using System.Collections.Generic;
using Sharpen;
using TheTravelingSalesman;

namespace TheTravelingSalesman.Solvers
{
	public class BranchBoundSolver<T> : ISolver<T>
	{
		private IProblem<T> problem;

		public BranchBoundSolver(IProblem<T> problem)
		{
			this.problem = problem;
		}

		public virtual IPath<T> Solve()
		{
			return CalculateShortestPath(problem);
		}

		public virtual IProblem<T> GetProblem()
		{
			return problem;
		}

		protected internal virtual IPath<T> CalculateShortestPath(IProblem<T> problem)
		{
			IList<int?> leftToVisit = new List<int?>();
			for (int i = 0; i < problem.GetLocationsCount(); i++)
			{
				leftToVisit.Add(i);
			}
			return CalculateShortestPath(problem, problem.CreatePath(), leftToVisit);
		}

		protected internal virtual IPath<T> CalculateShortestPath(IProblem<T> problem, IPath<T> startPath, IList<int?> leftToVisit)
		{
			IPath<T> bestPath = null;
			if (leftToVisit.Count == 1)
			{
				bestPath = startPath.To(leftToVisit[0].Value);
				problem.SetBestPath(bestPath);
			}
			else
			{
				IList<IPath<T>> nextPaths = new List<IPath<T>>();
				IPath<T> globalBestPath = problem.GetBestPath();
				foreach (int nextLocation in leftToVisit)
				{
					IPath<T> nextPath = startPath.To(nextLocation);
					if (nextPath.IsBetter(globalBestPath))
					{
						nextPaths.Add(nextPath);
					}
				}
				nextPaths.Sort();
				foreach (IPath<T> nextPath in nextPaths)
				{
					IList<int?> newLeftToVisit = new List<int?>(leftToVisit);
					int? nextLocation = nextPath.GetLast();
					newLeftToVisit.Remove(nextLocation);
					IPath<T> path = CalculateShortestPath(problem, nextPath, newLeftToVisit);
					if (path != null && (path.IsBetter(bestPath)))
					{
						bestPath = path;
					}
				}
			}
			return bestPath;
		}
	}
}
