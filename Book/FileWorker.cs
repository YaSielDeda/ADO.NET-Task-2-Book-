using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using static Book.Exceptions;

namespace Book
{
    class FileWorker
    {
        string[] rawData;
        public string[] Load(string path)
        {
            try
            {
                rawData = File.ReadAllText(path).Split('\n');
            }
            catch (FileNotFoundException)
            {
                throw new Exception("File is missing!");
            }
            if (rawData.Length < 3)
            {
                throw new LackOfData("Lack of data! Some data may absent or written in one line");
            }
            return rawData;
        }
    }
}
