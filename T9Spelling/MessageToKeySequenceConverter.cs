using System;
using System.Collections.Generic;
using System.Text;

namespace T9Spelling
{
	public class MessageToKeySequenceConverter
	{
		private static readonly string[] _keys = new string[] {" ", "", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" };
		
		private static readonly Dictionary<char, string> _mapping = new Dictionary<char, string>();

		static MessageToKeySequenceConverter()
		{
			for (var i = 0; i < _keys.Length; i++)
			{
				var key = _keys[i];

				for(var j = 0; j < key.Length; j++)
                    _mapping[key[j]] = new String(System.Convert.ToChar(i.ToString()), j + 1);
			}
		}

		public string Convert(string message)
		{
			var builder = new StringBuilder();
		
			for (var j = 0; j < message.Length; j++)
			{
				var current = Map(message[j]);

				if (j != 0)
				{
					var previous = Map(message[j - 1]);

					if (current[0] == previous[0])
						builder.Append(" ");
				}

				builder.Append(current);
			}

			return builder.ToString();			
		}

		private string Map(char character)
		{
			if (!_mapping.ContainsKey(character))
				throw new Exception("Invalid character.");

			return _mapping[character];
		}
	}
}