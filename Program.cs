using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>
        {
            { 0, new List<int> { 1, 2 } },
            { 1, new List<int> { 0, 3, 4 } },
            { 2, new List<int> { 0, 5, 6 } },
            { 3, new List<int> { 1 } },
            { 4, new List<int> { 1, 5 } },
            { 5, new List<int> { 2, 4 } },
            { 6, new List<int> { 2 } }
        };

            int startNode = 0;
            int endNode = 5;

            var queue = new Queue<int>();
            var visited = new HashSet<int>();
            var parents = new Dictionary<int, int>();

            queue.Enqueue(startNode);
            visited.Add(startNode);

            while (queue.Count > 0)
            {
                int current = queue.Dequeue();

                if (current == endNode) break;

                foreach (var neighbor in graph[current])
                {
                    if (!visited.Contains(neighbor))
                    {
                        visited.Add(neighbor);
                        parents[neighbor] = current;
                        queue.Enqueue(neighbor);
                    }
                }
            }

            List<int> path = new List<int>();
            if (parents.ContainsKey(endNode) || startNode == endNode)
            {
                int curr = endNode;
                while (curr != startNode)
                {
                    path.Add(curr);
                    curr = parents[curr];
                }
                path.Add(startNode);
                path.Reverse();

                Console.WriteLine(string.Join(" -> ", path));
            }
        }
    }
}
