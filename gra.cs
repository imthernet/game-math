using System;
using System.Threading;

namespace ConsoleGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int number1;
            int number2;
            int timeLimit = 5;
            int score = 0;
            int incorrectAnswers = 0;
            int attempts = 0;
            ConsoleKeyInfo key;
            bool keyPressed = false;

            Console.WriteLine("Witaj w grze! Naciśnij strzałkę w prawo, jeśli działanie jest parzyste, lub strzałkę w lewo, jeśli jest nieparzyste.");
            Console.WriteLine("Naciśnij dowolny klawisz, aby rozpocząć grę.");
            Console.ReadKey();

            //while (incorrectAnswers < 3)
            while (true)
            {
                number1 = random.Next(0, 100);
                number2 = random.Next(0, 100);
                int result = number1 + number2;

                Console.WriteLine(number1 + " + " + number2);

                Console.WriteLine("Masz " + timeLimit + " sekund na dokonanie wyboru.");
                int timeLeft = timeLimit;

                var timer = new Timer(state =>
                {
                    keyPressed = true;
                }, null, timeLimit * 1000, Timeout.Infinite);

                while (!keyPressed)
                {
                    Console.Write("Czas pozostały: " + timeLeft + "\r");
                    Thread.Sleep(1000);
                    timeLeft--;

                    if (Console.KeyAvailable)
                    {
                        key = Console.ReadKey(true);
                        keyPressed = true;
                        timer.Dispose();

                        if ((result % 2 == 0 && key.Key == ConsoleKey.RightArrow) ||
                            (result % 2 != 0 && key.Key == ConsoleKey.LeftArrow))
                        {
                            Console.WriteLine("\nGratulacje! Odpowiedź jest poprawna.");
                            score++;
                        }
                        else
                        {
                            Console.WriteLine("\nNiestety, odpowiedź jest niepoprawna.");
                            Console.WriteLine("Twój wynik to: " + score);
                            //incorrectAnswers++;
                            return;
                        }
                    }
                if (timeLeft == 0)
                {
                    attempts++;
                    Console.WriteLine("\nNiestety, czas upłynął.");
                    if (attempts >= 3)
                    {
                        Console.WriteLine("Przekroczono limit prób. Przerywam gre.");
                        return;
                    }
                    break;
                }
                }
                

                keyPressed = false;
                Console.WriteLine();
            }
        }
    }
}
