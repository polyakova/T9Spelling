using System;
using System.IO;

namespace T9Spelling
{
	public class FileInputProvider : IMessageInputProvider
	{
		private readonly string _path;
		
		public FileInputProvider(string path)
		{ 
			if (string.IsNullOrEmpty(path))
				throw new ArgumentException("Path is empty.");

			_path = path;
		}

		public StreamReader GetStream()
		{
			if (!File.Exists(_path))
				throw new FileNotFoundException("Specified file doesn't exist.");

			return File.OpenText(_path);
		}
	}
}