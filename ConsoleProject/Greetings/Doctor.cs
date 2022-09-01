using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greetings
{
    internal class Doctor : Person
    {
        float Salary = 0.0f;

        public Doctor()
        {
            this.name = "John Doe";
        }

        public Doctor (string name)
        {
            this.name = name;
        }

        override public void SayGreeting()
        {
            Console.WriteLine("Hello, I'm Dr. " + name);

        }
    }
}
