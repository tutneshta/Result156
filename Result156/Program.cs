using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Result156
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var classes = new[]
            {
                new Classroom { Students = { "Evgeniy", "Sergey", "Andrew" } },
                new Classroom { Students = { "Anna", "Viktor", "Vladimir" } },
                new Classroom { Students = { "Bulat", "Alex", "Galina" } }
            };

            var allStudents = GetAllStudents(classes);

            Console.WriteLine(string.Join(" ", allStudents));
        }

        private static string[] GetAllStudents(Classroom[] classes)
        {
            var classrooms = classes.Select(s => s.Students);

            var studentInClassrooms = classrooms as List<string>[] ?? classrooms.ToArray();
            var allStudent = new string[studentInClassrooms.Select(s => s.Count).Sum()];

            var i = 0;

            foreach (var studentInClassroom in studentInClassrooms)
            foreach (var student in studentInClassroom)
            {
                allStudent[i] = student;
                i++;
            }

            return allStudent;
        }

        public class Classroom
        {
            public List<string> Students = new List<string>();
        }
    }
}