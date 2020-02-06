using System;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;

namespace SupportBank
{
    public class MyProgram
    {
        public void MyMethod()
        {
            var mike = new Student();
            
            
            Console.Write($"The student's name is {mike.GetName()}");
        }
    }
    
    public class Student
    {
        // private string name;
        //
        // public string GetName()
        // {
        //     return name;
        // }
        //
        // public void SetName(string name)
        // {
        //     this.name = name;
        // }


        public string name;
        public string Name { get; set; }


        public string GetStudentInfo()
        {
            return $"the dog is called {name} and is {age} years old";
        }
        
        private 
        
    }
}