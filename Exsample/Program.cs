using Example;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Exsample
{
    public class Graph
    {
        private readonly Dictionary<int, List<int>> adjacencyList;

        public Graph(Dictionary<int, List<int>> adjList)
        {
            adjacencyList = adjList;
        }


        public int CountVertices() => adjacencyList.Count;

        public List<int> GetNeighbors(int vertex)
        {
            return adjacencyList.ContainsKey(vertex) ? adjacencyList[vertex] : new List<int>();
        }

        public List<int> GetVertices() => adjacencyList.Keys.ToList();
    }

    public interface IGraphColoring
    {
        Dictionary<int, int> ColorGraph(Graph graph);
        int GetOperationsCount();
    }

    public class GreedyColoring : IGraphColoring
    {
        private int operationsCount;
        private int numColors;

        public GreedyColoring(int numColors)
        {
            this.numColors = numColors;
        }

        public Dictionary<int, int> ColorGraph(Graph graph)
        {
            operationsCount = 0;
            Dictionary<int, int> colors = new Dictionary<int, int>();

            foreach (var vertex in graph.GetVertices())
            {
                if (!colors.ContainsKey(vertex))
                {
                    HashSet<int> usedColors = new HashSet<int>();

                    foreach (var neighbor in graph.GetNeighbors(vertex))
                    {
                        operationsCount++;
                        if (colors.ContainsKey(neighbor))
                        {
                            usedColors.Add(colors[neighbor]);
                        }
                    }

                    int color = 0;
                    while (usedColors.Contains(color))
                    {
                        operationsCount++;
                        color++;
                    }

                    if (color >= numColors)
                    {
                        return null;
                    }

                    colors[vertex] = color;
                }
            }

            return colors;
        }

        public int GetOperationsCount()
        {
            return operationsCount;
        }
    }

    public class MRVColoring : IGraphColoring
    {
        private Dictionary<int, int> colors;
        private int operationsCount;
        private int numColors;

        public MRVColoring(int numColors)
        {
            this.numColors = numColors;
        }

        public Dictionary<int, int> ColorGraph(Graph graph)
        {
            colors = new Dictionary<int, int>();
            operationsCount = 0;

            if (!Backtrack(graph))
            {
                return null;
            }

            return colors;
        }

        private int MRVNode(Graph graph)
        {
            operationsCount++;
            return graph.GetVertices().Where(node => !colors.ContainsKey(node)).OrderBy(node => RemainingColors(graph, node).Count()).First();
        }

        private bool Color(int node, Graph graph)
        {
            var remainingColors = RemainingColors(graph, node);
            if (remainingColors.Count == 0)
            {
                return false;
            }

            foreach (int c in remainingColors)
            {
                operationsCount++;
                if (IsConsistent(graph, node, c))
                {
                    colors[node] = c;
                    return true;
                }
            }
            return false;
        }

        private HashSet<int> RemainingColors(Graph graph, int node)
        {
            operationsCount++;
            HashSet<int> usedColors = new HashSet<int>(graph.GetNeighbors(node).Where(neigh => colors.ContainsKey(neigh)).Select(neigh => colors[neigh]));
            return new HashSet<int>(Enumerable.Range(0, numColors).Except(usedColors));
        }

        private bool IsConsistent(Graph graph, int node, int color)
        {
            operationsCount++;
            HashSet<int> usedColors = new HashSet<int>(graph.GetNeighbors(node).Where(neigh => colors.ContainsKey(neigh)).Select(neigh => colors[neigh]));
            return !usedColors.Contains(color);
        }

        private bool Backtrack(Graph graph)
        {
            if (colors.Count == graph.CountVertices())
                return true;

            int node = MRVNode(graph);
            foreach (int c in Enumerable.Range(0, numColors))
            {
                if (IsConsistent(graph, node, c))
                {
                    colors[node] = c;
                    if (Backtrack(graph))
                        return true;
                    colors.Remove(node);
                }
            }
            return false;
        }

        public int GetOperationsCount()
        {
            return operationsCount;
        }
    }


    public class BacktrackingColoring : IGraphColoring
    {
        private int numColors;
        private int operationsCount;

        public BacktrackingColoring(int numColors)
        {
            this.numColors = numColors;
        }

        public Dictionary<int, int> ColorGraph(Graph graph)
        {
            int V = graph.CountVertices();
            operationsCount = 0;

            int[] color = new int[V];
            int[] degrees = new int[V];
            for (int i = 0; i < V; i++)
            {
                degrees[i] = GetNeighborsDegree(graph, i);
                operationsCount++;
            }
            int[] verticesOrder = GetVerticesOrderByDegree(graph);

            if (!GraphColoringUtil(0, color, verticesOrder, graph))
            {
                return null;
            }

            return GetColoringResult(color);
        }

        private bool GraphColoringUtil(int v, int[] color, int[] verticesOrder, Graph graph)
        {
            if (v == graph.CountVertices())
            {
                return true;
            }

            for (int c = 0; c < numColors; c++)
            {
                operationsCount++;
                if (IsSafe(verticesOrder[v], c, color, graph))
                {
                    color[verticesOrder[v]] = c;
                    if (GraphColoringUtil(v + 1, color, verticesOrder, graph))
                    {
                        return true;
                    }
                    color[verticesOrder[v]] = 0;
                }
            }
            return false;
        }

        private bool IsSafe(int v, int c, int[] color, Graph graph)
        {
            foreach (int i in graph.GetNeighbors(v))
            {
                if (i == v) continue;
                operationsCount++;
                if (color[i] == c)
                {
                    return false;
                }
            }
            return true;
        }

        private int GetNeighborsDegree(Graph graph, int vertex)
        {
            operationsCount++;
            return graph.GetNeighbors(vertex).Count(neighbor => neighbor != vertex);
        }

        private int[] GetVerticesOrderByDegree(Graph graph)
        {
            operationsCount++;
            return Enumerable.Range(0, graph.CountVertices())
                             .OrderByDescending(v => GetNeighborsDegree(graph, v))
                             .ToArray();
        }

        private Dictionary<int, int> GetColoringResult(int[] color)
        {
            Dictionary<int, int> result = new Dictionary<int, int>();
            for (int i = 0; i < color.Length; i++)
            {
                result[i] = color[i];
            }
            return result;
        }

        public int GetOperationsCount()
        {
            return operationsCount;
        }
    }

    internal static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
