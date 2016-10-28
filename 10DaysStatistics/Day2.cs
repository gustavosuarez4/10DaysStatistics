using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _10DaysStatistics
{
	[TestClass]
	public class Day2
	{
		[TestMethod]
		public void Quartiles()
		{
			Console.ReadLine();
			var X = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
			Array.Sort(X);
			var size = 0;
			var skip = 0;

			if (X.Length%2 == 0)
			{
				size = X.Length/2;
				skip = size;
			}
			else
			{
				size = (int)Math.Floor(X.Length / 2.0);
				skip = (int)Math.Ceiling(X.Length / 2.0);
			}

			Console.WriteLine(Median(X.Take(size).ToArray()));
			Console.WriteLine(Median(X));
			Console.WriteLine(Median(X.Skip(skip).Take(size).ToArray()));
		}
		static int Median(int[] data)
		{
			var mid = data.Length/2;
			var length = data.Length;
			return length % 2 == 0 ? (data[mid] + data[mid - 1]) / 2 : data[mid];
		}

		[TestMethod]
		public void InterquartileRange()
		{
			Console.ReadLine();
			var X = "6 12 8 10 20 16".Split(' ').Select(int.Parse).ToArray();
			var F = "5 4 3 2 1 5".Split(' ').Select(int.Parse).ToArray();
			//9.0

			//var X = "10 40 30 50 20 10 40 30 50 20".Split(' ').Select(int.Parse).ToArray();
			//var F = "1 2 3 4 5 6 7 8 9 10".Split(' ').Select(int.Parse).ToArray();
			//20.0

			//var X = "10 40 30 50 20".Split(' ').Select(int.Parse).ToArray();
			//var F = "1 2 3 4 5".Split(' ').Select(int.Parse).ToArray();
			//30.0

			Array.Sort(X, F);
			
			var length = F.Sum();
			var q1 = 0;
			var q3 = 0;

			var half = (int)Math.Floor(length / 2.0);
			var quarter = (int)Math.Floor(half / 2.0);

			if (length % 4 == 0 || (length - 1) % 4 == 0)
			{
				q1 = (GetElementAt(quarter, X, F) + GetElementAt(quarter - 1, X, F))/2;
				q3 = (GetElementAt(length - quarter, X, F) + GetElementAt(length - quarter - 1, X, F))/2;
			}
			else if (half % 2 == 0)
			{
				q1 = GetElementAt(quarter, X, F);
				q3 = GetElementAt(length - quarter, X, F);
			}
			else
			{
				q1 = GetElementAt(quarter, X, F);
				q3 = GetElementAt(length - quarter - 1, X, F);
			}

			Console.WriteLine("{0:N1}", q3 - q1);
		}

		static int GetElementAt(int index, int[] X, int[] F)
		{
			var count = 0;
			var i = 0;
			for (; i < F.Length && index > count; i++)
			{
				count += F[i];
				if (index < count)
				{
					break;
				}
			}
			return X[i];
		}

		[TestMethod]
		public void StandardDeviation()
		{
			Console.ReadLine();
			var X = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
			var len = (double) X.Length;
			var mu = X.Sum()/len;
			var variance = X.Select(x => Math.Pow(x - mu, 2.0)).Aggregate((p, c) => p + c)/len;
			Console.WriteLine(Math.Sqrt(variance));
		}
	}
}
