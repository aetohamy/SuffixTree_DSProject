using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;

namespace SuffixTree_CSharpImplementation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int getNextIndexOf(int index , char c , string str)
        {
            for(int i = index ; i<str.Length;i++)
            {
                if (str[i] == c)
                    return i;
            }
            return -1;
        }

        private void button_BuildTree_Click(object sender, EventArgs e)
        {
            
            treeView1.Nodes.Clear();
            if (textBox_Word.Text == "")
                MessageBox.Show("String entered is empty.", "Empty String", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                string word = textBox_Word.Text;
                Dictionary<char, List<Suffix>> data = new Dictionary<char, List<Suffix>>();
                for(int i = 0 ; i < word.Length;i++)
                {
                    if(!data.ContainsKey(word[i]))
                    {
                        Suffix newSuffix = new Suffix(word.Substring(i+1),i+1);
                        List<Suffix> newVector = new List<Suffix>();
                        newVector.Add(newSuffix);
                        data.Add(word[i], newVector);
                    }

                    else
                    {
                        if (getNextIndexOf(i, word[i], word) == -1)
                            continue;
                        Suffix newSuffix = new Suffix(word.Substring(getNextIndexOf(i, word[i], word)+1), getNextIndexOf(i, word[i], word));
                        data[word[i]].Add(newSuffix);
                    }
                }

                TreeBuilder treeBuild = new TreeBuilder(data, treeView1);
                treeBuild.BuildTree();
                groupBox3.Enabled = true;
                
            }
        }

        private void button_Search_Click(object sender, EventArgs e)
        {
            bool isFound = false;
            if(textBox_SearchString.Text =="")
                MessageBox.Show("String entered is empty.", "Empty String", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
            else
            {
                string search = textBox_SearchString.Text;
                foreach(TreeNode node in treeView1.Nodes)
                {
                    if(node.Text==search[0].ToString())
                    {
                        string substr = search.Substring(1);
                      
                        foreach(TreeNode children in node.Nodes)
                        {
                           
                            if (children.Text == substr)
                            {
                                treeView1.SelectedNode = children.Nodes[1];
                                children.ForeColor = Color.Red;
                                children.Nodes[0].ForeColor = Color.Red;
                                children.Nodes[1].ForeColor = Color.Red;
                                MessageBox.Show(children.Nodes[0].Text +"\n" + children.Nodes[1].Text,"Suffix Found",MessageBoxButtons.OK,MessageBoxIcon.Information);
                                dataGridView1.Rows.Add(textBox_Word.Text, textBox_SearchString.Text, "Found", children.Nodes[1].Text);
                                isFound = true;
                                break;  
                            }
                        }
                    }
                }
                if (!isFound)
                {
                    MessageBox.Show("Suffix not found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dataGridView1.Rows.Add(textBox_Word.Text, textBox_SearchString.Text, "Not Found", "NULL");
                }
            }
        }
    }
}
