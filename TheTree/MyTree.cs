using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TheTree
{

    public class Node
    {
        public Node parent;
        public Node left;
        public Node right;
        public int val;

        public Node(int val)
        {
            this.val = val;
            this.left = null;
            this.right = null;
            this.parent = null;
        }

        public Node()
        {
            this.val = 0;
            this.left = null;
            this.right = null;
            this.parent = null;
        }
    }
    public class MyTree
    {
        Node top;
        int count = 0, countLeaves = 0;
        public static Spiskii.MyList listOfLeaves = new Spiskii.MyList();
        public static StreamWriter sw = File.CreateText("treeGraphvis.gv");
        //public static MyQueue queueNode = new MyQueue(); 
        public MyTree()
        {
            top = null;
        }

        public MyTree(int val)
        {
            top = new Node(val);
        }

        /// <summary>
        /// Количество элементов в дереве
        /// </summary>
        public int Count
        {
            get
            {
                if (count <= 0)
                    throw new Exception("The tree is empty");
                else return count;
            }
        }

        /// <summary>
        /// Метод добавления элементов в дерево
        /// </summary>
        /// <param name="val"></param>
        public void Add(int val)
        {
            bool added;

            if (top == null)
            {
                Node NewNode = new Node(val);
                top = NewNode;
                count++;
                return;
            }

            Node currentNode = top;
            added = false;
            Random rnd = new Random();
            int n = 10;

            do
            {
                n = rnd.Next(0, 1);
                // if (val < currentNode.val)
                //{
                if ((currentNode.left == null) || (currentNode.right == null))
                {
                    if (currentNode.left == null)
                    {
                        Node NewNode = new Node(val);
                        currentNode.left = NewNode;
                        sw.WriteLine(currentNode.val + "->" + currentNode.left.val + "[color=red]" + ";");
                        count++;
                        added = true;
                        return;
                    }
                    if (currentNode.right == null)
                    {
                        Node NewNode = new Node(val);
                        currentNode.right = NewNode;
                        sw.WriteLine(currentNode.val + "->" + currentNode.right.val + "[color=red]" + ";");
                        count++;
                        added = true;
                        return;
                    }
                }
                else
                {
                    if ((currentNode.right != top) && (currentNode.left != top))
                    {
                        if ((currentNode.left != currentNode) && (currentNode.right != currentNode))
                        {
                            if (currentNode.left != currentNode.right)
                            {
                                switch (n)
                                {
                                    case 0:
                                        currentNode = currentNode.left;
                                        break;
                                    case 1: currentNode = currentNode.right;
                                        break;
                                }
                            }
                        }
                    }
                }
                n = 10;
                //}
            } while (!added);

        }

        public void beginOfFile()
        {
            sw.WriteLine("digraph {");
        }
        int MinElement(Spiskii.MyList a)
        {
            int min = a[0];

            for (int i = 0; i < a.Count; i++)
            {
                if (a[i] < min)
                {
                    min = a[i];
                }
            }
            return min;
        }

        public void leavesToList(Node currentNode) //Вертикальный обход СДЕЛАТЬ СО СВОИМ СПИСКОМ!
        {

            if ((currentNode.left != null) || (currentNode.right != null))
            {
                if (currentNode.left != null)
                {
                    leavesToList(currentNode.left);
                }

                if (currentNode.right != null)
                {
                    leavesToList(currentNode.right);
                }
            }

            else
            {
                listOfLeaves.Add(currentNode.val);
                countLeaves++;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Leave {0}: {1}", countLeaves, currentNode.val);
            }

        }
             
      /*  public void leavesToListHorizonal(Node currentNode) 
        {
            Console.ForegroundColor = ConsoleColor.Red;
            queueNode.InQueue(top);
            do
            {
                if (currentNode.left != null)
                {
                    queueNode.InQueue(currentNode.left.val);
                    Console.WriteLine(currentNode.left.val);
                }
                if (currentNode.right != null) 
                {
                    queueNode.InQueue(currentNode.right.val);
                    Console.WriteLine(currentNode.right.val);
                }

                if (!queueNode.IsEmpty) currentNode.val = queueNode.OutQueue();
                
            } while (!queueNode.IsEmpty);          
        }*/
        /// <summary>
        /// Метод, возвращающий минимальный элемент среди листьев дерева
        /// </summary>
        public void doGetMinElRecur()
        {
            int min = 0;

            if (top != null)
            {
                Console.WriteLine();
                leavesToList(top);                
                sw.Write("}");
                min = MinElement(listOfLeaves);

                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("\nThe amount of leaves is: " + countLeaves);
                Console.Write("\nMinimal element among leaves is: {0}", min);

               // leavesToListHorizonal(top);              
                
            }
            else { throw new Exception("The tree is empty"); }
            sw.Close();
        }
    }
}







 