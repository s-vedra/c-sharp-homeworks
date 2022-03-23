using System;
using System.Collections.Generic;
using System.Text;

namespace Task1.Classes
{
    public class Driver
    {
        public string Name { get; set; }
        public decimal Skill { get; set; }
        public bool Selected { get; set; }

        public Driver(string name, decimal skill)
        {
            Name = name;
            Skill = skill;
        }
    }

    
}
