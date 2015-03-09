
using System.Linq;
using System.Threading.Tasks;
using System.Numerics;


namespace RainbowTableGenerator
{


    // http://stackoverflow.com/questions/18911262/parallel-calculation-of-biginteger-factorial
    // https://msdn.microsoft.com/en-us/magazine/cc163340.aspx
    // http://tipsandtricks.runicsoft.com/CSharp/ParallelClass.html
    class FactorialTest
    {


        public static BigInteger SingleFactorial(long x)
        {
            BigInteger res = x;
            x--;
            while (x > 1)
            {
                res *= x;
                x--;
            } // End while (x > 1)

            return res;
        } // End Function SingleFactorial


        /// <summary>
        /// The max number of parallel tasks
        /// </summary>
        static readonly int DegreeOfParallelism = System.Environment.ProcessorCount;

        // WTF ?
        public static BigInteger ParallelFactorial2(long x)
        {
            System.Collections.Generic.List<Task<BigInteger>> ls = new System.Collections.Generic.List<Task<BigInteger>>();
            int j = (1 + DegreeOfParallelism) ;

            for (int i = 1; i < j; ++i)
            {
                Task<BigInteger> tsk = Task.Factory.StartNew(() => Multiply(x, i), TaskCreationOptions.LongRunning);
                ls.Add(tsk);
            } // Next i 

            Task.WaitAll(ls.ToArray());

            BigInteger finalResult = 1;
            for (int i = 0; i < ls.Count; ++i)
            {
                finalResult *= ls[i].Result;
            } // Next i

            return finalResult;
        } // End Function ParallelFactorial2


        public static BigInteger ParallelFactorial(long x)
        {
            // Make as many parallel tasks as our DOP
            // And make them operate on separate subsets of data 
            Task<BigInteger>[] parallelTasks =
                Enumerable.Range(1, DegreeOfParallelism)
                            .Select(i => Task.Factory.StartNew(() => Multiply(x, i), TaskCreationOptions.LongRunning))
                            .ToArray();


            // after all tasks are done...
            Task.WaitAll(parallelTasks);

            // ... take the partial results and multiply them together
            BigInteger finalResult = 1;

            foreach (var partialResult in parallelTasks.Select(t => t.Result))
            {
                finalResult *= partialResult;
            } // Next partialResult 

            return finalResult;
        } // End Function ParallelFactorial


        /// <summary>
        /// Multiplies all the integers up to upperBound, with a step equal to DOP
        /// starting from a different int
        /// </summary>
        /// <param name="upperBoud"></param>
        /// <param name="startFrom"></param>
        /// <returns></returns>
        public static BigInteger Multiply(long upperBound, int startFrom)
        {
            BigInteger result = 1;

            for (var i = startFrom; i <= upperBound; i += DegreeOfParallelism)
                result *= i;

            return result;
        } // End Function Multiply


    } // End Class FactorialTest


} // End Namespace RainbowTableGenerator
