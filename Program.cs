using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Calculator
{
    internal class Program
    {
        #region Private Methods

        private static void Main(string[] args)
        {
            try
            {
                Calculator.ReadFile(args[0]);
                Calculator.ShowTotals();
            }
            catch (Exception e)
            {
                Console.WriteLine("An error has been thrown:");
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }

        #endregion Private Methods
    }
}