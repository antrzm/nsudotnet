using System;
using System.Collections.Generic;
using System.IO;

namespace task2 {
    internal static class Program {
        private static readonly string[] CheeringPhrases = {
            "You're almost there, try again!", "Please, just one more time!", "You've almost got it!", "Don't give up!"
        };

        public static void Main() {
            var history = new List<KeyValuePair<string, string>>();
            try {
                Console.WriteLine("Please, name yourself:");
                var name = Console.ReadLine();
                Console.WriteLine($"Hello, {name}! Let's play");
                var randomNum = new Random().Next(0, 50);
                var guessCounter = 0;
                var userGuess = Console.ReadLine();
                var startTime = DateTime.Now;
                var prevPhrase = "";             //to avoid repeats in cheering phrases
                do {
                    guessCounter++;
                    try {
                        if (int.Parse(userGuess) > 50 || int.Parse(userGuess) < 0) throw new FormatException();
                        if (int.Parse(userGuess) > randomNum) {
                            Console.WriteLine("Too big");
                            history.Add(new KeyValuePair<string, string>(userGuess, "Too big"));
                        }

                        if (int.Parse(userGuess) < randomNum) {
                            Console.WriteLine("Too little");
                            history.Add(new KeyValuePair<string, string>(userGuess, "Too little"));
                        }

                        if (int.Parse(userGuess) == randomNum) {
                            Console.WriteLine($"Congrats! You nailed it with {guessCounter} guess(es)!\n");
                            history.Add(new KeyValuePair<string, string>(userGuess, "Right answer!"));
                            Console.WriteLine("Your guesses were:");
                            foreach (var item in history) {
                                Console.WriteLine($"{item.Key} {item.Value}");
                            }

                            var difTime = DateTime.Now - startTime;
                            Console.WriteLine(
                                $"\nYour time: {difTime.Minutes}:{difTime.Seconds}");
                            break;
                        }
                    }
                    catch (FormatException) {
                        Console.WriteLine("You must guess a number from 0 to 50, not something else!");
                        userGuess = Console.ReadLine();
                        continue;
                    }

                    if (guessCounter % 4 == 0) {
                        string curPhrase;
                        do {
                            var randPhraseNum = new Random().Next(0, CheeringPhrases.Length);
                            curPhrase = CheeringPhrases[randPhraseNum];
                        } while (curPhrase == prevPhrase);

                        prevPhrase = curPhrase;
                        Console.WriteLine(curPhrase);
                    }

                    userGuess = Console.ReadLine();
                } while (userGuess != "q");

                if (userGuess.Equals("q"))
                    Console.WriteLine($"Sorry to see you go, {name}!");
            }
            catch (IOException exception) {
                Console.Write(exception.Message);
            }
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadLine();
        }
    }
}