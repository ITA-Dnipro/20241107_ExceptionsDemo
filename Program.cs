using System.Diagnostics;

namespace _20241107_ExceptionsDemo
{
    internal class Program
    {
        const int ITERATIONS_COUNT = 500;

        static void Main(string[] args)
        {
            bool flagExit = false;

            do
            {
                try
                {
                    Console.Write("Enter x? ");
                    string s = Console.ReadLine();

                    Console.WriteLine("x^2: {0}", GetSQR(s));

                    flagExit = true;
                }
                //catch (Exception ex)
                //{
                //    Console.ForegroundColor = ConsoleColor.Green;
                //    Console.WriteLine("Exception: {0}", ex);

                //    Console.ForegroundColor = ConsoleColor.Magenta;
                //    Console.WriteLine("     InnerException: {0}", ex.InnerException);
                //}
                catch (FormatException ex)
                {
                    Console.WriteLine("Stack: {0}", ex.StackTrace);

                    Console.WriteLine("Wrong input... :(");

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Exception: {0}", ex);
                }
                catch (MyException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Exception: {0}", ex);
                    Console.WriteLine("Wrong input string: {0}", ex.InputString);
                }
               
            } while (!flagExit);


            #region without exceptions
            
            {
                Stopwatch sw = Stopwatch.StartNew();

                for (int i = 0; i < ITERATIONS_COUNT; i++)
                {
                    if (GetSQR("test", out int result))
                    {
                        Console.WriteLine($"result = {result}");
                    }
                }

                sw.Stop();

                Console.WriteLine("time without exceptions: {0}msec, {1}ticks", sw.ElapsedMilliseconds, sw.ElapsedTicks);
            }


            #endregion

            #region with exceptions

            {
                Stopwatch sw = Stopwatch.StartNew();

                for (int i = 0; i < ITERATIONS_COUNT; i++)
                {
                    try
                    {
                        int res = GetSQR("test");
                        Console.WriteLine("x^2: {0}", res);
                    }
                    catch (FormatException ex)
                    {

                        //Console.WriteLine("Wrong input... :(");
                    }
                }

                sw.Stop();

                Console.WriteLine("time with exceptions: {0}msec, {1}ticks", sw.ElapsedMilliseconds, sw.ElapsedTicks);
            }


            #endregion

            Console.Write("Press any key...");
        }

        //public static int GetSQR(string s)
        //{
        //    int x = int.Parse(s);

        //    return x * x;
        //}

        public static int GetSQR(string s)
        {
            try
            {
                int x = int.Parse(s);
                return x * x;
            }
            catch (FormatException ex)
            {
                throw new MyException("Wrong input... :(", ex, s);
            }                
        }

        public static bool GetSQR(string s, out int result)
        {
            bool ok = int.TryParse(s, out result);

            return ok;
        }

      //  public static 

    }


}