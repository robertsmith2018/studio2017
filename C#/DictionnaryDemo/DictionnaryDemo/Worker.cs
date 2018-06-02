using System;
using System.Collections.Generic;
using System.Text;

namespace DictionnaryDemo
{
    public class Worker
    {
        public Worker()
        {
            Work();
        }

        public void Work()
        {
            Dictionary<string, Person> dict = new Dictionary<string, Person>();

            Person george = new Person() { Name = "George Washington", Age = 67 };
            string key = "George";
            dict.Add(key, george);

            dict.Add("john", new Person() { Name = "John ADAMS", Age = 90 });
            dict.Add("Thom", new Person() { Name = "Thomas Jefferson", Age = 91 });
            dict.Add("james", new Person() { Name = "John Adams", Age = 90 });

            Person thirdPresident = dict["Thom"];
            Console.Write("The third president of the United State was :" + thirdPresident.Name);

        }
    }
}
