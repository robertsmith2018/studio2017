using System;
using System.Collections.Generic;
using System.Text;

namespace Atelier_1
{
    enum gender { Male, Female }
    enum level { Beginner, Intermediate, Advanced }

    struct Student
    {
        public string Name { get; set; }
        public gender Gender { get; set; }
        public level Level { get; set; }

        public Student(string name, gender gender, level level)
        {
            this.Name = name;
            this.Gender = gender;
            this.Level = level;
        }
    }
}
