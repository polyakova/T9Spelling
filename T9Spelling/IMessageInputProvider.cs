using System.IO;

namespace T9Spelling
{	public interface IMessageInputProvider
	{
		StreamReader GetStream();
	}
}