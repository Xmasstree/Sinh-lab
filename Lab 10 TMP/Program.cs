using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BenchmarkDotNet;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Characteristics;
using Microsoft.Diagnostics.Symbols;
using Microsoft.Diagnostics.Tracing.Parsers.Clr;
using BenchmarkDotNet.Running;

namespace Lab_10_TMP
{
    [MemoryDiagnoser]
    public class Program
    {
        public static Thread thread1, thread2, thread3;
        static Methods mt = new Methods();


        [Benchmark]
        public void t1b()
        {
            mt.MutexPrint("###");
        }

        [Benchmark]
        public void t2b()
        {
            mt.SemaphorePrint("$$$");
        }

        [Benchmark]
        public void t3b()
        {

            mt.SemaphoreSlimPrint("@@@");
        }

        [Benchmark]
        public void t4b()
        {

            mt.MonitorPrint("@@@");
        }

        [Benchmark]
        public void t5b()
        {

            mt.SpinlockPrint("@@@");
        }

        static void Main(string[] args)
        {
            //mt.Menu();
            //string ch = Console.ReadLine();

            //switch (ch)
            //{
            //    case "1":
            //        thread1 = new Thread(() => mt.MutexPrint("###"));
            //        thread2 = new Thread(() => mt.MutexPrint("$$$"));
            //        thread3 = new Thread(() => mt.MutexPrint("@@@"));
            //        break;
            //    case "2":
            //        thread1 = new Thread(() => mt.SemaphorePrint("###"));
            //        thread2 = new Thread(() => mt.SemaphorePrint("$$$"));
            //        thread3 = new Thread(() => mt.SemaphorePrint("@@@"));
            //        break;
            //    case "3":
            //        thread1 = new Thread(() => mt.SemaphoreSlimPrint("###"));
            //        thread2 = new Thread(() => mt.SemaphoreSlimPrint("$$$"));
            //        thread3 = new Thread(() => mt.SemaphoreSlimPrint("@@@"));
            //        break;
            //    case "4":
            //        thread1 = new Thread(() => mt.MonitorPrint("###"));
            //        thread2 = new Thread(() => mt.MonitorPrint("$$$"));
            //        thread3 = new Thread(() => mt.MonitorPrint("@@@"));
            //        break;
            //    case "5":
            //        thread1 = new Thread(() => mt.SpinlockPrint("###"));
            //        thread2 = new Thread(() => mt.SpinlockPrint("$$$"));
            //        thread3 = new Thread(() => mt.SpinlockPrint("@@@"));
            //        break;
            //    default:
            //        Console.WriteLine("Такой команды нет.");
            //        break;
            //}

            //Console.WriteLine("Для запуска потоков нажмите Enter");
            //Console.ReadLine();
            //mt.manualResetEvent.Set();
            //thread1.Start();
            //thread2.Start();
            //thread3.Start();
            BenchmarkRunner.Run<Program>();
        }
    }
}
