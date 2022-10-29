using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Lab2.Interfaces;
using Lab2.Generators;
namespace Lab2.Main
{
    public class Faker : IFaker
    {
        private GeneratorContext _context;
        private List<IValueGenerator> Generators;
        private FakerConfig _config = null;
        private HashSet<Type> makingTypes = new HashSet<Type>();

        public Faker(FakerConfig config)
        {
            var _random = new Random();
            _context = new GeneratorContext(_random, this);
            Generators = LoadGenerators();
            _config = config;
        }
        public Faker()
        {
            var _random = new Random();
            _context = new GeneratorContext(_random, this);
            Generators = LoadGenerators();
        }

        private List<IValueGenerator> LoadGenerators()
        {
            List<IValueGenerator> listGenerators = new List<IValueGenerator>();
            var types = Assembly.GetExecutingAssembly().GetTypes();
            foreach (var type in types)
            {
                if ((typeof(IValueGenerator).IsAssignableFrom(type)) && (typeof(IValueGenerator) != type))
                    listGenerators.Add((IValueGenerator)Activator.CreateInstance(type));
            }
            return listGenerators;
        }
        private object GetDefault(Type type)
        {
            if (type.IsValueType)
                return Activator.CreateInstance(type);
            else
            {
                return null;
            }
        }
        public T Create<T>()
        {
            return (T)Create(typeof(T));
        }
       
        public object Create(Type t)
        {
            foreach (var generator in Generators)
            {
                if (generator.CanGenerate(t))
                    return generator.Generate(t,_context);
            }

            if (makingTypes.Contains(t))
                return null;
            if (!t.IsGenericType)
                makingTypes.Add(t);
            Dictionary<String, IValueGenerator> handleGenerators = null;
            if (_config != null)
                handleGenerators = _config.GetHandleConstructors(t);
            var constructed = ExecuteConstruct(t,handleGenerators);
            var Properties = constructed.GetType().GetProperties();
            foreach (var Property in Properties)
            {
                if (Property.CanWrite && ( Property.GetValue(constructed)==null || Property.GetValue(constructed).Equals(GetDefault(Property.PropertyType))))
                {
                    Property.SetValue(constructed,(handleGenerators!=null && handleGenerators.ContainsKey(Property.Name))?handleGenerators[Property.Name].Generate(Property.PropertyType,_context): Create(Property.PropertyType));
                }
            }

            var Fields = constructed.GetType().GetFields();
            foreach(var Field in Fields)
                if (Field.IsPublic && (Field.GetValue(constructed)==null || Field.GetValue(constructed).Equals(GetDefault(Field.FieldType))))
                    Field.SetValue(constructed,(handleGenerators!=null && handleGenerators.ContainsKey(Field.Name))?handleGenerators[Field.Name].Generate(Field.FieldType,_context):Create(Field.FieldType));
            makingTypes.Remove(t);
            return constructed;
        }

        private object ExecuteConstruct(Type t,Dictionary<String,IValueGenerator> handleGenerators)
        {
            var Constructors = t.GetConstructors().ToList()
                .OrderByDescending(c=>c.GetParameters().Length).ToList();
            foreach (var constructor in Constructors)
            {
                try
                {
                    return constructor.Invoke(constructor.GetParameters().Select
                        (parametr=>(handleGenerators!=null && handleGenerators.ContainsKey(parametr.Name))?handleGenerators[parametr.Name].Generate(parametr.ParameterType,_context):Create(parametr.ParameterType)).ToArray());
                }
                catch(Exception e)
                {
                    //Console.WriteLine(e.Message);
                    //Console.WriteLine("Trouble");
                }
            }
            return null;
        }
        
    }
}