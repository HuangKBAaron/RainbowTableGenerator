
using System.Windows.Forms;


namespace RainbowTableGenerator
{


    static class Program
    {


        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [System.STAThread]
        static void Main()
        {
#if true
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            return;
#endif
            long num = 100000;

            System.Diagnostics.Stopwatch s = System.Diagnostics.Stopwatch.StartNew();
            System.Numerics.BigInteger x = FactorialTest.SingleFactorial(num);
            s.Stop();
            // System.Console.WriteLine(x);
            System.Console.WriteLine("Elapsed Time (S): {0} ms", s.ElapsedMilliseconds);



            System.Diagnostics.Stopwatch t = System.Diagnostics.Stopwatch.StartNew();
            System.Numerics.BigInteger y = FactorialTest.ParallelFactorial(num);
            t.Stop();
            System.Console.WriteLine("Elapsed Time (P): {0} ms", t.ElapsedMilliseconds);
            System.Console.WriteLine(x == y);


            System.Diagnostics.Stopwatch u = System.Diagnostics.Stopwatch.StartNew();
            System.Numerics.BigInteger z = FactorialTest.ParallelFactorial2(num);
            u.Stop();
            System.Console.WriteLine("Elapsed Time (P2): {0} ms", u.ElapsedMilliseconds);
            System.Console.WriteLine(x == z);


            System.Console.WriteLine(System.Environment.NewLine);
            System.Console.WriteLine(" --- Press any key to continue --- ");
            System.Console.ReadKey();
        } // End Sub Main 


    } // End Class Program 


} // End Namespace RainbowTableGenerator 
