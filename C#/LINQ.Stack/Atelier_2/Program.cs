using System;
using System.Collections.Generic;
using System.Linq;

namespace Atelier_2
{
    class Program
    {
        static void Main(string[] args)
        {
         /*   //Exercice 1
            List<String> names = new List<String>(){ "Felix", "Sam", "Xavier", "Pascal", "Éric", "Ben" };
            foreach (string s in names)
            {
                Console.Write("\t" + s);
            }
            Console.WriteLine();
            int i = 2, j = 4;

            for(int index=i; index<=j/2; index++)
            {
                    string temp = names[index];
                    names[index] = names[j - index + i];
                    names[j - index + i] = temp;
            }
           
            foreach(string s in names)
            {
                Console.Write("\t" + s);
                
            }
            Console.ReadKey();
            */
            //Exercice 2
            /*List<String> names = new List<String>() { "Pascal", "Felix", "Sam", "Xavier", "Pascal", "Éric", "Ben", "Felix" };
            List<string> unique_names = new List<string>();
        
            foreach(string name in names)
            {
                if (!unique_names.Contains(name))
                {
                    unique_names.Add(name);
                }
            }

            Console.WriteLine("Il y a " + unique_names.Count + " noms distincts");
            Console.ReadKey();
            */
            // Exercice 3
            /* Stack<int> p1 = new Stack<int>();
             p1.Push(5); p1.Push(6); p1.Push(3); p1.Push(2);
             Stack<int> p2 = new Stack<int>();

             while (p1.Count > 0)
             {
                 int val = p1.Pop();
                 p2.Push(val);
             }
             */
            // Exercice 4
            /*Stack<int> p1 = new Stack<int>();
            p1.Push(5); p1.Push(6); p1.Push(3); p1.Push(2);
            Stack<int> p2 = new Stack<int>();

            while (p1.Count > 0)
            {
                int val = p1.Pop();
                p2.Push(val);
            }

            p1.Push(7);

           while (p2.Count > 0)
           {
               int val = p2.Pop();
               p1.Push(val);
           }*/
            // Exercice 5
            /*List<string> prenoms = new List<string>() { "Marc", "carl", "Marie", "Laurie" };

            var req = from p in prenoms
                      where p.ToUpper().StartsWith("M") || p.ToUpper().StartsWith("C")
                      select p;

            foreach(string s in req)
            {
                Console.WriteLine(s);
            }*/
            /**/  //Exercice 6
              List<Employee> employees = new List<Employee>();
              employees.Add(new Employee("Felix", new DateTime(2010,05,05), "Marketing", 50000));
              employees.Add(new Employee("Sam", new DateTime(2009, 06, 14), "Accounting", 42000));
              employees.Add(new Employee("Ben", new DateTime(2015, 07, 25), "Marketing", 35000));
              employees.Add(new Employee("Annie", new DateTime(1998, 12, 23), "IT", 70546));
              employees.Add(new Employee("Myriam", new DateTime(2012, 03, 01), "Accounting", 23564));
              employees.Add(new Employee("Pascal", new DateTime(2010, 10, 09), "Marketing", 28000));
              employees.Add(new Employee("Alex", new DateTime(2011, 11, 15), "IT", 64825));
              /**/
              // First Question:
              /*
              var req1 = from emp in employees
                         orderby emp.Hiredate
                         select emp;

              foreach(var emp1 in req1)
              {
                  Console.WriteLine(emp1.Name + "\t" + emp1.Hiredate) ;
              }
              Console.ReadKey();
             */
              //Second Question:
              /*
              var req2 = from emp in employees
                         where emp.Department.Equals("Marketing")
                         orderby emp.Name
                         select emp;

              foreach (var emp in req2)
              {
                  Console.WriteLine(emp.Name + "\t" + emp.Department);
              }

                 Console.ReadKey();
            /**/

            //Third Question :
             /*
              var req3 = from emp in employees
                         where emp.Salary < 40000
                         orderby emp.Name
                         select emp;

              foreach (var emp in req3)
              {
                  Console.WriteLine(emp.Name + "\t" + emp.Salary);
              }
            Console.ReadKey();
            */
            
            //4th Question
            /*
            var req4 = from emp in employees
                        select emp.Salary;

            Console.WriteLine("La moyenne des salaires est " + req4.Average());
            Console.ReadKey();
            */
            //5th Question
            /*
            var req5 = from emp in employees
                        select emp.Salary;

             Console.WriteLine("Le salaire le plus élevé est " + req5.Max());
             Console.WriteLine("Le salaire le moins élevé est " + req5.Min());

             Console.ReadKey();
             */
        }
    }
}
