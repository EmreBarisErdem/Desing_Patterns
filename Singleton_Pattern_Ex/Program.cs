
using System;
using System.Threading;

//if your application do not use threads 
public sealed class Singleton
{
	private Singleton() { }

	private static Singleton _instance;

	public static Singleton GetInstance()
	{
		if(_instance == null)
		{
			_instance = new Singleton();
		}
		return _instance;
	}


}


class Program
{

	static void Main()
	{
		#region Singleton
		//Singleton s1 = Singleton.GetInstance();
		//Singleton s2 = Singleton.GetInstance();

		//if (s1 == s2)
		//{
		//	Console.WriteLine("Singleton works");
		//}
		//else
		//{
		//	Console.WriteLine("Singleton failed");
		//}
		#endregion

		#region Singleton with Threads,


		Console.WriteLine(
				"{0}\n{1}\n\n{2}\n",
				"If you see the same value, then singleton was reused (yay!)",
				"If you see different values, then 2 singletons were created (booo!!)",
				"RESULT:"
			);

		Thread process1 = new Thread(() =>
		{
			SingletonWithThreads.TestSingleton("FOO");
		});
		Thread process2 = new Thread(() =>
		{
			SingletonWithThreads.TestSingleton("BAR");
		});

		process1.Start();
		process2.Start();

		process1.Join();
		process2.Join();


		#endregion
	}
}






//if your application uses threads 


public sealed class SingletonWithThreads
{
	private SingletonWithThreads() { }



	private static SingletonWithThreads _instance;



	private static readonly object _lock = new object();
	// We now have a lock object that will be used to synchronize threads
	// during first access to the Singleton.


	public string Value { get; set; } // to test the singleton work properly



	public static SingletonWithThreads GetInstance(string value)
	{
		// This conditional is needed to prevent threads stumbling over the
		// lock once the instance is ready.
		if (_instance == null)
		{
			// Now, imagine that the program has just been launched. Since
			// there's no Singleton instance yet, multiple threads can
			// simultaneously pass the previous conditional and reach this
			// point almost at the same time. The first of them will acquire
			// lock and will proceed further, while the rest will wait here.
			lock (_lock)
			{
				// The first thread to acquire the lock, reaches this
				// conditional, goes inside and creates the Singleton
				// instance. Once it leaves the lock block, a thread that
				// might have been waiting for the lock release may then
				// enter this section. But since the Singleton field is
				// already initialized, the thread won't create a new
				// object.
				if (_instance == null)
				{
					_instance = new SingletonWithThreads();
					_instance.Value = value;

				}
			}
		}
		return _instance;
	}

	public static void TestSingleton(string value)
	{
		SingletonWithThreads singleton = SingletonWithThreads.GetInstance(value);
		Console.WriteLine(singleton.Value);
	} // to test the singleton instance is actually one.

}




