using System.Collections.Generic;
using System.IO;

namespace T9Spelling
{
    public class FileOutputProvider: IMessageOutputProvider
    {
        private readonly string _path;

        public FileOutputProvider(string path)
        {
            _path = path;
        }

        public void Save(IEnumerable<string> result)
        {
			File.WriteAllLines(_path, result);
		}
    }
}