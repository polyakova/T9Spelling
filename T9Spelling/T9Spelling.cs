using System.Collections.Generic;

namespace T9Spelling
{
	public class T9Spelling
	{
		private readonly IMessageInputProvider _input;
		private readonly IMessageOutputProvider _output;
		private readonly MessageToKeySequenceConverter _convertor;

		public T9Spelling(IMessageInputProvider input, IMessageOutputProvider output)
		{
			_input = input;
			_output = output;
			_convertor = new MessageToKeySequenceConverter();
		}

		public void Process()
		{
			var result = new List<string>();

			using (var stream = _input.GetStream())
			{
				var numberOfTests = int.Parse(stream.ReadLine());

				for(var i = 1; i <= numberOfTests; i++)
				{
					var numbers = _convertor.Convert(stream.ReadLine());			
					result.Add($"Case #{i}: {numbers}");
				}
			}

			_output.Save(result);
		}
	}
}