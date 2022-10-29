using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq.Expressions;
using Lab2.Interfaces;

namespace Lab2.Main
{
    public class FakerConfig
    {
        private Dictionary<String, Dictionary<String,IValueGenerator>> ConfigGenerators=new Dictionary<string, Dictionary<string, IValueGenerator>>();
        public void add<TClass,TType,TGenerator>(Expression<Func<TClass,TType>>e) where TGenerator : IValueGenerator
        {
            /*if (!typeof(IValueGenerator).IsAssignableFrom(typeof(TGenerator)))
                return false;*/
            var handleGenerator = (IValueGenerator)Activator.CreateInstance(typeof(TGenerator));
            var member = e.Body as MemberExpression;
            if (member == null)
                throw  new Exception();
            var memberName = member.Member.Name;
            ConfigGenerators.Add(typeof(TClass).Name,new Dictionary<string, IValueGenerator>());
            ConfigGenerators[typeof(TClass).Name].Add(memberName,handleGenerator);
            ConfigGenerators[typeof(TClass).Name][memberName] = handleGenerator;
            //return true;
        }

        public Dictionary<String, IValueGenerator> GetHandleConstructors(Type t)
        {
            
            if (ConfigGenerators.ContainsKey(t.Name))
                return ConfigGenerators[t.Name];
            return null;
        }
    }
}