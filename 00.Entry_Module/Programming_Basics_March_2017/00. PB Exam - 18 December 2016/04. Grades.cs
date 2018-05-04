using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            //https://judge.softuni.bg/Contests/368/Programming-Basics-Exam-18-December-2016
            //https://judge.softuni.bg/Contests/Practice/Index/368#3
            //https://softuni.bg/trainings/resources/video/13332/video-screen-11-march-2017-hristo-hentov-csharp-programming-basics-january-2017
            //https://softuni.bg/trainings/resources/video/13326/video-screen-11-march-2017-anton-petrov-csharp-programming-basics-january-2017
            // Border cases in else if must be equal and larger or smaller - this costs me 20 point until debugged!!!!

            int studentNum = int.Parse(Console.ReadLine());

            double topStudents = 0;
            double between4 = 0;
            double between3 = 0;
            double fail = 0;
            double averageCom = 0;

            for (int i = 1; i <= studentNum; i++)
            {
                double studenGrade = double.Parse(Console.ReadLine());

                averageCom += studenGrade;

                if (studenGrade >= 2.00 && studenGrade <= 2.99)
                {
                    fail++;
                }
                else if (studenGrade >= 3.00 && studenGrade <= 3.99)
                {
                    between3++;
                }
                else if (studenGrade >= 4.00 && studenGrade <= 4.99)
                {
                    between4++;
                }
                else if (studenGrade >= 5.00)
                {
                    topStudents++;
                }
            }
                     

            Console.WriteLine("Top students: {0:F2}%", (topStudents / studentNum) * 100);

            Console.WriteLine("Between 4.00 and 4.99: {0:F2}%", (between4 / studentNum) * 100);
            Console.WriteLine("Between 3.00 and 3.99: {0:F2}%", (between3 / studentNum) * 100);
            Console.WriteLine("Fail: {0:F2}%", (fail / studentNum) * 100);

            var average = averageCom / studentNum;
            Console.WriteLine("Average: {0:f2}", average);
        }
    }
}
