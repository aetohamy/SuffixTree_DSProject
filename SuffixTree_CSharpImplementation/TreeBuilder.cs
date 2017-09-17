using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace SuffixTree_CSharpImplementation
{
    class TreeBuilder
    {
        private Dictionary<char, List<Suffix>> data;
        private TreeView tree;

        public TreeBuilder()
        {
            data = null;
            tree = null;
        }

        public TreeBuilder(Dictionary<char, List<Suffix>> data , TreeView tree)
        {
            this.data = data;
            this.tree = tree;
        }

        public void BuildTree()
        {
            int i = 0;
            foreach (KeyValuePair<char, List<Suffix>> entry in data)
            {
                tree.Nodes.Add(entry.Key.ToString());
                foreach(Suffix suffix in entry.Value)
                {
                    if(suffix.SuffixString=="")
                    {
                        suffix.SuffixString = "$";
                    }

                    TreeNode newNode = new TreeNode(suffix.SuffixString);
                    newNode.Nodes.Add("Suffix : " + suffix.SuffixString);
                    newNode.Nodes.Add("Index : " + suffix.SuffixIndex);
                    tree.Nodes[i].Nodes.Add(newNode);
                }
                i++;
            }
        }

    }
}
