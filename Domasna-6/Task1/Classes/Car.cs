using System;
using System.Collections.Generic;
using System.Text;

namespace Task1.Classes
{
    public class Car
    {
        public string Model { get; set; }
        public int Speed { get; set; }
        public Driver Driver { get; set; }
        public bool Selected { get; set; }


        
        public Car(string model, int speed)
        {
            Model = model;
            Speed = speed;
        }
        

        public int CalculateSpeed()
        {
            return (int) Driver.Skill * Speed;
        }
      
    }
}
