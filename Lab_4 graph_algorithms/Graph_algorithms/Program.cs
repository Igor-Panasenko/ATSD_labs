﻿using System;

namespace Graph_algorithms
{
    class WeightedGraph<T> where T : IComparable {
        private class Edge<T> : IComparable<Edge<T>> where T : IComparable {
            public int src;
            public int dest;
            public T weight;

            public Edge()
            {
                src = 0;
                dest = 0;
                weight = default(T);
            }
            public int CompareTo(Edge<T> comparerEdge)
            {
                if (this.weight.CompareTo(comparerEdge.weight) > 0)
                {
                    return 1;
                }
                if (this.weight.CompareTo(comparerEdge.weight) < 0)
                {
                    return -1;
                }
                return 0;
            }
        }
        public class subset
        {
            public int parent;
            public int rank;
            public subset()
            {
                parent = 0;
                rank = 0;
            }
        }

       private int V;
       private int E;
       private Edge<T>[] edge;

       public WeightedGraph(int v, int e)
        {
            this.V = v;
            this.E = e;
            this.edge = new Edge<T>[E];
            for(int i=0; i<e; i++)
            {
                edge[i] = new Edge<T>();
            }
        }
        private int find (subset[] subsets, int i)
        {
            if (subsets[i].parent != i)
            {
                subsets[i].parent = find(subsets, subsets[i].parent);
            }
            return subsets[i].parent;
        }

        private void union(subset[] subsets, int x, int y)
        {
            int xRoot = find(subsets, x);
            int yRoot = find(subsets, y);
            if (subsets[xRoot].rank < subsets[yRoot].rank)
            {
                subsets[xRoot].parent = yRoot;
            }
            else
            {
                if (subsets[xRoot].rank > subsets[yRoot].rank)
                {
                    subsets[yRoot].parent = xRoot;
                }
                else
                {
                    subsets[yRoot].parent = xRoot;
                    subsets[xRoot].rank++;
                }
            }
        }
        public void KruskalsMST()
        {
            Edge<T>[] result = new Edge<T>[this.V];
            int e = 0;
            for(int i=0; i<V; ++i)
            {
                result[i] = new Edge<T>();
            }
            Edge<T>[] copy = new Edge<T>[this.edge.Length];
            for(int j=0; j<this.edge.Length; j++)
            {
                copy[j].weight= edge[j].weight;
                copy[j].src = edge[j].src;
                copy[j].dest = edge[j].dest;
            }
            for(int j=0; j<copy.Length; j++)
            {
                for(int k=j; k<copy.Length; k++)
                {
                    if (copy[j].CompareTo(copy[k]) > 0)
                    {
                        Edge<T> temp = copy[j];
                        copy[j] = copy[k];
                        copy[k] = temp;
                    }
                }
            }
            subset[] subsets = new subset[this.V];
            for(int i=0; i<V; i++)
            {
                subsets[i] = new subset();
            }
            for(int v=0; v<V; v++)
            {
                subsets[v].parent = v;
                subsets[v].rank = 0;
            }
            int next=0;
            while (e < V - 1)
            {
                Edge<T> next_edge = copy[next++];
                int x = find(subsets, next_edge.src);
                int y = find(subsets, next_edge.dest);

                if (x != y)
                {
                    result[e++] = next_edge;
                    this.union(subsets, x, y);
                }
            }
            Console.WriteLine("Following are edges in the construxted MST");
            T minCost;
            for(int i=0; i<e; ++i)
            {
                Console.WriteLine(result[i].src + " -- " + result[i].dest + " == " + result[i].weight);
            }
            Console.ReadLine();
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
