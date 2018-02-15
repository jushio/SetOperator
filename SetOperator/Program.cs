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
            if (args.Length != 3)
            {
                Console.WriteLine("SetOperator.exe @command @fileNameOfA @fileNameOfB");
                return;
            }
            string cmd = args[0];
            string fileNameA = args[1];
            string fileNameB = args[2];

            List<string> a = new List<string>();
            List<string> b = new List<string>();

            try
            {
                FileReadToList(fileNameA, ref a);
                FileReadToList(fileNameB, ref b);
            }
            catch
            {
                Console.WriteLine("Exception: " + fileNameA + "か" + fileNameB + "の読出しエラー");
                return;
            }

            try
            {
                IEnumerable<string> res = SetOperator.Do(cmd, a, b);
                StringBuilder sb = new StringBuilder();
                foreach (string i in res)
                    sb.Append(i + "\n");
                Console.Write(sb.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return;
            }
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
            using (
                System.IO.StreamReader file =
                   new System.IO.StreamReader(fileName))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    a.Add(line);
                }

            }
        }
    }
}
