using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
	class Program
	{
		static void Main(string[] args)
		{

			Random random = new Random();

			string[] words = { "Big", "Small", "Medium", "Size", "Cool" };

			string wordToGuess = words[random.Next(0, words.Length)];
			string wordToGuessUppercase = wordToGuess.ToUpper();

			List<char> correctGuesses = new List<char>();
			List<char> incorrectGuesses = new List<char>();

			int lives = 10;
			bool won = false;
			int lettersRevealed = 0;
			char letter1 = wordToGuessUppercase[1];

			string input;
			char guess;
			char guess1;

			StringBuilder sb = new StringBuilder(wordToGuess.Length);
			for (int i = 0; i < wordToGuess.Length; i++)
				sb.Append('_');

			sb.Append(" Guessed letters: ");
			while (!won && lives > 0)
			{
				Console.WriteLine("Guess a Letter: ");
				input = Console.ReadLine().ToUpper();
				try
				{
					guess = input[0];
					guess1 = input[1];

					if (input == wordToGuess.ToUpper())
					{
						Console.WriteLine("You are correct!, the right word is: ");
						Console.WriteLine(wordToGuessUppercase);
						won = true;
						break;
					}
					else if (guess1 != letter1)
					{
						Console.WriteLine("Wrong word guess");
					}
				}

				catch
				{
					guess = input[0];
					if (correctGuesses.Contains(guess))

					{
						Console.WriteLine("You've already tried '{0}', and it was correct!", guess);
						continue;
					}
					else if (incorrectGuesses.Contains(guess))
					{
						Console.WriteLine("You've already tried '{0}', and it was wrong!", guess);
						continue;
					}

					else if (wordToGuessUppercase.Contains(guess))
					{
						correctGuesses.Add(guess);

						for (int i = 0; i < wordToGuess.Length; i++)
						{
							if (wordToGuessUppercase[i] == guess)
							{
								sb[i] = wordToGuess[i];
								lettersRevealed++;
							}
						}
						if (lettersRevealed == wordToGuess.Length)
							won = true;

					}
					else
					{
						incorrectGuesses.Add(guess);
						sb.Append(guess);
						Console.WriteLine("Wrong, there's no '{0}' in it!", guess);
						lives--;
					}

					Console.WriteLine(sb.ToString());
				}
			}

			if (won)
				Console.WriteLine("You won!");
			else
				Console.WriteLine("You lost! It was '{0}'", wordToGuess);

			Console.Write("Press ENTER to exit....");
			Console.ReadLine();


		}
	}
}