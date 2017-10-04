using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetEnv;

namespace StratGatherer
{
    class Program
    {
        static void Main(string[] args)
        {
            Setup();
            Execute();            
        }

        private static void Setup()
        {
            DotNetEnv.Env.Load();
        }

        private static void Execute()
        {
            StatisticsCompiler.CompileStats();
        }
    }
}
