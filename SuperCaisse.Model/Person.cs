using System;
using System.Collections.Generic;
using System.Text;

namespace SuperCaisse.Model
{
    public abstract class Person
    {
        public string Name { get; }
        public Details Details { get; }
        
        protected Person(string name, Details details)
        {
            Name = name;
            Details = details;
        }
    }
}
