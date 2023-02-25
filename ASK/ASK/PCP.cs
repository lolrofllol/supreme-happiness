using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ASK
{
    internal class PCP
    {
        private List<string> ListX, ListY;
        public bool? Run(List<string> listX, List<string> listY)
        {
            var pcpDataList = new List<PCPData>();
            var temp = new List<PCPData>();

            if (listX.Count != listY.Count)
            {
                return null;
            }

            int i = 1;
            int tupleCount = listX.Count;

            while (i < 999)
            {
                Console.WriteLine($"Testing index {i}");

                if (i == 1)
                {
                    for (int j = 0; j < tupleCount; j++)
                    {
                        var indices = new List<int>() { j };

                        var pcpData = new PCPData(indices, listX[j], listY[j]);
                        pcpDataList.Add(pcpData);

                        if (pcpData.Check())
                        {
                            Console.WriteLine("found solution!");
                            Console.Write("sequence: ");
                            Console.WriteLine(string.Join(",", pcpData.Indices));
                            return true;
                        }
                    }
                }
                else
                {
                    temp = new List<PCPData>();
                    Console.WriteLine($"testing {pcpDataList.Count} tuples");
                    foreach (var item in pcpDataList)
                    {
                        for (int j = 0; j < tupleCount; j++)
                        {
                            var indices = new List<int>(item.Indices)
                            {
                                j
                            };

                            var sequenceX = item.SequenceX + listX[j];
                            var sequenceY = item.SequenceY + listY[j];

                            var pcpData = new PCPData(indices, sequenceX, sequenceY);
                            temp.Add(pcpData);

                            if (pcpData.Check())
                            {
                                var printableIndices = new List<int>(pcpData.Indices);
                                printableIndices.ForEach(x => x++);
                                Console.WriteLine("found solution!");
                                Console.Write("indices: ");
                                foreach (var index in pcpData.Indices)
                                {
                                    Console.Write($"{index + 1},");
                                }
                                Console.WriteLine();

                                Console.WriteLine($"sequence: {pcpData.SequenceX}");
                                return true;
                            }
                        }
                    }
                    pcpDataList = new List<PCPData>(temp);
                }

                i += 1;
            }

            return false;
        }

        public bool? RunWithTree(List<string> listX, List<string> listY, int depth = 15)
        {
            if (listX.Count != listY.Count)
            {
                return null;
            }

            ListX = listX;
            ListY = listY;

            int tupleCount = listX.Count;

            var root = new Node();

            var parentNodes = new List<Node>() { root };
            for (int x = 0; x < depth; x++)
            {
                Console.WriteLine($"creating depth layer {x}");
                var tempNodes = new List<Node>();
                foreach (var parentNode in parentNodes)
                {
                    var children = new List<Node>();
                    for (int i = 0; i < tupleCount; i++)
                    {
                        var node = new Node(i + 1);
                        children.Add(node);
                    }
                    parentNode.Children = children;
                    tempNodes.AddRange(children);
                }
                parentNodes = tempNodes;
            }

            return CheckNode(root, new List<int>());
        }

        private bool CheckNode(Node node, List<int> indices)
        {
            Console.WriteLine($"checking node with depth: {indices.Count + 1}");

            if (node.IsRoot)
            {
                foreach (var child in node.Children)
                {
                    if (CheckNode(child, indices)) return true;
                }
                return false;
            }

            var sequenceX = "";
            var sequenceY = "";

            foreach (var index in indices)
            {
                sequenceX += ListX[index - 1];
                sequenceY += ListY[index - 1];
            }

            sequenceX += ListX[node.TupleIndex - 1];
            sequenceY += ListY[node.TupleIndex - 1];

            var newIndices = new List<int>(indices)
            {
                node.TupleIndex
            };

            if (sequenceX == sequenceY)
            {

                Console.WriteLine("found solution!");
                Console.Write("indices: ");
                foreach (var index in newIndices)
                {
                    Console.Write($"{index},");
                }
                Console.WriteLine();

                Console.WriteLine($"sequence: {sequenceX}");
                return true;
            }

            if (node.IsLeaf)
            {
                Console.WriteLine("leaf reached!");
            }
            else
            {
                foreach (var child in node.Children)
                {
                    if (CheckNode(child, newIndices)) return true;
                }
            }

            return false;
        }
    }

    internal class PCPData
    {
        public List<int> Indices { get; private set; }
        public string SequenceX { get; private set; }
        public string SequenceY { get; private set; }
        public PCPData(List<int> indices, string sequenceX, string sequenceY) =>
            (Indices, SequenceX, SequenceY) = (indices, sequenceX, sequenceY);

        public bool Check() => SequenceX == SequenceY;
    }
}
