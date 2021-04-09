using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook
{
   public class statistics
    {
        public double Average
        {
            get 
            {
                return sum / count;
            }
        }
        public double high;
        public double low;

        public char letter
        {
            get 
            {
                switch (Average)
                {
                    case var d when d >= 90.0:
                        return 'A';

                    case var d when d >= 80.0:
                        return 'B';

                    case var d when d >= 70.0:
                        return 'C';

                    case var d when d >= 60.0:
                        return 'D';

                    case var d when d >= 50.0:
                        return 'E';

                    default:
                        return 'F';
                }
            }
        }
        
        public double sum;
        public int count;

        public void Add(double number)
        {
            sum += number;
            count += 1;

            high = Math.Max(number, high);
            low = Math.Min(number, low);

        }
        public statistics()
        {
            count = 0;
            sum = 0.0;
            high = double.MinValue;
            low = double.MaxValue;
        }
    }
}
