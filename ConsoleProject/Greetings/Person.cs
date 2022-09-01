using System;

namespace Greetings
{
    class Person
    {
        protected string name = "";
        protected int phoneNumber = 0;
        protected string emailAddress = "";

        //default constructor
        public Person()
        {
            this.name = "John Doe";
        }

        //one argument constructor (name)
        public Person (string name)
        {
            this.name = name;
        }

        public virtual void SayGreeting()
        {
            Console.WriteLine("Hello, I'm " + name);
        }
    }

}