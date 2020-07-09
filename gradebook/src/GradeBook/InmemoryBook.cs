using System;
using System.Linq;
using System.Collections.Generic;

namespace GradeBook
{

    public class InmemoryBook : Book
    {

        public override event GradeAddedDelegate GradeAdded;
        private List<float> grades;

        public InmemoryBook(string name) : base(name)
        {
            this.grades = new List<float>();
        }

        public override void StoreGrade(float grade)
        {
            if (!ValidateGrade(grade))
            {
                return;
            }
            this.grades.Add(grade);
            if (GradeAdded != null)
            {
                GradeAdded.Invoke(this, new EventArgs());
            }
        }

        public void StoreGrades(List<float> newGrades)
        {
            foreach (float grade in newGrades)
            {
                StoreGrade(grade);
            }
        }

        public int GetGradeCount()
        {
            return grades.Count;
        }

        public void PrintGrades()
        {
            System.Console.WriteLine("=============================");
            foreach (float grade in grades)
            {
                System.Console.WriteLine($"  {grade}");
            };
            System.Console.WriteLine("=============================");
        }

        public override Statistics GetStatistics()
        {
            var stats = new Statistics();
            foreach (float grade in grades)
            {
                stats.AddStat(grade);
            }
            return stats;
        }

    }

}
