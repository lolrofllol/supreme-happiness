using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASK
{
    internal class PCP
    {
        private List<string>? _inputX;
        private List<string>? _inputY;

        private List<List<string>>? _listX;
        private List<List<string>>? _listY;


        public bool? Run(List<string> listX, List<string> listY)
        {
            _inputX = listX;
            _inputY = listY;

            _listX = new List<List<string>>();
            _listY = new List<List<string>>();

            if (listX.Count != listY.Count)
            {
                return null; 
            }

            int i = 0;
            int tupleCount = listX.Count;

            while (i < 999)
            {
                for (int j = 0; j < tupleCount; j++)
                {

                }
            }

            return false;
        }


    }
}
