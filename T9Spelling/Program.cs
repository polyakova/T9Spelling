using System;

namespace T9Spelling
{
	class Program
	{
		static void Main(string[] args)
		{
			if (args.Length == 0)
				throw new ArgumentNullException("Input file is missing.");

			var input = new FileInputProvider(args[0]);
			var output = new FileOutputProvider(args.Length > 1 ? args[1] : "output.txt");

			new T9Spelling(input, output).Process();
		}
    }
}
