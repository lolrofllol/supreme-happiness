using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASK
{
    internal class Node
    {
        public int TupleIndex { get; private set; }
        public List<Node> Children { get; set; }
        public bool IsLeaf => Children.Count == 0;
        public bool IsRoot => TupleIndex == -1;

        public Node()
        {
            TupleIndex = -1;
            Children = new List<Node>();
        }

        public Node(int tupleIndex)
        {
            TupleIndex = tupleIndex;
            Children = new List<Node>();
        }

        public Node(List<Node> children)
        {
            TupleIndex = -1;
            Children = children;
        }

    }
}
