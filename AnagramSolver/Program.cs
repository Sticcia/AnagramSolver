using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AnagramSolver
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Opening dictionaries...");

			List<string> dictionary = new List<string>(File.ReadAllLines(@"..\..\paroleitaliane\1000_parole_italiane_comuni.txt"));

			Console.WriteLine("Insert input:");

			var input = Console.ReadLine().Replace(" ", string.Empty);
			Console.WriteLine(input);

			foreach (var item in Permute(input, 0, input.Length - 1))
			{
				//Console.WriteLine(item);
				string word = "";

				for (int i = 0; i < item.Length; i++)
				{
					word += item[i];

					if (dictionary.Contains(word))
					{
						Console.WriteLine("Possible word found: " + word);
						dictionary.Remove(word);
					}
				}
			}
			

			Console.WriteLine("Press any key to close:");
			Console.ReadLine();
		}

		private static IEnumerable<string> Permute(string str, int l, int r)
		{
			if (l == r)
			{
				yield return str;
			}
			else
			{
				for (int i = l; i <= r; i++)
				{
					str = Swap(str, l, i);
					foreach(string s in Permute(str, l + 1, r))
					{
						yield return s;
					}
					str = Swap(str, l, i);
				}
			}
		}

		private static string Swap(string str, int i, int j)
		{
			char tmp;
			char[] charArray = str.ToCharArray();
			tmp = charArray[i];
			charArray[i] = charArray[j];
			charArray[j] = tmp;
			string s = new string(charArray);
			return s;
		}
	}
}
