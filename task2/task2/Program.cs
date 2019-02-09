using System;
using System.IO;

namespace task2 {
    internal static class Program {
        private static readonly string[] CheeringPhrases = {
            "You're almost there, try again!", "Please, just one more time!", "You've almost got it!", "Don't give up!"
        };

        private static int randomNum;

        //TODO:
        //random (0 to 50);
        //time;
        //history (with more/less marks);
        //random cheering phrase


        public static void Main(string[] args) {
            try {
                Console.WriteLine("Please, name yourself:");
                var name = Console.ReadLine();
                randomNum = 1; //TODO: add random number generation
                Console.WriteLine("Hello, " + name + "! Let's play");
                var guessCounter = 0;
                var userGuess = Console.ReadLine();
                do {
                    guessCounter++;
                    try {
                        if (int.Parse(userGuess) > 50 || int.Parse(userGuess) < 0) throw new FormatException();
                        if (int.Parse(userGuess) > randomNum) Console.WriteLine("Too big");
                        if (int.Parse(userGuess) < randomNum) Console.WriteLine("Too little");
                        if (int.Parse(userGuess) == randomNum)
                            Console.WriteLine("Congrats! You nailed it with " + guessCounter + " guesses!");
                    }
                    catch (FormatException) {
                        Console.WriteLine("You must guess a number from 0 to 50, not something else!");
                        userGuess = Console.ReadLine();
                        continue;
                    }

                    if (guessCounter % 4 == 0) {
                        Console.WriteLine(CheeringPhrases[(guessCounter / 4 - 1) % CheeringPhrases.Length]);
                    }

                    userGuess = Console.ReadLine();
                } while (userGuess != randomNum.ToString() && !userGuess.Equals("q"));

                if (userGuess.Equals("q"))
                    Console.WriteLine("Sorry to see you go!");
                if (int.Parse(userGuess) == randomNum)
                    Console.WriteLine("Congrats! You nailed it with " + guessCounter + " guesses!");
            }
            catch (IOException exception) {
                Console.Write(exception.Message);
            }
        }
    }
}