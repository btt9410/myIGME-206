using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BinaryTreeVisualizer;

namespace BTree
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            string exeFile = Application.ExecutablePath;
            exeFile = exeFile.Substring(exeFile.LastIndexOf('\\') + 1);

            try
            {
                using (var key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(
        @"Software\WOW6432Node\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION",
        true))
                {
                    key.SetValue(exeFile, 11001, Microsoft.Win32.RegistryValueKind.DWord);
                    key.Close();
                }
            }
            catch
            {
                MessageBox.Show(@"Cannot access the registry, but the program may work.  If not, run " + exeFile + @" as Administrator or ensure registry setting Computer\HKEY_LOCAL_MACHINE\ SOFTWARE\WOW6432Node\Microsoft\ Internet Explorer\Main\ FeatureControl\FEATURE_BROWSER_EMULATION has a DWORD value for Name = " + exeFile + " with a value of 11001.  Otherwise the Web Browser features may not work.");
            }

            InitializeComponent();

            BTree.form1 = this;
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            BTree root = null;
            BTree node;
            List<int> treeList = new List<int>();

            this.richTextBox1.Clear();

            node = new BTree(1, null);
            root = node;
            treeList.Add(node.id);
            node = new BTree(5, root);
            treeList.Add(node.id);
            node = new BTree(15, root);
            treeList.Add(node.id);
            node = new BTree(20, root);
            treeList.Add(node.id);
            node = new BTree(21, root);
            treeList.Add(node.id);
            node = new BTree(22, root);
            treeList.Add(node.id);
            node = new BTree(23, root);
            treeList.Add(node.id);
            node = new BTree(24, root);
            treeList.Add(node.id);
            node = new BTree(25, root);
            treeList.Add(node.id);
            node = new BTree(30, root);
            treeList.Add(node.id);
            node = new BTree(35, root);
            treeList.Add(node.id);
            node = new BTree(37, root);
            treeList.Add(node.id);
            node = new BTree(40, root);
            treeList.Add(node.id);
            node = new BTree(55, root);
            treeList.Add(node.id);
            node = new BTree(60, root);
            treeList.Add(node.id);

            this.richTextBox1.Text += "\n";
            BTree.TraverseAscending(root);

            // new root and node
            BTree nodeTwo;
            BTree rootTwo = null;

            // between 1 and 60
            nodeTwo = new BTree(30, null, false);
            rootTwo = nodeTwo;
            nodeTwo = new BTree(15, rootTwo, false);
            nodeTwo = new BTree(45, rootTwo, false);
            nodeTwo = new BTree(8, rootTwo, false);
            nodeTwo = new BTree(23, rootTwo, false);
            nodeTwo = new BTree(38, rootTwo, false);
            nodeTwo = new BTree(53, rootTwo, false);


            for (int i = 0; i < treeList.Count; i++)
            {
                if (i == 0)
                {
                    nodeTwo = new BTree(treeList.ElementAt(i), null);
                    rootTwo = nodeTwo;
                }
                else
                {
                    nodeTwo = new BTree(treeList.ElementAt(i), rootTwo);
                }
            }

            this.richTextBox1.Text += "\n";
            BTree.TraverseAscending(rootTwo);



            VisualizeBinaryTree visualizeBinaryTree = new VisualizeBinaryTree(rootTwo);
        }
    }
    public class BTree
    {
        public BTree ltChild;

        public BTree gteChild;

        public object data;

        public bool isData;

        public int id;

        public static Form1 form1;

        private static int nLastCntr;

        public static bool operator ==(BTree a, BTree b)
        {
            bool returnVal = false;

            try
            {
                if (a.data.GetType() == typeof(int))
                {
                    returnVal = ((int)a.data == (int)b.data);
                }

                if (a.data.GetType() == typeof(string))
                {
                    returnVal = ((string)a.data == (string)b.data);
                }
            }
            catch
            {
                returnVal = (a == (object)b);
            }

            return (returnVal);
        }

        public static bool operator !=(BTree a, BTree b)
        {
            bool returnVal = false;
            try
            {
                if (a.data.GetType() == typeof(int))
                {
                    returnVal = ((int)a.data != (int)b.data);
                }

                if (a.data.GetType() == typeof(string))
                {
                    returnVal = ((string)a.data != (string)b.data);
                }
            }
            catch
            {
                returnVal = (a != (object)b);
            }

            return (returnVal);
        }

        public static bool operator <(BTree a, BTree b)
        {
            bool returnVal = false;

            try
            {
                if (a.data.GetType() == typeof(int))
                {
                    returnVal = ((int)a.data < (int)b.data);
                }

                if (a.data.GetType() == typeof(string))
                {
                    returnVal = (((string)a.data).CompareTo((string)b.data) < 0);
                }
            }
            catch
            {
                returnVal = false;
            }

            return (returnVal);
        }

        public static bool operator >(BTree a, BTree b)
        {
            bool returnVal = false;

            try
            {
                if (a.data.GetType() == typeof(int))
                {
                    returnVal = ((int)a.data > (int)b.data);
                }

                if (a.data.GetType() == typeof(string))
                {
                    returnVal = (((string)a.data).CompareTo((string)b.data) > 0);
                }
            }
            catch
            {
                returnVal = false;
            }

            return (returnVal);
        }

        public static bool operator >=(BTree a, BTree b)
        {
            bool returnVal = false;

            try
            {
                if (a.data.GetType() == typeof(int))
                {
                    returnVal = ((int)a.data >= (int)b.data);
                }

                if (a.data.GetType() == typeof(string))
                {
                    returnVal = (((string)a.data).CompareTo((string)b.data) >= 0);
                }
            }
            catch
            {
                returnVal = false;
            }

            return (returnVal);
        }

        public static bool operator <=(BTree a, BTree b)
        {
            bool returnVal = false;

            try
            {
                if (a.data.GetType() == typeof(int))
                {
                    returnVal = ((int)a.data <= (int)b.data);
                }

                if (a.data.GetType() == typeof(string))
                {
                    returnVal = (((string)a.data).CompareTo((string)b.data) <= 0);
                }
            }
            catch
            {
                returnVal = false;
            }

            return (returnVal);
        }
       
        public BTree(object nData, BTree root, bool isData = true)
        {
            this.ltChild = null;
            this.gteChild = null;
            this.data = nData;
            this.isData = isData;

            this.id = nLastCntr;
            ++nLastCntr;

            form1.richTextBox1.Text += nData.ToString() + " ";

            if (root != null)
            {
                AddChildNode(this, root);
            }
        }
        public static void AddChildNode(BTree newNode, BTree treeNode)
        {
            if(newNode >= treeNode)
            {
                if(newNode.gteChild == null)
                {

                }
                else
                {

                }
            }
            else
            {
                if(newNode.ltChild == null)
                {


                }
                else
                {
                }
            }
        }

        public static BTree DeleteNode(BTree nodeToDelete, BTree treeNode)
        {
            if (treeNode == null)
            {
                return treeNode;
            }


            if (nodeToDelete < treeNode)
            {
                treeNode.ltChild = DeleteNode(nodeToDelete, treeNode.ltChild);
            }
            else if (nodeToDelete > treeNode)
            {
                treeNode.gteChild = DeleteNode(nodeToDelete, treeNode.gteChild);
            }
            else
            {
                if (treeNode.ltChild == null)
                {
                    return treeNode.gteChild;
                }
                else if (treeNode.gteChild == null)
                {
                    return treeNode.ltChild;
                }

                BTree nextValNode = treeNode.gteChild;

                while (nextValNode != null)
                {

                    treeNode.data = nextValNode.data;

                    nextValNode = nextValNode.ltChild;
                }

                nodeToDelete.data = treeNode.data;
                DeleteNode(nodeToDelete, treeNode.gteChild);
            }

            return treeNode;
        }


        public static void TraverseAscending(BTree node)
        {
            if (node != null)
            {
                TraverseAscending(node.ltChild);

                if (node.isData)
                {
                    form1.richTextBox1.Text += " " + node.data.ToString();
                }

                TraverseAscending(node.gteChild);
            }
        }

        public static void TraverseDescending(BTree node)
        {
            if (node != null)
            {
            }
        }
    }
}
