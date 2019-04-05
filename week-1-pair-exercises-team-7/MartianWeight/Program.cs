// This is the Scarlet Johansson of MartianWeight programs.  The program will allow the user to create an array of X lenght,
// and then the user can input weights to convert into Mars weight.

using System;

namespace MartianWeight
{
    /*
    In case you've ever pondered how much you weight on Mars, here's the calculation:
    Wm = We* 0.378
    where 'Wm' is the weight on Mars, and 'We' is the weight on Earth

    Write a command line program which accepts a series of Earth weights from the user  
    and displays each Earth weight as itself, and its Martian equivalent.


    C:\Users> MartianWeight  
    Enter a series of Earth weights (space-separated): 98 235 185

    98 lbs.on Earth, is 37 lbs.on Mars.
    235 lbs.on Earth, is 88 lbs.on Mars.
    185 lbs.on Earth, is 69 lbs.on Mars. 
    */
    class Program
    {
        static void Main(string[] args)
        {
            // Enter the amount of weights to input, accept the number, set the variable for arrayLength
            Console.WriteLine("Please enter the amount of weights you want to convert: ");
            string weightsInput = Console.ReadLine();
            int numberOfWeights = int.Parse(weightsInput);

            // Start a loop to prompt the user for each weight variable
            double[] acceptedWeights = new double[numberOfWeights];

            for (int i = 0; i < acceptedWeights.Length; i++)
            {
                Console.WriteLine($"Please enter a weight for index {i}: ");
                string weight = Console.ReadLine();
                double setWeight = double.Parse(weight);
                acceptedWeights[i] = setWeight;
            }

            // run the EarthToMarsConverter method
            EarthToMarsConverter(acceptedWeights, numberOfWeights);

            Console.ReadKey();

        }
        public static void EarthToMarsConverter(double[] earthWeight, int arrayLength)
        {
            // Method converts the weights and outputs the result
            for (int i = 0; i < earthWeight.Length; i++)
            {
                Console.WriteLine($"{earthWeight[i]} lbs on Earth, is {earthWeight[i] * 0.378} lbs on Mars.");
            }

            return;
        }
    }
}
