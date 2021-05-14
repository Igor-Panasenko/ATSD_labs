using System;
using System.Collections;
using System.Collections.Generic;

namespace Graph_algorithms
{
    public class WeightedGraph<T> where T : IComparable
    {
        public class Edge : IComparable<Edge>
        {
            public int src;
            public int dest;
            public int weight;

            public Edge()
            {
                src = 0;
                dest = 0;
                weight = 0;
            }

            public Edge(int from, int to, int weight)
            {
                src = from;
                dest = to;
                this.weight =weight;
            }
            public int CompareTo(Edge comparerEdge)
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

        private int V;          //количество вершины
        private int E;          // количество ребра
        public Edge[] edge;
        public int[,] Adjacency_matrix;
 public WeightedGraph()
        {
            Console.WriteLine("Hello, write number of vertices and \nnumber of edges in your graph");
            string str= Console.ReadLine();
            string part_str="";
            int V;
            int E;
            int te = 0;
            while (str[te] != ',')
            {
                part_str += str[te];
                te++;
            }
            V = Convert.ToInt32(part_str);
            part_str = "";
            te++;
            while (te < str.Length)
            {
                part_str += str[te];
                te++;
            }
            E = Convert.ToInt32(part_str);

            this.V = V;
            this.E = E;
            this.edge = new Edge[E];
            this.Adjacency_matrix = new int[V, V];
            int number = 0;
            while (number != E)
            {
                Console.WriteLine("Write from start and destination number for vertex");
                str=Console.ReadLine();
                te = 0;
                part_str = "";
                
                while (str[te] != ',')
                {
                    part_str += str[te];
                    te++;
                }
                int from = Convert.ToInt32(part_str);
                part_str = "";
                te++;
                while (te < str.Length)
                {
                    part_str += str[te];
                    te++;
                }
                int to = Convert.ToInt32(part_str);
                Console.WriteLine("write weight of this vertex");
                int weight= Convert.ToInt32(Console.ReadLine());
                edge[number] = new Edge(from, to, weight);
                number++;
                Console.Clear();
            }
            for (int i = 0; i < edge.Length; i++)
            {
                Adjacency_matrix[edge[i].src, edge[i].dest] = edge[i].weight;
                Adjacency_matrix[edge[i].dest, edge[i].src] = edge[i].weight;
            }
        }
        public WeightedGraph(int v, int e)
        {
            this.V = v;
            this.E = e;
            this.edge = new Edge[E];
            for (int i = 0; i < e; i++)
            {
                edge[i] = new Edge();
            }
            this.Adjacency_matrix = new int[V, V];
        }

        public void print_graph()
        {
            string answer = "";
            for(int i=0; i<V; i++)
            {
                for(int j=0; j<V; j++)
                {
                    answer += Adjacency_matrix[i, j]+"   ";
                }
                answer += "\n";
            }
            Console.WriteLine(answer);
        }
        private int find(subset[] subsets, int i)
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
            Edge[] result = new Edge[this.V];    //массив где хранится результирующее МСТ
            int e = 0;
            for (int i = 0; i < V; ++i)
            {
                result[i] = new Edge();                 //заполнили результат дефолтными полями 
            }
            Edge[] copy = new Edge[this.edge.Length];
            for (int i = 0; i < this.edge.Length; ++i)
            {
                copy[i] = new Edge();                
            }
            for (int j = 0; j < this.edge.Length; j++)
            {
                copy[j].weight = edge[j].weight;
                copy[j].src = edge[j].src;
                copy[j].dest = edge[j].dest;
            }
            for (int j = 0; j < copy.Length; j++)
            {
                for (int k = j; k < copy.Length; k++)
                {
                    if (copy[j].CompareTo(copy[k]) > 0)
                    {
                        Edge temp = copy[j];
                        copy[j] = copy[k];
                        copy[k] = temp;
                    }
                }
            }
            subset[] subsets = new subset[this.V];
            for (int i = 0; i < V; i++)
            {
                subsets[i] = new subset();
            }
            for (int v = 0; v < V; v++)
            {
                subsets[v].parent = v;
                subsets[v].rank = 0;
            }
            int next = 0;
            while (e < V - 1)
            {
                Edge next_edge = copy[next];
                int x = find(subsets, next_edge.src);
                int y = find(subsets, next_edge.dest);

                if (x != y)
                {
                    result[e++] = next_edge;
                    this.union(subsets, x, y);
                }
                next++;
            }
            Console.WriteLine("Following are edges in the constructed MST");
            int minCost=0;
            for (int i = 0; i < e; ++i)
            {
                Console.WriteLine(result[i].src + " -- " + result[i].dest + " == " + result[i].weight);
                minCost += result[i].weight;
            }
            Console.WriteLine("Minimum Cost Spanning Tree = " + minCost);
            Console.ReadLine();
        }

        public void dijkstra()
        {
            Console.WriteLine("write number of start vertex but < " + V);
            int start =Convert.ToInt32(Console.ReadLine());
            if (start >= V)
            {
                Console.WriteLine("error, too big number. \nnumbers of vertices starts with 0");
                return;
            }
            int No_Parent = -1;
            int[] shortestDistances = new int[V];
            bool[] added = new bool[V];
            for(int i=0; i<V; i++)
            {
                shortestDistances[i] = int.MaxValue;
                added[i] = false;
            }
            shortestDistances[start] = 0;
            int[] parents = new int[V];
            parents[start] = No_Parent;
            for(int i=0; i<V; i++)
            {
                int nearestVertex = -1;
                int shortestDistance = int.MaxValue;
                for(int vertexIndex=0; vertexIndex<V; vertexIndex++)
                {
                    if(!added[vertexIndex] && shortestDistances[vertexIndex] < shortestDistance)
                    {
                        nearestVertex = vertexIndex;
                        shortestDistance = shortestDistances[vertexIndex];
                    }
                }
                added[nearestVertex] = true;
                for(int vertexIndex=0; vertexIndex<V; vertexIndex++)
                {
                    int edgeDistance = this.Adjacency_matrix[nearestVertex, vertexIndex];
                    if (edgeDistance > 0 && ((shortestDistance + edgeDistance) < shortestDistances[vertexIndex])){
                        parents[vertexIndex] = nearestVertex;
                        shortestDistances[vertexIndex] = shortestDistance + edgeDistance;

                    }
                }

            }
            print_Solution(start, shortestDistances, parents);
        }
        private void print_Solution(int start, int[] distances, int[] parents)
        {
            int nVertices = distances.Length;
            Console.Write("Vertex\t Distance \tPath");
            for(int vertexIndex=0; vertexIndex<nVertices; vertexIndex++)
            {
                if (vertexIndex != start)
                {
                    Console.Write("\n"+start+"-->");
                    Console.Write(vertexIndex + " \t\t ");
                    Console.Write(distances[vertexIndex] + " \t\t ");
                    printPath(vertexIndex, parents);
                }
            }
        }

        private void printPath(int current, int[] parents)
        {
            if (current == -1)
            {
                return;
            }
            printPath(parents[current], parents);
            Console.Write(current + " ");
        }
        //дополнительное задание

        public void Prim_Sll()
        {
            SortedList parent = new SortedList(V);
            SortedList key = new SortedList(V);
            bool[] mstSet = new bool[V];
            for(int i=0; i<this.V; ++i)
            {
                key[i] = int.MaxValue;
                mstSet[i]= false;
            }
            key[0] = 0;
            parent[0] = -1;
            for(int count=0; count<this.V-1; count++)
            {
                int u = MinKey(mstSet, key);
                mstSet[u] = true;
                for(int v=0; v<this.V; ++v)
                {
                    if(Adjacency_matrix[u,v]!=0 && mstSet[v]==false && Adjacency_matrix[u, v] <(int)key[v])
                    {
                        parent[v] = u;
                        key[v] = Adjacency_matrix[u, v];
                    }
                }
            }
            Print_MST(parent);
            
        }
        private int MinKey ( bool[] set, SortedList key)
        {
            int min = int.MaxValue; 
            int minindex = -1;
            for(int v=0; v<this.V; ++v)
            {
                if (set[v] == false && (int)key[v]<min)
                {
                    minindex = v;
                    min =(int) key[v];
                    
                }
            }
            return minindex;
        }
        private void Print_MST (SortedList parent)
        {
            int Sum_MST = 0;
            Console.WriteLine("Edge     Weight");
            for(int i=1; i<this.V; ++i)
            {
                Sum_MST += Adjacency_matrix[i, (int)parent[i]];
                Console.WriteLine(parent[i] + " - " + i + "   " + Adjacency_matrix[i, (int)parent[i]]);
            }
            Console.WriteLine("Sum weights of MST == " + Sum_MST);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
           // WeightedGraph<int> graph = new WeightedGraph<int>();
            WeightedGraph<int> graph = new WeightedGraph<int>(4, 5);
            graph.edge[0].src = 0;
            graph.edge[0].dest = 1;
            graph.edge[0].weight = 10;

            // add edge 0-2
            graph.edge[1].src = 0;
            graph.edge[1].dest = 2;
            graph.edge[1].weight = 6;

            // add edge 0-3
            graph.edge[2].src = 0;
            graph.edge[2].dest = 3;
            graph.edge[2].weight = 5;

            // add edge 1-3
            graph.edge[3].src = 1;
            graph.edge[3].dest = 3;
            graph.edge[3].weight = 15;

            // add edge 2-3
            graph.edge[4].src = 2;
            graph.edge[4].dest = 3;
            graph.edge[4].weight = 4;
            for (int i = 0; i < graph.edge.Length; i++)
            {
               graph.Adjacency_matrix[graph.edge[i].src, graph.edge[i].dest] = graph.edge[i].weight;
                graph.Adjacency_matrix[graph.edge[i].dest, graph.edge[i].src] = graph.edge[i].weight;
            }




            graph.print_graph();
            graph.KruskalsMST();
            graph.dijkstra();
            Console.WriteLine();
            graph.Prim_Sll();
        }
    }
}
