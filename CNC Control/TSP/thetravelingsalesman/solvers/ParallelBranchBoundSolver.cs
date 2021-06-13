using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Sharpen;
using Sharpen.Concurrent;
using TheTravelingSalesman;

namespace TheTravelingSalesman.Solvers
{
	public class ParallelBranchBoundSolver<T> : ISolver<T>
	{
		private IProblem<T> problem;

		private ThreadPoolExecutor pool;

		private volatile IPath<T> bestPath;

		private int threadCount;

		public ParallelBranchBoundSolver(IProblem<T> problem)
			: this(problem, Runtime.GetRuntime().AvailableProcessors() + 1)
		{
		}

		public ParallelBranchBoundSolver(IProblem<T> problem, int threadCount)
		{
			this.problem = problem;
			this.threadCount = threadCount;
			this.pool = new ThreadPoolExecutor(threadCount, threadCount, 5000, TimeUnit.Milliseconds);
		}

		public virtual IPath<T> Solve()
		{
			pool.Submit(() => CalculateShortestPath(problem));
			while (pool.GetTaskCount() != pool.GetCompletedTaskCount())
			{
				try
				{
					System.Threading.Thread.Sleep(200);
				}
				catch (Exception)
				{
				}
			}
			pool.Shutdown();
			try
			{
				pool.AwaitTermination(500, TimeUnit.Milliseconds);
			}
			catch (Exception)
			{
			}
			return bestPath;
		}

		public IProblem<T> GetProblem()
		{
			return problem;
		}

		protected internal void CalculateShortestPath(IProblem<T> problem)
		{
			IList<int> leftToVisit = new List<int>();
			for (int i = 0; i < problem.GetLocationsCount(); i++)
			{
				leftToVisit.Add(i);
			}
			CalculateShortestPath(problem, problem.CreatePath(), leftToVisit);
		}

		protected internal void CalculateShortestPath(IProblem<T> problem, IPath<T> startPath, IList<int> leftToVisit)
		{
			if (leftToVisit.Count == 1)
			{
				IPath<T> path = startPath.To(leftToVisit[0]);
				SetBestPath(path);
			}
			else
			{
				IList<IPath<T>> nextPaths = new List<IPath<T>>();
				IPath<T> globalBestPath = problem.GetBestPath();
				foreach (int? nextLocation in leftToVisit)
				{
					IPath<T> nextPath = startPath.To(nextLocation.Value);
					//if (globalBestPath == null || nextPath.getLength() < globalBestPath.getLength()) {
					if (nextPath.IsBetter(globalBestPath))
					{
						nextPaths.Add(nextPath);
					}
				}
				problem.CalculateLengths(nextPaths);
				nextPaths.Sort();
				if ((pool.GetTaskCount() - pool.GetCompletedTaskCount()) <= threadCount && problem.GetLocationsCount() - startPath.GetLocationsCount() > 12)
				{
					foreach (IPath<T> nextPath in nextPaths)
					{
						IList<int> newLeftToVisit = new List<int>(leftToVisit);
						int nextLocation = nextPath.GetLast();
						newLeftToVisit.Remove(nextLocation);
						pool.Submit(() => CalculateShortestPath(problem, nextPath, newLeftToVisit));
					}
				}
				else
				{
					foreach (IPath<T> nextPath in nextPaths)
					{
						IList<int> newLeftToVisit = new List<int>(leftToVisit);
						int nextLocation = nextPath.GetLast();
						newLeftToVisit.Remove(nextLocation);
						CalculateShortestPath(problem, nextPath, newLeftToVisit);
					}
				}
			}
		}

		protected internal void SetBestPath(IPath<T> path)
		{
			lock (this)
			{
				if (path != null && path.IsBetter(bestPath))
				{
					bestPath = path;
					problem.SetBestPath(path);
				}
			}
		}

		public override string ToString()
		{
			return "ParallelBranchBoundSolver [threadCount=" + threadCount + "]";
		}
	}
}
