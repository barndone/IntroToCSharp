using System;

namespace Greetings
{
    class TestClass
    { 
        static void Main()
        {
            Person testPersonA = new Person();
            Person testPersonB = new Person("Brandon");
            Doctor testDoctorA = new Doctor();
            Doctor testDoctorB = new Doctor("Natalie");

            testPersonA.SayGreeting();
            testPersonB.SayGreeting();
            testDoctorA.SayGreeting();
            testDoctorB.SayGreeting();
        }
    }
}
