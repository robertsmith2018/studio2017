using System;
using System.Collections.Generic;

namespace Atelier_1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Exercice 1
            /*
               //saisie
               int heures = 0;
               int minutes = 0;
               try
               {
                   Console.WriteLine("Donner le nombre des heures");
                   heures = Int32.Parse(Console.ReadLine());
                   Console.WriteLine("Donner le nombre des minutes");
                   minutes = Int32.Parse(Console.ReadLine());
               }
               catch (FormatException)
               {
                   Console.WriteLine("Valeurs numeriques seulement");
                   Console.ReadKey();
                   return;
               }
               //message erreur
               if (!(heures >= 0 && minutes >= 0))
               {
                   Console.WriteLine("Valeur négative non acceptée");
                   Console.ReadKey();
                   return;
               }
               //conversion en secondes
               int secondes = heures * 3600;
               secondes += minutes * 60;
               Console.WriteLine("Valeur en secondes est " + secondes);
            
            // Exercice 2
            string[] months = { "Jan", "Fev", "Mar", "Avr", "Mai", "Jun", "Jui", "Aou", "Sep", "Oct", "Nov", "Dec" };
            try
            {
                int numero = 0;
                do {
                    Console.WriteLine("Donner le numero de mois (entre 1 et 12)");
                    numero = Int32.Parse(Console.ReadLine());
                }
                while (!(numero > 0 && numero < 13));
            
               Console.WriteLine("Le mois correspondant est " + months[numero - 1]); 
            
            }
            catch (FormatException)
            {
                Console.WriteLine("Valeurs numeriques seulement");
                Console.ReadKey();
                return;
            }
            //Exercice 3
            int[] numbers = { 1, 2, 3, 2, 1, 3, 5, 2, 3, 1};
            int numPeaks = 0;
            if (numbers.Length > 2)
            {
                for (int i = 1; i < numbers.Length - 1; i++)
                {
                    if ((numbers[i] > numbers[i + 1]) && (numbers[i] > numbers[i - 1]))
                    {
                        numPeaks++;
                    }
                }
            }
            Console.WriteLine("Numbre de pics est " + numPeaks);
            
            //Exercie 4
            string[] mots = { "The", "are", "is", "The", "is", "is" };
            List<string> mots_unique = new List<string>();
            foreach(string s in mots)
            {
                if (!mots_unique.Contains(s))
                {
                    mots_unique.Add(s);
                }
            }
            foreach(string s in mots_unique)
            {
                int nb = 0;
                foreach(string m in mots)
                {
                    if (s == m)
                    {
                        nb++;
                    }
                }
                Console.WriteLine("Le mot " + s + " existe " + nb +" fois");
            }
            */
            //Exercice 5
            Student std1 = new Student("Felix", gender.Male, level.Beginner);
            Student std2 = new Student("Annie", gender.Female, level.Beginner);
            Student std3 = new Student("Sam", gender.Male, level.Advanced);
            Student std4 = new Student("Myriam", gender.Female, level.Intermediate);

            Student[] students = { std1, std2, std3, std4 };
            //demander un level
            Console.WriteLine("Donner un level(1: Beginner, 2: Intermediate, 3: Advanced)");
            int numero = Int32.Parse(Console.ReadLine());
            level selectedLevel;
            switch (numero)
            {
                case 1: selectedLevel = level.Beginner; break;
                case 2: selectedLevel = level.Intermediate; break;
                case 3: selectedLevel = level.Advanced; break;
                default: selectedLevel = level.Beginner; break;
            }

            List<Student> results = getStudentsByLevel(students, selectedLevel);

            foreach (Student s in results)
            {
                Console.WriteLine(s.Name);
            }
            Console.ReadKey();
        }

        public static List<Student> getStudentsByLevel(Student[] students, level level)
        {
            List<Student> selectedStudents = new List<Student>();

            foreach (Student s in students)
            {
                if (s.Level == level)
                {
                    selectedStudents.Add(s);
                }
            }

            return selectedStudents;
        }
    }
}
