using System;
using System.Collections.Generic;

namespace SecondTask
{
    class SecondTask
    {
        static void Main(string[] args)
        {
            List<Int32> list = new List<int>();
            Random random = new Random();
            for (; ; )
            {
                list.Insert(0, random.Next(1, 100));
                if (list.Count > 12)
                {
                    int sum = 0, counter = 0;
                    double average = 0.0;
                    for (int i = 3; i <= 12; i++)
                    {
                        counter++;
                        sum += list[i];
                    }
                    average = (double)sum / counter;
                }
            }
        }
    }
}
