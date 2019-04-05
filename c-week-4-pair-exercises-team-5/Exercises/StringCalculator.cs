using System;
using System.Collections.Generic;
using System.Text;

namespace Exercises
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (numbers != null)
            {
                string[] separatedNums;

                if (numbers.Contains("//"))
                {
                    // Define custom delimiter
                    char customDelimiter = numbers[2];

                    // Remove slashes from string
                    numbers = numbers.Remove(0, 3);

                    separatedNums = numbers.Split(new char[] { ',', '\n', customDelimiter }, StringSplitOptions.RemoveEmptyEntries);
                }
                else
                {
                    separatedNums = numbers.Split(new char[] { ',', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                }


                int sum = 0;

                for (int i = 0; i < separatedNums.Length; i++)
                {
                    sum += int.Parse(separatedNums[i]);
                }

                return sum;
            }
            else
            {
                return 0;
            }
        }
    }
}
