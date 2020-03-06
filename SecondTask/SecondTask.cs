using System;
using System.Collections.Generic;

namespace SecondTask
{
    class SecondTask
    {
        static void Main(string[] args)
        {
            const int StartRange = 3;
            const int EndRange = 12;
            const double RangeSize = 10.0;
            List<Int32> list = new List<int>();
            Random random = new Random();
            double averageOld, average = 0.0;
            for (; ; )
            {
                list.Insert(0, random.Next(1, 100));
                if (list.Count > 12)
                {
                    averageOld = 0.0;
                    for (int i = StartRange; i <= EndRange; i++)
                    {
                        averageOld += (double)list[i] / RangeSize;
                        average = averageOld;
                    }
                }
            }
        }
    }
}
