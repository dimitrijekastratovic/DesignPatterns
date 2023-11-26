using System;
using Newtonsoft.Json;

namespace Prototype
{

	/// <summary>
	/// Prototype
	/// </summary>
	public abstract class Person
	{
		public abstract string Name { get; set; }
		public abstract Person? Clone(bool deepClone);
	}

    /// <summary>
    /// Concrete Prototype
    /// </summary>
    public class Manager : Person
    {
        public override string Name { get; set; }

        public Manager(string name)
        {
            Name = name;
        }

        public override Person? Clone(bool deepClone = false)
        {
            if(deepClone)
            {
                var objectAsJson = JsonConvert.SerializeObject(this);
                return JsonConvert.DeserializeObject<Manager>(objectAsJson);
            }
            return (Person)MemberwiseClone(); //shallow clone
        }
    }

    /// <summary>
    /// Concrete Prototype
    /// </summary>
    public class Employee : Person
    {
        public override string Name { get; set; }
        public Manager Manager { get; set; }

        public Employee(string name, Manager manager)
        {
            Name = name;
            Manager = manager;
        }

        public override Person? Clone(bool deepClone = false)
        {
            if(deepClone)
            {
                var objectAsJson = JsonConvert.SerializeObject(this);
                return JsonConvert.DeserializeObject<Employee>(objectAsJson);
            }
            return (Person)MemberwiseClone(); //shallow clone
        }
    }
}

