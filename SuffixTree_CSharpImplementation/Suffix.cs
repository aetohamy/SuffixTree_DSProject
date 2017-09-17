using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuffixTree_CSharpImplementation
{
    class Suffix
    {
        private string suffix;
        private int index;

        public string SuffixString
        {
            get
            {return suffix;}

            set 
            { suffix = value;}
        }

        public int SuffixIndex
        {
            get
            { return index; }
            set
            { index = value;}
        }

        public Suffix()
        {
            suffix = "";
            index = -1;
        }

        public Suffix(string suffix , int index)
        {
            this.suffix = suffix;
            this.index = index;
        }
    }
}
