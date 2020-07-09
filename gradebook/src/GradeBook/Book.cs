using System;
using System.Collections.Generic;

namespace GradeBook
{

    public abstract class Book : NamedObject, IBook
    {
        public Book(string name) : base(name)
        {
        }
        public abstract event GradeAddedDelegate GradeAdded;
        public abstract Statistics GetStatistics();
        public abstract void StoreGrade(float grade);

        public virtual bool ValidateGrade(float grade)
        {
            return (0 <= grade && grade <= 100) ? true : false;
        }

    }

}