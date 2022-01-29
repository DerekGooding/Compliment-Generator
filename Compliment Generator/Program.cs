using System;
using System.Speech.Synthesis;
using System.Threading;

namespace Compliment_Generator
{
    class Program
    {
        static Random rand = new Random();
        static void Main()
        {
            bool isExiting = false;
            do
            {
                Console.WriteLine("Press Any Key for compliment! ESC exits");
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape) isExiting = true;
                Console.Clear();
                var output = GenerateCompliment();
                Console.WriteLine(output);
                TextToSpeech(output);
                Console.WriteLine();
            } while (!isExiting);
        }

        static string GenerateCompliment()
        {
            string output = string.Empty;
            output = ComplimentPart(StartArray) + " "
                + ComplimentPart(MiddleArray) + " "
                + ComplimentPart(EndArray);
            return output;
        }

        static string ComplimentPart(string[] input) => input[rand.Next(0, input.Length)];

        static string[] StartArray =
        {
        "You are",
        "You smell like" ,
        "You look like",
        "I've never seen such"
        };
        static string[] MiddleArray =
        {
        "a sexy",
        "an awesome",
        "a magnificant",
        "a wonderful",
        "a glorious",
        "my one and only"
        };
        static string[] EndArray =
        {
        "king",
        "rockstar",
        "champion",
        "jedi master",
        "stallion",
        "mainstream hottie",
        };


        static void TextToSpeech(string input)
        {
            var synthesizer = new SpeechSynthesizer();
            synthesizer.SetOutputToDefaultAudioDevice();
            Thread thread = new Thread(() => { synthesizer.Speak(input);});
            thread.Start();
        }

    }
}
