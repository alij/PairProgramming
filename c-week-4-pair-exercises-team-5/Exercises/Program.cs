using System;

namespace Exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            string result = "";

            string number = "38576";
            int num = int.Parse(number);

            int counter = 0;
            while (num >= 100000)
            {
                num -= 100000;
                counter++;
                
            }

            result += GetSingleNumber(num) + " hundred ";

            int counter2 = 0;
            while (num >= 10000)
            {
                num -= 10000;
                counter2++;

            }

            result += GetTenWord(counter2);

            string test = GetSingleNumber(counter);


        }

        public string GetSingleNumber(int number)
        {
            switch (number)
            {
                case 0:
                    return "zero";
                case 1:
                    return "one";
                case 2:
                    return "two";
                case 3:
                    return "three";
                case 4:
                    return "four";
                case 5:
                    return "five";
                case 6:
                    return "six";
                case 7:
                    return "seven";
                case 8:
                    return "eight";
                case 9:
                    return "nine";
                default:
                    return "";
            }
        }

        public string GetTenWord(int number)
        {
            switch (number)
            {
                case 10:
                    return "ten";
                case 11:
                    return "eleven";
                case 12:
                    return "twelve";
                case 13:
                    return "thirteen";
                case 14:
                    return "fourteen";
                case 15:
                    return "fifteen";
                case 16:
                    return "sixteen";
                case 17:
                    return "seventeen";
                case 18:
                    return "eighteen";
                case 19:
                    return "nineteen";
                case 20:
                    return "twenty";
                case 30:
                    return "thirty";
                case 40:
                    return "forty";
                case 50:
                    return "fifty";
                case 60:
                    return "sixty";
                case 70:
                    return "seventy";
                case 80:
                    return "eighty";
                case 90:
                    return "ninety";
                default:
                    return "";
            }
        }
    }
}
