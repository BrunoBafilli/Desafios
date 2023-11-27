using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

class Program
{
	static void Main()
	{
		BenchmarkRunner.Run<Benchmark>();
	}
}

public class Benchmark
{
	private int[] vetNumeros = GerarVetorAleatorio(1000000000);

	[Benchmark]
	public void ON()
	{
		HashSet<int> hashSet = new HashSet<int>();
		int result = 0;

		foreach (var num in vetNumeros)
		{
			if (hashSet.Contains(num))
			{
				result = num;
				break;
			}
			hashSet.Add(num);
		}
	}

	[Benchmark]
	public void ON2()
	{
		int resultado = 0;
		bool stop = false;

		for (int i = 0; i < vetNumeros.Length; i++)
		{
			for (int t = i + 1; t < vetNumeros.Length; t++)
			{
				if (vetNumeros[i] == vetNumeros[t])
				{
					stop = true;
					resultado = vetNumeros[i];
					break;
				}
			}
			if (stop)
				break;
		}
	}

	[Benchmark]
	public void BenchmarkON()
	{
		ON();
	}

	[Benchmark]
	public void BenchmarkON2()
	{
		ON2();
	}

	private static int[] GerarVetorAleatorio(int tamanho)
	{
		Random random = new Random();
		int[] vetor = new int[tamanho];

		for (int i = 0; i < tamanho; i++)
		{
			vetor[i] = random.Next(1, 1000000000); // Altere os valores conforme necessário
		}

		return vetor;
	}
}