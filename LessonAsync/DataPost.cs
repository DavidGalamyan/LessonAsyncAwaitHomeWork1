using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonAsync
{
    static class DataPost
    {
        private readonly static string _file = "message.txt";
        public static void PostsWriteToFile(string[] posts)
        {
            File.WriteAllLinesAsync(_file, posts);
        }
    }
}
