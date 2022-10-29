using System;

namespace Lab2.Interfaces
{
    public interface IFaker
    {
        public T Create<T>();

        public object Create(Type t);
    }
}