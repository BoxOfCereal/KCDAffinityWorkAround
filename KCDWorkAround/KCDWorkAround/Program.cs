using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //get an array of the processes by the executable name
            //uses "friendly" name eg drop the .exe
            Process[] process = Process.GetProcessesByName("KingdomCome");
            //if nothing is returned the process can't be found
            if (process.Length == 0)
            {
                Console.WriteLine("Can't find it bro.\n");
            }
            Console.WriteLine(process[0].ToString());
            //just double checking if I've got anything
            Console.WriteLine("Process length :{0}", process.Length);

            Program program = new Program();
            //getCpu info test
            //program.GetCpuInfo();
            program.ChangeProcessAffinity("KingdomCome");
            //program.GetMaxedCpu();

            //program.GetPerformanceCategories();
            Environment.Exit(0);
        }

        public void GetCpuInfo()
        {
            Console.WriteLine("BEGIN CPU INFO");
            Console.WriteLine("Total # of processors: {0}", Environment.ProcessorCount);
            //Console.WriteLine("Current processor affinity: {0}", Process.GetCurrentProcess().ProcessorAffinity);
            Console.WriteLine("Current processor affinity: {0}", Process.GetProcessesByName("KingdomCome")[0].ProcessorAffinity);
            Console.WriteLine("*********************************");

            Console.WriteLine("Insert your selected processors, separated by comma (first CPU index is 1):");
            var input = Console.ReadLine();
            Console.WriteLine("*********************************");
            var usedProcessors = input.Split(',');

            //TODO: validate input
            int newAffinity = 0;
            foreach (var item in usedProcessors)
            {
                newAffinity = newAffinity | int.Parse(item);
                Console.WriteLine("Processor #{0} was selected for affinity.", item);
            }
            Process.GetProcessesByName("KingdomCome")[0].ProcessorAffinity = (System.IntPtr)newAffinity;
            Console.WriteLine("*********************************");
            Console.WriteLine("Current processor affinity is {0}", Process.GetProcessesByName("KingdomCome")[0].ProcessorAffinity);

            return;
        }

        //getting worked on
        public void ChangeProcessAffinity(string processName)
        {
            int numOfProcessors = Environment.ProcessorCount;
            Console.WriteLine("BEGIN CPU INFO");
            Console.WriteLine("Total # of processors: {0}", numOfProcessors);
            //Console.WriteLine("Current processor affinity: {0}", Process.GetCurrentProcess().ProcessorAffinity);
            Console.WriteLine("Current processor affinity: {0}", Process.GetProcessesByName(processName)[0].ProcessorAffinity);
            Console.WriteLine("*********************************");

            Console.WriteLine("Insert your selected processors, separated by comma (first CPU index is 1):");
            //I wanted to make it easy for people to just double click and run it, otherwise you can manually enter in the cpus
            //var input = Console.ReadLine();
            var input = "1";
            Console.WriteLine("*********************************");
            var usedProcessors = input.Split(',');

            //TODO: validate input
            int newAffinity = 0;
            foreach (var item in usedProcessors)
            {
                newAffinity = newAffinity | int.Parse(item);
                Console.WriteLine("newAffinity = {0}", newAffinity);
                Console.WriteLine("Processor #{0} was selected for affinity.", item);
            }
            Process.GetProcessesByName(processName)[0].ProcessorAffinity = (System.IntPtr)newAffinity;
            Console.WriteLine("*********************************");
            Console.WriteLine("Current processor affinity is {0}", Process.GetProcessesByName(processName)[0].ProcessorAffinity);
            Console.WriteLine("Resetting Processor Affinities: ");

            //FIXME This needs to reset the affinities back to default I can't figure out how or if there is a built in method to do this
            //for (int i = 0;i< numOfProcessors; i++)
            //{
            //     
            //}
            newAffinity = Convert.ToInt16(Math.Pow(2.00,numOfProcessors) - 1);
            Process.GetProcessesByName(processName)[0].ProcessorAffinity = (System.IntPtr)newAffinity;
            Console.WriteLine("Current processor affinity is {0}", Process.GetProcessesByName(processName)[0].ProcessorAffinity);


            return;
        }

        //TODO find max cpu
        public int GetMaxedCpu()
        {
            int numOfProcessors = Environment.ProcessorCount;

            PerformanceCounter cpuCounter;



            //FIXME I need to find the correct category, first argument
            cpuCounter = new PerformanceCounter("Processor", "% Processer Time", "_Total");
            //cpuCounter1 = new PerformanceCounter("Processor", "% Processer Time", "0");

            //always starts at 0
            dynamic firstValue = cpuCounter.NextValue();

            //matches task manager reading
            System.Threading.Thread.Sleep(1000);

            dynamic secondValue = cpuCounter.NextValue();

            Console.WriteLine("Current CPU percentage :{0}% ", secondValue);
            //TODO return the core with the highest shit
            return 0;
        }

        //gets a list of performance categories for use with PerformanceCounter class
        public string[] GetPerformanceCategories()
        {
            string machineName = Environment.MachineName;
            PerformanceCounterCategory[] categories;

            //generate a list of categories registered on specified computer
            try
            {
                Console.WriteLine("These categories are registered on " + (machineName.Length > 0 ? "computer \"{0}\":" : "this computer:"), machineName);
                categories = PerformanceCounterCategory.GetCategories();

                string[] categoryNames = new string[categories.Length];
                int objX;
                for (objX = 0; objX < categories.Length; objX++)
                {
                    categoryNames[objX] = categories[objX].CategoryName;
                }

                Array.Sort(categoryNames);
                for (objX = 0; objX < categories.Length; objX++)
                {
                    //Console.WriteLine("{0-4} - {1}", objX + 1, categoryNames[objX]);
                    Console.WriteLine(categoryNames[objX]);
                }

                return categoryNames;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to get categories on " +
                    (machineName.Length > 0 ? "computer \"{0}\":" : "this computer:"), machineName);
                Console.WriteLine(ex.Message);
            }


            return new string[1];
            //create and sort an array of category names


        }
    }
}
