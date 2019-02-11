using System;

namespace task1 {
    internal static class Program {
        public static void Main(string[] args) {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Please, write a date in dd.mm.yyyy format:");
            var date = Console.ReadLine();
            try {
                var day = int.Parse(date.Split('.')[0]);
                var month = int.Parse(date.Split('.')[1]);
                var year = int.Parse(date.Split('.')[2]);

                if (day > DateTime.DaysInMonth(year, month)) throw new FormatException();
                if (day > 31 || day < 1 || month > 12 || month < 1 || year < 0) throw new FormatException();

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Mon Tue Wed Thu Fri");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Sat Sun");

                var userMonthTime = new DateTime(year, month, 1);
                if (userMonthTime.DayOfWeek != DayOfWeek.Monday)
                    for (var i = 0; i < userMonthTime.DayOfWeek - DayOfWeek.Monday; i++)
                        Console.Write("    ");        //skipping empty days
                var weekendsCounter = 0;
                for (;;) {
                    if (userMonthTime.DayOfWeek == DayOfWeek.Sunday ||
                        userMonthTime.DayOfWeek == DayOfWeek.Saturday) {
                        Console.ForegroundColor = ConsoleColor.Red;
                        weekendsCounter++;
                    }
                    else Console.ForegroundColor = ConsoleColor.White;

                    Console.Write(userMonthTime.Day < 10 ? $" {userMonthTime.Day}  " : $" {userMonthTime.Day} ");
                    if (userMonthTime.DayOfWeek == DayOfWeek.Sunday) Console.WriteLine();
                    if (userMonthTime.Day == DateTime.DaysInMonth(year, month)) break;
                    userMonthTime = userMonthTime.AddDays(1);
                }

                Console.WriteLine(
                    $"\nNumber of working days: {DateTime.DaysInMonth(year, month) - weekendsCounter}");
            }
            catch (FormatException) {
                Console.WriteLine("Wrong format");
                return;
            }
            catch (ArgumentOutOfRangeException) {
                Console.WriteLine("Wrong format");
                return;
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadLine();
        }
    }
}