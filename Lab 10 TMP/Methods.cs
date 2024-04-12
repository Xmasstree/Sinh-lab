using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Lab_10_TMP
{
    class Methods
    {
        public static Random random = new Random();
        public static Mutex mutex = new Mutex();
        public static Semaphore semaphore = new Semaphore(3, 3);
        public static SemaphoreSlim semaphoreSlim = new SemaphoreSlim(3);
        public static SpinLock spinLock = new SpinLock();
        public static object locker = new object();
        public ManualResetEvent manualResetEvent = new ManualResetEvent(false);


        public void MutexPrint(string sum)
        {
            //manualResetEvent.WaitOne();
            for (int i = 0; i < 500; i++)
            {
                //Thread.Sleep(random.Next(500));
                mutex.WaitOne();
                Console.WriteLine(sum);
                mutex.ReleaseMutex();
            }
        }

        public void SemaphorePrint(string sum)
        {
            //manualResetEvent.WaitOne();
            for (int i = 0; i < 500; i++)
            {
                //Thread.Sleep(random.Next(500));
                semaphore.WaitOne();
                Console.WriteLine(sum);
                semaphore.Release();
            }
        }

        public void SemaphoreSlimPrint(string sum)
        {
            //manualResetEvent.WaitOne();
            for (int i = 0; i < 500; i++)
            {
                //Thread.Sleep(random.Next(500));
                semaphoreSlim.Wait();
                Console.WriteLine(sum);
                semaphoreSlim.Release();
            }
        }

        public void MonitorPrint(string sum)
        {
            //manualResetEvent.WaitOne();
            Monitor.Enter(locker);
            for (int i = 0; i < 500; i++)
            {
                //Thread.Sleep(random.Next(500));
                Console.WriteLine(sum);
            }
            Monitor.Exit(locker);
        }

        public void SpinlockPrint(string sum)
        {
            //manualResetEvent.WaitOne();
            bool flag = false;

                spinLock.Enter(ref flag);
                for (int i = 0; i < 500; i++)
                {
                    //Thread.Sleep(random.Next(500));
                    Console.WriteLine(sum);
                }

                if (flag)
                {
                    spinLock.Exit();
                }
            
        }

        public void Menu()
        {
            Console.WriteLine("Введите");
            Console.WriteLine("1. Для использования мьютекса.");
            Console.WriteLine("2. Для использования семафора.");
            Console.WriteLine("3. Для использования семафорСлим.");
            Console.WriteLine("4. Для использования монитора.");
            Console.WriteLine("5. Для завершения спинлока.");
            Console.Write("Ввод: ");
        }
    }
}
