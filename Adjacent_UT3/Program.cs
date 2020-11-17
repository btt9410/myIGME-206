using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Adjacent_UT3
{
    class Program
    {
        static bool[,] graphMatrix = new bool[,]
        { //         RED      BLUE     GREY    TEAL   YELLOW     ORANGE     PURPLE   GREEN
    /* RED (0) */ {  false,  true,     true,  false,  false,     false,    false,   false },
   /* BLUE (1) */ {  false,  false,   false,   true,   true,     false,    false,   false },
   /* GREY (2) */ {  false,  false,   false,   true,  false,      true,    false,   false },
   /* TEAL (3) */ {  false,   true,    true,  false,  false,     false,    false,   false },
 /* YELLOW (4) */ {  false,  false,   false,  false,  false,     false,    false,    true },
 /* ORANGE (5) */ {  false,  false,   false,  false,  false,     false,     true,   false },
 /* PURPLE (6) */ {  false,  false,   false,  false,   true,     false,    false,   false },
  /* GREEN (7) */ {  false,  false,   false,  false,  false,     false,    false,   false },
        };

        static int[][] graphList = new int[][]
        {
            new int[] { 1, 2 },
            new int[] { 3, 4 },
            new int[] { 3, 5 },
            new int[] { 1, 2 },
            new int[] { 7 },
            new int[] { 6 },
            new int[] { 4 },
            null
        };

        static List<Node> path = new List<Node>();
        static LinkedList<Node> linkedPath = new LinkedList<Node>();

        static bool wait = false;
        static int intState = 0;
        static string userState;

        static void Main(string[] args)
        {

            Node node;

            node = new Node(0);
            path.Add(node);
            linkedPath.AddLast(node);

            node = new Node(1);
            path.Add(node);
            linkedPath.AddLast(node);

            node = new Node(2);
            path.Add(node);
            linkedPath.AddLast(node);

            node = new Node(3);
            path.Add(node);
            linkedPath.AddLast(node);

            node = new Node(4);
            path.Add(node);
            linkedPath.AddLast(node);

            node = new Node(5);
            path.Add(node);
            linkedPath.AddLast(node);

            node = new Node(6);
            path.Add(node);
            linkedPath.AddLast(node);

            node = new Node(7);
            path.Add(node);
            linkedPath.AddLast(node);

            path[0].AddEdge(1, path[1]);
            path[0].AddEdge(5, path[2]);
            path[0].edges.Sort();

            path[1].AddEdge(1, path[3]);
            path[1].AddEdge(8, path[4]);

            path[2].AddEdge(0, path[3]);
            path[2].AddEdge(1, path[5]);
            path[2].edges.Sort();

            path[3].AddEdge(1, path[1]);
            path[3].AddEdge(0, path[2]);
            path[3].edges.Sort();

            path[4].AddEdge(6, path[7]);
            path[4].edges.Sort();

            path[5].AddEdge(1, path[6]);
            path[5].edges.Sort();

            path[6].AddEdge(1, path[4]);
            path[6].edges.Sort();
            
            List<Node> shortestPath = GetShortestPathDijkstra();

            string stringState;
            int nUserState;
            int moves = 0;

            Thread thread = new Thread(DFS);
            thread.Start();

            //while (intState != 7)
            while(intState != linkedPath.Last.Value.intState)
            {
                stringState = IntToStringState(intState);
                Console.WriteLine("Current state: " + stringState);

                Console.Write("Enter your desired state: ");
                //userState = Console.ReadLine().ToUpper();


                wait = true;
                while (wait) ;

                nUserState = StringToIntState(userState);
                Console.WriteLine(userState);


                //int[] stateList = graphList[intState];
                int[] stateList = new int[linkedPath.Count];
                for(int i = 0; i < linkedPath.Count; i++)
                {
                    stateList[i] = linkedPath.ElementAt<Node>(i).intState;
                }
                bool valid = false;

                if (stateList != null)
                {
                    foreach (int n in stateList)
                    {
                        if (n == nUserState)
                        {
                            valid = true;
                            intState = nUserState;
                            ++moves;
                            break;
                        }
                    }
                }

                if (!valid)
                {
                    Console.WriteLine("That is an invalid move.");
                }
            }

            Console.WriteLine("You won in " + moves + " moves.");

            thread.Abort();
        }

        static string IntToStringState(int intState)
        {
            string stringState = null;

            switch (intState)
            {
                case 0:
                    stringState = "RED";
                    break;
                case 1:
                    stringState = "BLUE";
                    break;
                case 2:
                    stringState = "GREY";
                    break;
                case 3:
                    stringState = "TEAL";
                    break;
                case 4:
                    stringState = "YELLOW";
                    break;
                case 5:
                    stringState = "ORANGE";
                    break;
                case 6:
                    stringState = "PURPLE";
                    break;
                case 7:
                    stringState = "GREEN";
                    break;
                default:
                    stringState = "RED";
                    break;
            }

            return stringState;
        }

        static int StringToIntState(string sState)
        {
            int intState;

            switch (sState)
            {
                case "RED":
                    intState = 0;
                    break;
                case "BLUE":
                    intState = 1;
                    break;
                case "GREY":
                    intState = 2;
                    break;
                case "TEAL":
                    intState = 3;
                    break;
                case "YELLOW":
                    intState = 4;
                    break;
                case "ORANGE":
                    intState = 5;
                    break;
                case "PURPLE":
                    intState = 6;
                    break;
                case "GREEN":
                    intState = 7;
                    break;
                default:
                    intState = 0;
                    break;
            }

            return intState;
        }
        static void DFS()
        {
            bool[] visit = new bool[graphList.Length];

            DFSUtil(intState, visit);
        }
        static void DFSUtil(int v, bool[] visit)
        {
            while (!wait) ;

            visit[v] = true;
            userState = IntToStringState(v);
            // Console.Write(v + " ");

            wait = false;

            int[] neighbors = graphList[v];
            foreach (int n in neighbors)
            {
                if (!visit[n])
                {
                    DFSUtil(n, visit);
                }
            }
        }

        static public List<Node> GetShortestPathDijkstra()
        {
            DijkstraSearch();
            List<Node> shortestPath = new List<Node>();
            shortestPath.Add(path[7]);
            BuildShortestPath(shortestPath, path[7]);
            shortestPath.Reverse();
            return (shortestPath);
        }
        
        static private void BuildShortestPath(List<Node> list, Node node)
        {
            if(node.nearestToStart == null)
            {
                return;
            }

            list.Add(node.nearestToStart);
            BuildShortestPath(list, node.nearestToStart);
        }

        static private int NodeOrderBy(Node n)
        {
            return n.minCostToStart;
        }

        static private void DijkstraSearch()
        {
            Node start = path[0];

            start.minCostToStart = 0;
            List<Node> prioQueue = new List<Node>();
            prioQueue.Add(start);

            do
            {
                prioQueue.Sort();

                prioQueue = prioQueue.OrderBy(delegate (Node n) { return n.minCostToStart; }).ToList();
                prioQueue = prioQueue.OrderBy((Node n) => { return n.minCostToStart; }).ToList();
                prioQueue = prioQueue.OrderBy((n) => { return n.minCostToStart; }).ToList();
                prioQueue = prioQueue.OrderBy((n) => n.minCostToStart).ToList();
                prioQueue = prioQueue.OrderBy(n => n.minCostToStart).ToList();

                Node node = prioQueue.First();
                prioQueue.Remove(node);

                foreach (Edge cnn in node.edges)
                {
                    Node childNode = cnn.connectedNode;
                    if (childNode.visit)
                    {
                        continue;
                    }

                    if (childNode.minCostToStart == int.MaxValue || node.minCostToStart + cnn.cost < childNode.minCostToStart)
                    {
                        childNode.minCostToStart = node.minCostToStart + cnn.cost;
                        childNode.nearestToStart = node;
                        if (!prioQueue.Contains(childNode))
                        {
                            prioQueue.Add(childNode);
                        }
                    }
                }
                node.visit = true;
                if (node == path[7])
                {
                    return;
                }
            } while (prioQueue.Any());
        }
    }

        public class Node : IComparable<Node>
        {
            public int intState;
            public List<Edge> edges = new List<Edge>();

            public int minCostToStart;
            public Node nearestToStart;
            public bool visit;

            public Node(int intState)
            {
                this.intState = intState;
                this.minCostToStart = int.MaxValue;
            }

            public void AddEdge(int cost, Node connect)
            {
                Edge e = new Edge(cost, connect);
                edges.Add(e);
            }

            public int CompareTo(Node n)
            {
                return this.minCostToStart.CompareTo(n.minCostToStart);
            }
        }

        public class Edge : IComparable<Edge>
        {
            public int cost;
            public Node connectedNode;

            public Edge(int cost, Node connectedNode)
            {
                this.cost = cost;
                this.connectedNode = connectedNode;
            }

            public int CompareTo(Edge e)
            {
                return this.cost.CompareTo(e.cost);
            }

    }
}