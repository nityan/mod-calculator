using System;
using System.Numerics;

namespace ModCalculator
{
	class Program
	{
		static void Main(string[] args)
		{
			//Console.WriteLine("Enter a dividend:");
			//var dividend = long.Parse(Console.ReadLine());

			//Console.WriteLine("Enter a divisor:");
			//var divisor = long.Parse(Console.ReadLine());

			//var result = dividend - (dividend / divisor) * divisor;

			//Console.WriteLine($"The result of {dividend} mod {divisor} is: {result}");

			Console.WriteLine("Enter values for a, b, g, and p");

			var a = new BigInteger(int.Parse(Console.ReadLine()));
			var b = new BigInteger(int.Parse(Console.ReadLine()));
			var g = new BigInteger(int.Parse(Console.ReadLine()));
			var p  = new BigInteger(int.Parse(Console.ReadLine()));

			Calculate(a, b, g, p);

			Console.ReadKey();
		}

		private static void Calculate(BigInteger a, BigInteger b, BigInteger g, BigInteger p)
		{
			var alicePublicKey = BigInteger.ModPow(g, a, p);
			var bobPublicKey = BigInteger.ModPow(g, b, p);

			var bobSecretKey = BigInteger.ModPow(alicePublicKey, b, p);
			var aliceSecretKey = BigInteger.ModPow(bobPublicKey, a, p);

			Console.WriteLine($"g value: {g}");
			Console.WriteLine($"p value: {p}");
			Console.WriteLine($"Alice public key: {alicePublicKey}");
			Console.WriteLine($"Alice private key: {a}");
			Console.WriteLine($"Secret key as determined by Alice: {aliceSecretKey}");

			Console.WriteLine($"Bob public key: {bobPublicKey}");
			Console.WriteLine($"Bob private key: {b}");
			Console.WriteLine($"Secret key as determined by Bob: {bobSecretKey}");
		}
	}
}
