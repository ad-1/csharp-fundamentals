using System;
using System.IO;
using System.Collections.Generic;

namespace GradeBook
{

    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
        }

        public override event GradeAddedDelegate GradeAdded;

        public override Statistics GetStatistics()
        {
            using (var reader = File.OpenText($"{Name}.txt"))
            {
                Statistics stats = new Statistics();
                var line = reader.ReadLine();
                while (line != null)
                {
                    stats.AddStat(float.Parse(line));
                    line = reader.ReadLine();
                }
                return stats;
            }
        }

        public override void StoreGrade(float grade)
        {
            if (!ValidateGrade(grade))
            {
                return;
            }
            using (var writer = File.AppendText($"{Name}.txt"))
            {
                writer.WriteLine(grade);
                if (GradeAdded != null)
                {
                    GradeAdded.Invoke(this, new EventArgs());
                }
            }
        }
    }

}