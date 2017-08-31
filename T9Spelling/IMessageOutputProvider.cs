using System.Collections.Generic;

namespace T9Spelling
{
	public interface IMessageOutputProvider
	{
		void Save(IEnumerable<string> result);
	}	
}