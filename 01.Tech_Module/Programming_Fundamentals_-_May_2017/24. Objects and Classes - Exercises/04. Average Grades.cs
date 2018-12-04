using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Average_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            var students = new List<Student>();

            var studentsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < studentsCount; i++)
            {
                var tokens = Console.ReadLine().Split();
                var name = tokens.First();
                var grades = tokens
                    .Skip(1)
                    .Select(double.Parse)
                    .ToArray();

                var student = new Student()
                {
                    Name = name,
                    Grades = grades
                };

                students.Add(student);
            }

            students = students
                .Where(a => a.AverageGrade >= 5.00)
                .OrderBy(a => a.Name)
                .ThenByDescending(a => a.AverageGrade)
                .ToList();
            foreach (var student in students)
            {
                Console.WriteLine($"{student.Name} -> {student.AverageGrade:F2}");
            }
        }
    }
    class Student
    {
        public string Name { get; set; }
        public double[] Grades { get; set; }
        public double AverageGrade => this.Grades.Average();


    }
}
