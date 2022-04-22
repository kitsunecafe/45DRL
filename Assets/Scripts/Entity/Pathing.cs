using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// https://gist.github.com/ryancollingwood/32446307e976a11a1185a5394d6657bc
namespace JuniperJackal.Entity
{
	public class Pathing
	{
		public class Node : IComparable<Node>, IEquatable<Node>
		{
			public readonly Node Parent;
			public readonly Vector2Int Position;
			public readonly int Cost;
			public readonly int Heuristic;
			public readonly int TotalCost;

			public Node(Vector2Int position)
			{
				Position = position;
				Parent = null;

				Cost = 0;
				Heuristic = 0;
				TotalCost = 0;
			}

			public Node(Vector2Int position, Node parent, Vector2Int goal) : this(position)
			{
				Parent = parent;
				Cost = parent.Cost + 1;
				Heuristic = CalculateHeuristic(position, goal);
				TotalCost = Cost + Heuristic;
			}

			private static int CalculateHeuristic(Vector2Int position, Vector2Int goal)
			{
				return Pow(position.x - goal.x, 2) + Pow(position.y - goal.y, 2);
			}

			public int CompareTo(Node other)
			{
				return TotalCost.CompareTo(other.TotalCost);
			}

			public bool Equals(Node other)
			{
				return Position == other.Position;
			}

			private static int Pow(int n, int e)
			{
				return (int)Math.Pow(n, e);
			}
		}

		private static readonly Vector2Int[] AdjacentPositions = new Vector2Int[]
		{
		Vector2Int.down,
			Vector2Int.up,
			Vector2Int.left,
			Vector2Int.right,
			new Vector2Int(-1, -1),
			new Vector2Int(-1,  1),
			new Vector2Int(1,  -1),
			new Vector2Int(1,   1)
		};

		public IEnumerable<Vector2Int> Find(ICellGrid grid, Vector2Int start, Vector2Int end) => Find(grid, start, end, true);
		public IEnumerable<Vector2Int> Find(ICellGrid grid, Vector2Int start, Vector2Int end, bool allowDiagonalMovement)
		{
			var startNode = new Node(start);
			var endNode = new Node(end);

			var open = new SortedSet<Node>();
			var closed = new HashSet<Vector2Int>();

			Push(open, startNode);

			var iterations = 0;
			var maxIterations = grid.xDim * grid.yDim / 2;

			var adjacentPositions = AllAdjacentPositions(allowDiagonalMovement);

			while (open.Any())
			{
				iterations += 1;

				var currentNode = Pop(open);

				if (iterations > maxIterations || currentNode.Equals(endNode))
				{
					return BacktrackPath(currentNode);
				}

				closed.Add(currentNode.Position);

				var children = GetAdjacentPositions(currentNode, adjacentPositions, grid)
					.Except(closed)
					.Select(p => new Node(p, currentNode, end))
					.Except(open);

				foreach (var child in children)
				{
					Push(open, child);
				}
			}

			return Enumerable.Empty<Vector2Int>();
		}

		private IEnumerable<Vector2Int> GetAdjacentPositions(Node node, ArraySegment<Vector2Int> adjacentPositions, ICellGrid grid)
		{
			for (int i = 0; i < adjacentPositions.Count; i++)
			{
				var position = node.Position + adjacentPositions[i];

				if (position.x > grid.xDim - 1 || position.x < 0 || position.y > grid.yDim || position.y < 0)
				{
					continue;
				}

				if (grid.IsWall(position.x, position.y))
				{
					continue;
				}

				yield return position;
			}
		}

		private List<Vector2Int> BacktrackPath(Node node)
		{
			var path = new List<Vector2Int>();
			var current = node;

			while (current != null)
			{
				path.Add(current.Position);
				current = current.Parent;
			}

			path.Reverse();
			return path;
		}

		private ArraySegment<Vector2Int> AllAdjacentPositions(bool allowDiagonalMovement)
		{
			return allowDiagonalMovement ? AdjacentPositions : new ArraySegment<Vector2Int>(AdjacentPositions, 0, 4);
		}

		private void Push(SortedSet<Node> set, Node element)
		{
			set.Add(element);
		}

		private Node Pop(SortedSet<Node> set)
		{
			var element = set.Min();
			set.Remove(element);
			return element;
		}
	}
}
