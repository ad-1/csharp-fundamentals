namespace GradeBook
{

    public class Statistics
    {

        public float High;
        public float Low;
        private float sum;
        private int count;

        public float Average
        {
            get
            {
                return sum / count;
            }
        }

        public char Letter
        {
            get
            {
                switch (Average)
                {
                    case var d when d >= 90:
                        return 'A';
                    case var d when d >= 80:
                        return 'B';
                    case var d when d >= 70:
                        return 'C';
                    case var d when d >= 50:
                        return 'D';
                    case var d when d >= 0:
                        return 'F';
                    default:
                        return 'N';
                }
            }
        }

        public Statistics()
        {
            this.Low = float.MaxValue;
            this.High = float.MinValue;
            this.sum = 0;
            this.count = 0;
        }

        public void AddStat(float value)
        {
            sum += value;
            count++;
            High = (value > High) ? value : High;
            Low = (value < Low) ? value : Low;
        }

    }

}