using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalculator
{
    /// <summary>
    /// A basic Program class that contains the Main method.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Main is the starting point of the program.  It creates a
        /// single instance of the TaxCalculatorTestDriver class and
        /// call its Run method.
        /// </summary>
        /// 
        /// <param name="args">Passed in arguments for the Main method.</param>
        static void Main(string[] args)
        {
            TaxCalculatorTestDriver driver = new TaxCalculatorTestDriver();
            driver.Run();
        }
    }
}
