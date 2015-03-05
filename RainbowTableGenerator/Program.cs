using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RainbowTableGenerator
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
#if false
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
#endif
            long num = 100000;

            System.Diagnostics.Stopwatch s = System.Diagnostics.Stopwatch.StartNew();
            System.Numerics.BigInteger x = FactorialTest.SingleFactorial(num);
            s.Stop();
            // System.Console.WriteLine(x);
            Console.WriteLine("Elapsed Time (S): {0} ms", s.ElapsedMilliseconds);



            System.Diagnostics.Stopwatch t = System.Diagnostics.Stopwatch.StartNew();
            System.Numerics.BigInteger y = FactorialTest.ParallelFactorial(num);
            t.Stop();
            Console.WriteLine("Elapsed Time (P): {0} ms", t.ElapsedMilliseconds);
            System.Console.WriteLine(x == y);


            System.Diagnostics.Stopwatch u = System.Diagnostics.Stopwatch.StartNew();
            System.Numerics.BigInteger z = FactorialTest.ParallelFactorial2(num);
            u.Stop();
            Console.WriteLine("Elapsed Time (P2): {0} ms", u.ElapsedMilliseconds);
            System.Console.WriteLine(x == z);


            System.Console.WriteLine(System.Environment.NewLine);
            System.Console.WriteLine(" --- Press any key to continue --- ");
            System.Console.ReadKey();
        }
    }
}
