// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


// Izrada metoda koje će se izvršavati u zasebnim dretvama
// Izrada koda koji pokreće zadatke u zasebnim dretvama
static void ThreadRun1()
{
    System.Diagnostics.Stopwatch sw = System.Diagnostics.Stopwatch.StartNew();
    {
        sw.Restart();
        Thread.Sleep(2000);
    }
}

Thread myThread = new Thread(ThreadRun1);
Thread myThread2 = new Thread(ThreadRun1);

myThread.Start();
myThread2.Start();


// Korištenje async i await
static async Task<int> Method1()
{
    int count = 0;
    await Task.Run(() =>
    {
        for (int i = 0; i < 100; i++)
        {
            Console.WriteLine(" Method 1");
            count += 1;
        }
    });
    return count;
}

var count = await Method1();


