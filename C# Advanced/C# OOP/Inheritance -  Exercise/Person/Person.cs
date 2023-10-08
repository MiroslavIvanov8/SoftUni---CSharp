using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    public class Person
    {
        private int age;
        private string name;
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public int Age
        {
            get
            {
                return age;
            }

            set
            {
                if (value >= 0)
                {
                    age = value;
                }
                
            }

        }
        public string Name
        {
            get 
            {
                return name;
            }

            set
            { 
                name = value;
            }

        }
        public override string ToString()
        {


            return $"Name: {this.Name}, Age: {this.Age}";
        }
    }
    public class Child : Person
    {
        private int age;
        public Child(string name, int age) : base(name, age)
        { 

        }            

        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (value <= 15)
                {
                    age = value;
                }
               
            }
        }
    }
}
        
         
    
 

  

        
        

    
	