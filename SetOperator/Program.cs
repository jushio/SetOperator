using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetOperator
{
    class Program
    {
        static void Main(string[] args)
        {
            string dataDir = @"./dat";
            string[] files = System.IO.Directory.GetFiles(
                dataDir, "*", System.IO.SearchOption.AllDirectories);
            if (files.Count() != 2)
                throw new Exception();

            List<string> a = new List<string>();
            List<string> b = new List<string>();

            FileReadToList(files[0], ref a);
            FileReadToList(files[1], ref b);

            IEnumerable<string> seki = a.Intersect(b);

            WriteAll<string>("res.txt", seki, s => s);
        }

        public static void Write(string path, string contents, bool append = false)
        {
            using (StreamWriter w = new StreamWriter(path, append))
            {
                w.Write(contents);
            }
        }

        public static void WriteAll<T>(string filepath, IEnumerable<T> ienu, Func<T, string> getName)
        {
            StringBuilder sb = new StringBuilder();
            foreach (T i in ienu)
                sb.Append(getName(i) + "\n");
            Write(filepath, sb.ToString(), true);
        }

        static void FileReadToList(string fileName, ref List<string> a)
        {
            System.IO.StreamReader file =
               new System.IO.StreamReader(fileName);
            string line;
            var delims = new char[] { '/', '_' };
            while ((line = file.ReadLine()) != null)
            {
                a.Add(line);
            }
        }
    }
}
