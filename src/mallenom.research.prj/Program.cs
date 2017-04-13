using System;

using Mallenom.Research.A;
using Mallenom.Research.B;

namespace Mallenom.Research
{
	static class Program
	{
		public static void Main()
		{
			var a = new ClassA();
			var b = new ClassB();

			Console.WriteLine($"A: {typeof(ClassA).Assembly.FullName}");
			Console.WriteLine($"B: {typeof(ClassB).Assembly.FullName}");

		}
	}
}
