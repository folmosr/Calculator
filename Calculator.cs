using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Calculator
{
    public static class Calculator
    {
        #region Private Fields

        private static readonly Regex Pattern = new Regex(@"^[\w\-. ]+$");
        private static readonly List<Resumen> Total = new List<Resumen>();

        #endregion Private Fields

        #region Private Methods

        /// <summary>
        /// Reads the file and set the task and total array
        /// </summary>
        /// <param name="path"></param>
        public static void ReadFile(string path)
        {
            if (File.Exists(path))
            {
                Resumen fileResumen = new Resumen
                {
                    FileName = Path.GetFileName(path)
                };

                string[] lines = File.ReadAllLines(path);

                foreach (string line in lines)
                {
                    if (int.TryParse(line, out int result))
                    {
                        fileResumen.AmountList.Add(result);
                    }
                    else if (Pattern.IsMatch(line))
                    {
                        var t = Task.Run(() => ReadFile(line));
                        t.Wait();
                    }
                }

                Total.Add(fileResumen);
            }
        }

        /// <summary>
        /// Shows resumen per file and global total
        /// </summary>
        public static void ShowTotals()
        {
            foreach (Resumen item in Total)
            {
                Console.WriteLine($" {item.FileName} total:");
                Console.WriteLine(item.AmountList.Sum());
            }
            Console.WriteLine("global total:");
            Console.WriteLine(Total.Select(x => x.AmountList.Sum()).Sum());
        }
    }

    #endregion Private Methods
}