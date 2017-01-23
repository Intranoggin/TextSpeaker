using System;
using System.Speech.Synthesis;
using System.IO;

namespace TextSpeaker
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				using (SpeechSynthesizer synth = new SpeechSynthesizer())
				{
					synth.SetOutputToDefaultAudioDevice();

					using (StreamReader sr = new StreamReader("script.txt"))
					{
						while (!sr.EndOfStream)
						{
							String line = sr.ReadLine();
							Console.WriteLine(line);

							synth.Speak(line);

							Console.ReadKey();
						}
					}
				}
			}
			catch (Exception e)
			{
				Console.WriteLine("The file could not be read:");
				Console.WriteLine(e.Message);
			}
			Console.WriteLine();
			Console.WriteLine("Press any key to exit...");
			Console.ReadKey();

		}
	}
}
