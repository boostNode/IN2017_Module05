/*
*  Author: Troy Davis
*  Project: Module05_Lesson01 - Console (examples: arrays, methods, switch statements, recursion, try-catch)
*  Class: IN 2017 (Advanced C#)
*  Date: Feb 22, 2017 
*  Revision: Original
*/

using System;
using System.IO;

namespace Module05_Lesson01
{
    class Program
    {
        static void Main(string[] args)
        {
            // greeting
            Console.WriteLine("Northwind Corporation - Lesson 01\n");


            // EXAMPLE 1: arrays (see Monitor Class and VideoResolution enum below)
            Console.WriteLine("EXAMPLE 1 - arrays\n");
            Monitor[] monitors = {
                new Monitor(VideoResolution.VGA),
                new Monitor(VideoResolution.SVGA),
                new Monitor(VideoResolution.HDTV_1080),
                new Monitor(VideoResolution.WUXGA)
            };
            // output max resolution for each monitor
            int index = 0;
            foreach(Monitor m in monitors)
            {
                Console.Write("\tMonitor {0} - ", index); m.OutputScreenSpecs();
                index++;
            }


            // EXAMPLE 2: methods (see OutputString() method below)
            Console.WriteLine("\nEXAMPLE 2 - methods\n");
            OutputString("Greetings Earthling! You have invoked my method.");


            // EXAMPLE 3: switch statement (see TestSwitch() & TestSwitchFallThrough() methods and Stoplight enum below)
            Console.WriteLine("\nEXAMPLE 3 - switch statements\n");
            TestSwitch(7, 7, '*');
            TestSwitchFallThrough();
            Stoplight s = Stoplight.Red;
            switch (s)
            {
                case Stoplight.Red:
                    Console.ForegroundColor = ConsoleColor.Red;
                    OutputString("Listen carefully Earthling, you must STOP right now!");
                    break;
                case Stoplight.Yellow:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    OutputString("Ok Earthling, be carefull - use CAUTION!");
                    break;
                case Stoplight.Green:
                    Console.ForegroundColor = ConsoleColor.Green;
                    OutputString("Earthling, you must GO, GO, GO!");
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    OutputString("Earthling, I am unsure what to advise!");
                    break;
            }
            Console.ForegroundColor = ConsoleColor.Gray;


            // EXAMPLE 4: recursion (see Factorial() and CharacterRepeater() methods below)
            Console.WriteLine("\nEXAMPLE 4 - recursion\n");
            Console.Write("\tThe value 7 factorial (7!) is equal to {0}\n", Factorial(7));
            Console.Write("\tRepeating the character '$' 7 times: "); CharacterRepeater('$', 7); Console.WriteLine("\n");


            // EXAMPLE 5: try-catch (see ExceptionTest() method below)
            Console.WriteLine("\nEXAMPLE 5 - try-catch\n");
            ExceptionTest();


            // wait on user to close console
            Console.Write("\nPress 'Enter' to exit: "); Console.ReadLine();
        }

        public static void OutputString(string s)
        {
            Console.WriteLine("\t" + s);
        }
        public static void TestSwitch(int op1, int op2, char opr)
        {
            int result;
            switch (opr)
            {
                case '+':
                    result = op1 + op2;
                    break;
                case '-':
                    result = op1 - op2;
                    break;
                case '*':
                    result = op1 * op2;
                    break;
                case '/':
                    result = op1 / op2;
                    break;
                default:
                    Console.WriteLine("Unknown Operator");
                    return;
            }
            Console.WriteLine("\t{0} {1} {2} = {3}", op1.ToString(), opr.ToString(), op2.ToString(), result);
            return;
        }
        public static void TestSwitchFallThrough()
        {
            DateTime dt = DateTime.Today;
            switch (dt.DayOfWeek)
            {
                case DayOfWeek.Monday:
                case DayOfWeek.Tuesday:
                case DayOfWeek.Wednesday:
                case DayOfWeek.Thursday:
                case DayOfWeek.Friday:
                    Console.WriteLine("\tToday is a weekday");
                    break;
                default:
                    Console.WriteLine("\tToday is a weekend day");
                    break;
            }
        }
        public static int Factorial(int n)
        {
            if (n == 0)
            {
                return 1; //base case
            }
            else
            {
                return n * Factorial(n - 1); //recursive case
            }
        }
        public static void CharacterRepeater(char c, int numbTimes)
        {
            if( numbTimes > 0 )
            {
                Console.Write(c.ToString());
                CharacterRepeater(c, --numbTimes);// recurse on self until numbTimes = 0 (note: must use pre versus post decrement operator)
            }
        }
        private static void ExceptionTest()
        {
            StreamReader sr = null;
            try
            {
                sr = File.OpenText(@"k:\data.txt");
                Console.WriteLine("\tExceptionTest: " + sr.ReadToEnd());
            }
            catch (FileNotFoundException fnfe)
            {
                Console.WriteLine("\tException 1: " + fnfe.Message);
            }
            catch (DirectoryNotFoundException dnfe)
            {
                Console.WriteLine("\tException 2: " + dnfe.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("\tException 3: " + ex.Message);
            }
        }
    }

    class Monitor
    {
        // constructor
        public Monitor(VideoResolution maxRes)
        {
            this.MaxResolution = maxRes;
        }
        public VideoResolution MaxResolution { get; set; }
        public void OutputScreenSpecs()
        {
            switch (this.MaxResolution)
            {
                case VideoResolution.CGA:
                    Console.WriteLine("Maximum Resolution = CGA: 320 x 200");
                    break;
                case VideoResolution.EGA:
                    Console.WriteLine("Maximum Resolution = EGA: 640 x 350");
                    break;
                case VideoResolution.VGA:
                    Console.WriteLine("Maximum Resolution = VGA: 640 x 480");
                    break;
                case VideoResolution.SVGA:
                    Console.WriteLine("Maximum Resolution = SVGA: 800 x 600");
                    break;
                case VideoResolution.HDTV_720:
                    Console.WriteLine("Maximum Resolution = HDTV (720i/p): 1280 x 720");
                    break;
                case VideoResolution.XGA:
                    Console.WriteLine("Maximum Resolution = XGA: 1024 x 768");
                    break;
                case VideoResolution.WXGA:
                    Console.WriteLine("Maximum Resolution = WXGA: 1366 x 768");
                    break;
                case VideoResolution.SXGA:
                    Console.WriteLine("Maximum Resolution = SXGA: 1280 x 1024");
                    break;
                case VideoResolution.HDTV_1080:
                    Console.WriteLine("Maximum Resolution = HDTV (1080i/p): 1920 x 1080");
                    break;
                case VideoResolution.UXGA:
                    Console.WriteLine("Maximum Resolution = UXGA: 1600 x 1200");
                    break;
                case VideoResolution.WUXGA:
                    Console.WriteLine("Maximum Resolution = WUXGA: 1920 x 1200");
                    break;
                default:
                    Console.WriteLine("Maximum Resolution = UNSPECIFIED");
                    break;
            }
        }
    }
    enum VideoResolution
    {
        CGA,
        EGA,
        VGA,
        SVGA,
        HDTV_720,
        XGA,
        WXGA,
        SXGA,
        HDTV_1080,
        UXGA,
        WUXGA
    }
    enum Stoplight { Red, Yellow, Green }
}