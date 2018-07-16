using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atelier_7.Models
{
    public class DataManager
    {
        public List<Department> Departments { get; set; }
        public List<Employee> Employees { get; set; }

        public DataManager()
        {
            Departments = new List<Department>();
            Employees = new List<Employee>();
            populate();
        }

        public void populate()
        {
            //ajouter quelques departements,
            if(Departments.Count == 0)
            {
                Departments.Add(new Department() {
                    ID = 1,
                    Name = "Informatique"
                });
                Departments.Add(new Department()
                {
                    ID = 2,
                    Name = "Mathématiques"
                });
                Departments.Add(new Department()
                {
                    ID = 3,
                    Name = "Techniques Juridiques"
                });
                Departments.Add(new Department()
                {
                    ID = 4,
                    Name = "Sciences Humaines"
                });
            }

            //ajouter quelques employés,
            if(Employees.Count == 0)
            {
                Employees.Add(new Employee()
                {
                    ID = 1, Name = "Jérémy", City = "Valleyfield",
                    Job = "Professeur", DepartmentID = 3
                });
                Employees.Add(new Employee()
                {
                    ID = 2,
                    Name = "Tim",
                    City = "Montréal",
                    Job = "Technicien",
                    DepartmentID = 1
                });
                Employees.Add(new Employee()
                {
                    ID =3,
                    Name = "Alain",
                    City = "Valleyfield",
                    Job = "Professeur",
                    DepartmentID = 1
                });
                Employees.Add(new Employee()
                {
                    ID = 4,
                    Name = "Annie",
                    City = "Québec",
                    Job = "Tecnnicienne",
                    DepartmentID = 4
                });
                Employees.Add(new Employee()
                {
                    ID = 5,
                    Name = "Antonia",
                    City = "St-foy",
                    Job = "Consultante",
                    DepartmentID = 2
                });
                Employees.Add(new Employee()
                {
                    ID = 6,
                    Name = "Catherine",
                    City = "Laval",
                    Job = "Professeure",
                    DepartmentID = 3
                });
            }
        }
    }
}
