using System;
using System.Drawing;

namespace ImageMontageProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MontageManager montageManager = new MontageManager();

            string command = "";

            while (command != "end")
            {
                Console.Write("Enter location:");
                string imageLocation = Console.ReadLine();

                Bitmap image = new Bitmap(imageLocation);

                Console.WriteLine($"1.Random Filter\n2.Custom Filter");

                start:

                command = Console.ReadLine();

                if (command.Equals("1"))
                {
                    var random = new Random();
                    int r = random.Next(0, 255);
                    int g = random.Next(0, 255);
                    int b = random.Next(0, 255);

                    Bitmap newRandomImage = montageManager.ColorFormatting(image, r, g, b);
                    montageManager.SaveFile(newRandomImage);
                    image.Dispose();
                }

                else if (command.Equals("2"))
                {
                    Console.Write("Red:");
                    int red = int.Parse(Console.ReadLine());
                    Console.Write("Green:");
                    int green = int.Parse(Console.ReadLine());
                    Console.Write("Blue:");
                    int blue = int.Parse(Console.ReadLine());

                    Bitmap newImage = montageManager.ColorFormatting(image, red, green, blue);
                    montageManager.SaveFile(newImage);
                    image.Dispose();
                }

                else
                {
                    Console.Write("Choose the correct command:");
                    goto start;
                }
            }
        }
    }
}