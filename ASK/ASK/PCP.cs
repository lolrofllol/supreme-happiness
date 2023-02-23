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
        private List<string>? _inputX;
        private List<string>? _inputY;

        private List<List<string>>? _listX, _tempListX;
        private List<List<string>>? _listY, _tempListY;


        public bool? Run(List<string> listX, List<string> listY)
        {
            //_inputX = listX;
            //_inputY = listY;

            //_listX = new List<List<string>>();
            //_listY = new List<List<string>>();

            //_tempListX = new List<List<string>>();
            //_tempListY = new List<List<string>>();

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
