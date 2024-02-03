using System;
using System.Collections.Generic;
using System.Linq;

class Vertex
{
    public object Object;
    public IReadOnlyList<Edge> IncidentEdges;
}

class Edge 
{
    public Vertex A;
    public Vertex B;
    public bool Contains(Vertex V) => V == A || V == B;
}

interface IAdjacencyList
{
    IReadOnlyList<Vertex> Verteces { get; }
    IReadOnlyList<Edge> Edges { get; }
}

class Graph : IAdjacencyList
{
    readonly List<Vertex> _vertices = new List<Vertex>();
    readonly List<Edge> _edges = new List<Edge>();

    public Graph(int[] vertices, KeyValuePair<int,int>[] edges)
    {
        foreach (KeyValuePair<int,int> pair in edges)
        {
            if (!_vertices.Exists(v => (int)v.Object == pair.Key))
            {
                _vertices.Add(new Vertex { Object = pair.Key });
            }
            if (!_vertices.Exists(v => (int)v.Object == pair.Value))
            {
                _vertices.Add(new Vertex { Object = pair.Value });
            }
            Vertex A = _vertices
                .Where(v => (int)v.Object == pair.Key)
                .First();
            Vertex B = _vertices
                .Where(v => (int)v.Object == pair.Value)
                .First();
            _edges.Add(new Edge { A = A, B = B });
        }
        foreach (int v in vertices)
        {
            if (!_vertices.Exists(e => (int)e.Object == v))
            {
                _vertices.Add(new Vertex { Object = v });
            }
            Vertex s = _vertices
                .Where(e => (int)e.Object == v)
                .First();
            s.IncidentEdges = _edges
                .Where(e => e.Contains(s))
                .ToList();
        }
    }

    public IReadOnlyList<Vertex> Verteces => _vertices;

    public IReadOnlyList<Edge> Edges => _edges;
}

namespace ConsoleAppGraph
{
    class Program
    {
        static IEnumerable<Vertex> BFS(IAdjacencyList graph, int s)
        {
            var explored = new List<Vertex>
            {
                graph.Verteces[s]
            };

            var queue = new Queue<Vertex>();
            queue.Enqueue(graph.Verteces[s]);

            yield return graph.Verteces[s];

            while (queue.Any())
            {
                var work = queue.Dequeue();
                var adjacents = graph.Edges
                    .Where(e => e.Contains(work))
                    .Select(e => e.A == work ? e.B : e.A);

                foreach (var adj in adjacents)
                {
                    if (!explored.Contains(adj))
                    {
                        explored.Add(adj);
                        yield return adj;
                        queue.Enqueue(adj);
                    }
                }
            }
        }

        static IEnumerable<Vertex> DFS(IAdjacencyList graph, int s)
        {
            var explored = new List<Vertex>();

            var stack = new Stack<Vertex>();
            stack.Push(graph.Verteces[s]);

            yield return graph.Verteces[s];

            while (stack.Any())
            {
                var work = stack.Pop();
                if (!explored.Contains(work))
                {
                    explored.Add(work);
                    if (work != graph.Verteces[s])
                    {
                        yield return work;
                    }

                    var adjacents = graph.Edges
                        .Where(e => e.Contains(work))
                        .Select(e => e.A == work ? e.B : e.A);

                    foreach (var adj in adjacents)
                    {
                        stack.Push(adj);
                    }
                }
            }
        }

        static Dictionary<Vertex, int> ComputeDistance(IAdjacencyList graph, int s)
        {
            var explored = new List<Vertex>
            {
                graph.Verteces[s]
            };

            var queue = new Queue<Vertex>();
            queue.Enqueue(graph.Verteces[s]);

            Dictionary<Vertex, int> distances = new Dictionary<Vertex, int>();
            foreach (var v in graph.Verteces)
                distances.Add(v, v == graph.Verteces[s] ? 0 : int.MaxValue);

            while (queue.Any())
            {
                var work = queue.Dequeue();
                var adjacents = graph.Edges
                    .Where(e => e.Contains(work))
                    .Select(e => e.A == work ? e.B : e.A);

                foreach (var adj in adjacents)
                {
                    if (!explored.Contains(adj))
                    {
                        explored.Add(adj);
                        distances[adj] = distances[work] + 1;
                        queue.Enqueue(adj);
                    }
                }
            }
            return distances;
        }


        static void Main(string[] args)
        {
            Graph graph = new Graph(
                new int[] { 0, 1, 2, 3, 4, 5 },
                new KeyValuePair<int, int>[]
                {
                    new KeyValuePair<int, int>( 0, 2 ),
                    new KeyValuePair<int, int>( 0, 1 ),
                    new KeyValuePair<int, int>( 1, 2 ),
                    new KeyValuePair<int, int>( 1, 3 ),
                    new KeyValuePair<int, int>( 3, 2 ),
                    new KeyValuePair<int, int>( 3, 4 ),
                    new KeyValuePair<int, int>( 2, 5 )
                });

            foreach (Vertex vertex in graph.Verteces)
            {
                Console.WriteLine("Vertex: " + vertex.Object.ToString());
                foreach (Edge edge in vertex.IncidentEdges)
                {
                    Console.WriteLine("\tEdge: " + edge.A.Object.ToString() + " " + edge.B.Object.ToString());
                }
            }

            Console.WriteLine("\nAll Edges");
            foreach (Edge edge in graph.Edges)
            {
                Console.WriteLine("\tEdge: " + edge.A.Object.ToString() + " " + edge.B.Object.ToString());
            }

            var bfs = BFS(graph, 0);
            var dfs = DFS(graph, 0);

            Console.Write("\nBFS: ");
            foreach (var s in bfs)
                Console.Write(s.Object.ToString() + " ");
            Console.WriteLine();

            Console.Write("\nDFS: ");
            foreach (var s in dfs)
                Console.Write(s.Object.ToString() + " ");
            Console.WriteLine();

            var distances = ComputeDistance(graph, 0);
            Console.WriteLine("\nDistances: ");
            foreach (var s in distances)
                Console.WriteLine($"d(0, { s.Key.Object }) = { s.Value }");

            Console.ReadKey();
        }
    }
}
