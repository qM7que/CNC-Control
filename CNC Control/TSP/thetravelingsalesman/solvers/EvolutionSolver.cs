using System;
using System.Collections.Generic;
using Sharpen;
using TheTravelingSalesman;

namespace TheTravelingSalesman.Solvers
{
	public class EvolutionSolver<T> : ISolver<T>
	{
		private IProblem<T> problem;

		private IList<IPath<T>> population = new List<IPath<T>>();

		private Random random = new Random();

		private int populationCount = 500;

		private int generationCount = 1000;

		private int eliteCount = 250;

		private int eliteDescendendCount = 25;

		private int mutatePercent = 15;

		private int maxNoImprovement = 1000;

		private int noImprovement = 0;

		public EvolutionSolver(IProblem<T> problem)
		{
			this.problem = problem;
		}

		public virtual IPath<T> Solve()
		{
			//Path result = createRandom();
			IPath<T> result = CreateNearest();
			for (int i = 0; i < 10; i++)
			{
				population.Add(result);
			}
			for (int i = 0; i < populationCount - 10; i++)
			{
				population.Add(CreateRandom());
			}
			for (int generation = 0; generation < generationCount; generation++)
			{
				IList<IPath<T>> descendants = new List<IPath<T>>();
				population.Sort();
				for (int i = 0; i < eliteCount; i++)
				{
					IPath<T> elite = population[i];
					for (int j = 0; j < eliteDescendendCount; j++)
					{
						IPath<T> descendant = Evolve(elite);
						if (random.Next(100) < mutatePercent)
						{
							descendant = Mutate(descendant);
						}
						descendants.Add(descendant);
					}
				}
				problem.CalculateLengths(descendants);
				Sharpen.Collections.AddAll(population, descendants);
				population.Sort();
				while (population.Count > populationCount)
				{
					population.GetAndRemove(population.Count - 1);
				}
				IPath<T> best = population[0];
				if (best.IsBetter(result))
				{
					result = best;
					problem.SetBestPath(best);
				}
				else
				{
					noImprovement++;
					if (noImprovement >= maxNoImprovement)
					{
						System.Console.Out.WriteLine("kill no imporvment");
						break;
					}
				}
			}
			return result;
		}

		private IPath<T> Evolve(IPath<T> path)
		{
			int[] locations = path.GetLocations();
			int[] result = Sharpen.Arrays.CopyOf(locations, locations.Length);
			int from = random.Next(locations.Length - 1);
			Exchange(result, from, from + 1);
			return problem.CreatePath(result);
		}

		private IPath<T> Mutate(IPath<T> path)
		{
			int[] locations = path.GetLocations();
			int[] result = Sharpen.Arrays.CopyOf(locations, locations.Length);
			int from = random.Next(locations.Length);
			int to = random.Next(locations.Length);
			Exchange(result, from, to);
			return problem.CreatePath(result);
		}

		private IPath<T> CreateRandom()
		{
			int[] result = new int[problem.GetLocationsCount()];
			IList<int?> locations = new List<int?>();
			for (int i = 0; i < problem.GetLocationsCount(); i++)
			{
				locations.Add(i);
			}
			for (int i = 0; i < result.Length; i++)
			{
				int l = random.Next(locations.Count);
				result[i] = locations.GetAndRemove(l).Value;
			}
			return problem.CreatePath(result);
		}

		private IPath<T> CreateNearest()
		{
			IPath<T> result = problem.CreatePath();
			for (int j = 0; j < problem.GetLocationsCount(); j++)
			{
				IList<IPath<T>> neighbors = new List<IPath<T>>();
				for (int i = 0; i < problem.GetLocationsCount(); i++)
				{
					if (!result.Contains(i))
					{
						neighbors.Add(result.To(i));
					}
				}
				problem.CalculateLengths(neighbors);
				neighbors.Sort();
				result = neighbors[0];
			}
			return result;
		}

		private void Exchange(int[] result, int from, int to)
		{
			int temp = result[from];
			result[from] = result[to];
			result[to] = temp;
		}

		public virtual IProblem<T> GetProblem()
		{
			return problem;
		}

		public override string ToString()
		{
			return "EvolutionSolver [populationCount=" + populationCount + ", generationCount=" + generationCount + ", eliteCount=" + eliteCount + ", eliteDescendendCount=" + eliteDescendendCount + ", mutatePercent=" + mutatePercent + "]";
		}
	}
}
