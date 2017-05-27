using System;
using System.Collections.Generic;
namespace Task3ITechArt
{
	class Program
	{
		static void Main()
		{
			try
			{
				var res = MyFunctions.CountChange(4, new long[] { 1, 2 });
				Console.WriteLine("countChange(4, [1,2]) = " + res);
				res = MyFunctions.CountChange(10, new long[] { 5, 2, 3 });
				Console.WriteLine("countChange(10, [5,2,3]) = " + res);
				res = MyFunctions.CountChange(11, new long[] { 5, 7 });
				Console.WriteLine("countChange(11, [5,7]) = " + res);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
			Console.ReadLine();
		}
	}
	public static class MyFunctions
	{
		private static long[] GetCopy(long[] list)
		{
			if (list == null)
			{
				Console.WriteLine("Author given null as array - it is a wrong input value");
				throw new Exception("Error in GetCopy method (Author error)");
			}
			var res = new long[list.Length];
			for (long i = 0; i < list.Length; i++) res[i] = list[i];
			return res;
		}
		public static long CountChange(long sum, long[] moneys)
		{
			return CountChangeArray(sum, moneys).Count;
		}
		private static List<long[]> CountChangeArray(long sum, long[] moneys)
		{
			if (moneys == null)
			{
				Console.WriteLine("Tester given null as array - it is a wrong input value");
				throw new Exception("Error in CountChange method (Tester error)");
			}
			Moneys = moneys;
			Solutions = new List<long[]>();
			CountChangeRecursion(new long[Moneys.Length], sum, 0);
			return Solutions;
		}
		private static long[] Moneys { get; set; }
		private static List<long[]> Solutions { get; set; }
		private static void CountChangeRecursion(long[] curSolution, long sumMore, long number)
		{
			for (long i = 0; i <= sumMore / Moneys[number]; i++)
			{
				var buffersumMore = sumMore - i * Moneys[number];

				if (buffersumMore < 0) return;
				if (buffersumMore == 0)
				{
					var res = GetCopy(curSolution);
					res[number] = i;
					Solutions.Add(res);
				}
				if (buffersumMore > 0 && number + 1 < Moneys.Length)
				{
					var res = GetCopy(curSolution);
					res[number] = i;
					CountChangeRecursion(res, buffersumMore, number + 1);
				}
			}
		}
	}
}