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
        public string[] Load(string path, bool authorFlag)
        {
            bool isIntName = false;
            bool isIntSecondname = false;
            int res;
            try
            {
                rawData = File.ReadAllText(path).Split('\n');
                if (authorFlag)
                {
                    isIntName = Int32.TryParse(rawData[0], out res);
                    isIntSecondname = Int32.TryParse(rawData[1], out res);
                }
            }
            catch (FileNotFoundException)
            {
                throw new Exception("File is missing!");
            }
            if (rawData.Length < 3)
            {
                throw new InvalidAuthorException("Lack of data! Some data may absent or written in one line");
            }
            if (isIntName || isIntSecondname)
            {
                throw new FormatException("Name/Secondname can't be a number!");
            }
            return rawData;
        }
    }
}
