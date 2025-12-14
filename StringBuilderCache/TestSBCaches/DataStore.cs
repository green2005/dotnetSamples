using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class DataStore<T> where T : Stream
    {
        private readonly T _data;
        public DataStore(T inst) 
        { 
            _data = inst;
        
        }
        public T GetValue() 
        {
            return _data;
        }


    }
}
