using System;
using System.Linq;
using System.Collections.Generic;

namespace GradeBook
{

    public class Book
    {

        // MARK: - Properties

        private List<float> grades;
        private string name;

        // MARK: - Init

        public Book(string name, float[] grades)
        {
            this.name = name;
            this.grades = grades.ToList<float>();
        }

        // MARK: - Handlers

        public void StoreGrades(float[] newGrades)
        {
            foreach (float grade in newGrades)
            {
                Console.WriteLine($"Adding new grade: {grade}");
            }
            this.grades.AddRange(newGrades);
        }

        private float GetHighestGrade()
        {
            return grades.Max();
        }

        public float GetLowestGrade()
        {
            return grades.Min();
        }

        public float GetAverageGrade()
        {
            float total = 0;
            foreach (float grade in grades)
            {
                total += grade;
            }
            return total / grades.Count;
        }

        public Statistics GetStatistics()
        {
            return new Statistics(
                high: GetHighestGrade(),
                low: GetLowestGrade(),
                average: GetAverageGrade()
            );
        }

    }

}