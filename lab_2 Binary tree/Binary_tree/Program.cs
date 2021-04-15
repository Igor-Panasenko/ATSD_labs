using System;



namespace Binary_tree
{
    class Node<T> where T : IComparable {
        public T Data;
      
        public Node<T> Left = null;
        public Node<T> Right = null;


        public Node(T data){
            this.Data = data;
            
            }
        public Node() { }
    }

    class Binary_Tree<T> where T: IComparable
    {
        public Node<T> Root { get; set; } = null;
        private int number_elements = 0;
        public int Number_elements { get { return number_elements; } set { number_elements = value; } }
        public Binary_Tree()
        {

        }
        public Binary_Tree(T data)
        {
            this.Number_elements++;
            Root = new Node<T>(data);
        }

        public void Insert(T data)
        {
            Node<T> new_node = new Node<T>(data);
            if (this.Root == null)
            {
                this.Number_elements++;
                this.Root = new_node;
            }
            else
            {
                Root = InsertRec(this.Root, new_node);
            }
        }
        private Node<T> InsertRec(Node<T> current, Node<T> new_node)
        {
            if (current == null)
            {
                current = new_node;
                return current;
            }
            if (current.Data.CompareTo(new_node.Data) > 0)
            {
                current.Left = InsertRec(current.Left, new_node);
                current = Balance_Tree(current);
                
            }
            else
            {
                if (current.Data.CompareTo(new_node.Data) < 0)
                {
                    current.Right = InsertRec(current.Right, new_node);
                    current = Balance_Tree(current);
                }
            }
            return current;
        }

        public bool IsEmpty()
        {
            if (this.Root == null)
            {
                return true;
            }
            else { return false; }
        }

        public bool IsFull()
        {
            Console.WriteLine("Binary_tree tree can not be full");
            return false;
        }

        public void Preorder()
        {
            Console.WriteLine("Pre order traversal of tree: ");
            rec_preorder(this.Root);
        }
        private void rec_preorder(Node<T> node) {
            if (node == null)
            {
                return;
            }
         
            Console.Write(node.Data + ", ");
            rec_preorder(node.Left);
            rec_preorder(node.Right);
        }

        public void In_order()
        {
            Console.WriteLine("In order traversal of tree: ");
            rec_inorder(this.Root);
        }
        private void rec_inorder(Node<T> node)
        {
            if (node == null)
            {
                return;
            }
            rec_inorder(node.Left);
            Console.Write(node.Data + ", ");
            rec_inorder(node.Right);
        }

        public void Post_order()
        {
            Console.WriteLine("Post order traversal of tree: ");
            rec_postorder(this.Root);
        }

        private void rec_postorder(Node<T> node)
        {
            if (node == null)
            {
                return;
            }
            rec_postorder(node.Left);
            rec_postorder(node.Right);
            Console.Write(node.Data+", ");
        }

        public int Get_Size()
        {
            return recSize(this.Root);

        }

        private int recSize(Node<T> node)
        {

            if (node == null)
            {
                return 0;
            }
                return recSize(node.Right) + recSize(node.Left) + 1;
            
        }

        private int max(int l, int r)
        {
            return l > r ? l : r;
        }
        public int GetHeight(Node<T> node)
        {
            int height = 0;
            if (node != null)
            {
                int l = GetHeight(node.Left);
                int r = GetHeight(node.Right);
                int m = max(l, r);
                height = m + 1;
            }
            return height;
        }

        public T Delete(T value)
        {
            Node<T> res = Rec_Delete(this.Root, value);
            return res.Data;

        } 
        private Node<T> Rec_Delete(Node<T> current, T value)
        {
            Node<T> parent;
            if (current == null)
            {
                return null;
            }
            else
            {
                if (value.CompareTo(current.Data) < 0)
                {
                    current.Left = Rec_Delete(current.Left, value);
                    if (balance_factor(current) == -2)
                    {
                        if (balance_factor(current.Right) <= 0)
                        {
                            current = Rotate_FullR(current);
                        }
                        else
                        {
                            current = Rotate_RL(current);
                        }
                    }
                }
                else 
                    if(value.CompareTo(current.Data) > 0)
                {
                    current.Right = Rec_Delete(current.Right, value);
                    if (balance_factor(current) == 2)
                    {
                        if (balance_factor(current.Left) >= 0)
                        {
                            current = Rotate_FullL(current);
                        }
                        else
                        {
                            current = Rotate_LR(current);
                        }
                    }
                }
                else
                {
                    if (current.Right != null)
                    {
                        parent = current.Right;
                        while (parent.Left != null)
                        {
                            parent = parent.Left;
                        }
                        current.Data = parent.Data;
                        current.Right = Rec_Delete(current.Right, parent.Data);
                        if (balance_factor(current)== 2){
                            if (balance_factor(current.Left) >= 0)
                            {
                                current = Rotate_FullL(current);
                            }
                            else
                            {
                                current = Rotate_LR(current);
                            }
                        }
                    }
                    else
                    {
                        return current.Left;
                    }
                }    
            }
            return current;
        }

        public void Find(T key)
        {
            if (rec_find(key, Root) != null)
            {
                if (rec_find(key, Root).Data.CompareTo(key) == 0)
                {
                    Console.WriteLine("{0} was found!", key);
                }
                else
                {
                    Console.WriteLine("Nothing found!");
                }
            }
            else
            {
                Console.WriteLine("Nothing found!");
            }
        }

        private Node<T> rec_find (T target, Node<T> current)
        {
            if (current != null)
            {
                if (target.CompareTo(current.Data) < 0)
                {
                    if (target.CompareTo(current.Data) == 0)
                    {
                        return current;
                    }
                    else
                    {
                        return rec_find(target, current.Left);
                    }
                }
                else
                {
                    if (target.CompareTo(current.Data) == 0)
                    {
                        return current;
                    }
                    else
                    {
                        return rec_find(target, current.Right);
                    }
                }
            }
            else
            {
                return null;
            }
        }

        public void Print_Sorted()
        {
            Node < T > node= this.Root;
            string str = "";
            rec_forSorted(node,ref str);
            Console.WriteLine(str);
            string[] arrStr = str.Split(",");
            string[] right_arr = new string[arrStr.Length - 1];
            for (int i=0; i<right_arr.Length; i++)
            {
                right_arr[i] = arrStr[i];
            }
            right_arr= sort_ascending(right_arr);
            print_asc(right_arr);
            print_desc(right_arr);
        }

        private void rec_forSorted(Node<T> node,ref string str)
        {
            if (node == null)
            {
                return;
            }
            str = str+node.Data + ",";
            rec_forSorted(node.Left,ref str);
            rec_forSorted(node.Right, ref str);
        }

        private string[] sort_ascending(string[] arr)
        {
            for(int i=0; i<arr.Length; i++)
            {
                for(int j=i; j< arr.Length; j++)
                {
                    if (arr[i].CompareTo(arr[j])>0)
                    {
                        string ch = arr[i];
                        arr[i] = arr[j];
                        arr[j] = ch;
                    }
                }
            }
            return arr;
        }

        private void print_asc(string[] arr)
        {
            Console.WriteLine();
            Console.WriteLine("tree keys sorted in ascending order: ");
            for (int i=0; i<arr.Length; i++)
            {
                Console.Write(arr[i]+", ");
            }
            Console.WriteLine();
        }

        private void print_desc(string[] arr)
        {
            Console.WriteLine();
            Console.WriteLine("tree keys sorted in descending order: ");
            for (int i = arr.Length-1; i >=0; i--)
            {
                Console.Write(arr[i]+", ");
            }
            Console.WriteLine();

        }
       

        private Node<T> Balance_Tree(Node<T> node)
        {
            int balanced = balance_factor(node);
            if (balanced > 1)
            {
                if (balance_factor(node.Left) > 0)
                {
                    node = Rotate_FullL(node);
                }
                else
                {
                    node = Rotate_LR(node);
                }
            }
            else
                if (balanced<-1)
            {
                if (balance_factor(node.Right) > 0)
                {
                    node = Rotate_RL(node);
                }
                else
                {
                    node = Rotate_FullR(node);
                }
            }
            return node;
        }

        private int balance_factor(Node<T> current)
        {
            int l = GetHeight(current.Left);
            int r = GetHeight(current.Right);
            int b_factor = l - r;
            return b_factor;
        }
        private Node<T> Rotate_FullR(Node<T> parent)
        {
            Node<T> pivot = parent.Right;
            parent.Right = pivot.Left;
            pivot.Left = parent;
            return pivot;
        }
        private Node<T> Rotate_FullL(Node<T> parent)
        {
            Node<T> pivot = parent.Left;
            parent.Left = pivot.Right;
            pivot.Right = parent;
            return pivot;
        }
        private Node<T> Rotate_LR(Node<T> parent)
        {
            Node<T> pivot = parent.Left;
            parent.Left = Rotate_FullR(pivot);
            return Rotate_FullL(parent);
        }
        private Node<T> Rotate_RL(Node<T> parent)
        {
            Node<T> pivot = parent.Right;
            parent.Right = Rotate_FullL(pivot);
            return Rotate_FullR(parent);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Binary_Tree<int> Tree_1 = new Binary_Tree<int>(45);
            Tree_1.Insert(69);
            Tree_1.Insert(44);
            Tree_1.Insert(10);
            Tree_1.Insert(55);
            Tree_1.Insert(66);
            Tree_1.Insert(25);
            Tree_1.Insert(77);
            Tree_1.Insert(13);
            Tree_1.Insert(88);
            Tree_1.Insert(99);
           
            Binary_Tree<int> Tree_2 = new Binary_Tree<int>();
            Console.WriteLine(Tree_2.IsEmpty());
           

            Tree_1.Preorder();
            Console.WriteLine();
            Tree_1.In_order();
            Console.WriteLine();
            Tree_1.Post_order();
            Console.WriteLine();
            Tree_1.Delete(66);
            Tree_1.Preorder();
            Tree_1.Find(10);
            Tree_1.Find(66);
            Tree_1.Print_Sorted();

            /*
            Console.WriteLine(Tree_1.Get_Size());
            Console.WriteLine(Tree_2.Get_Size());
            Console.WriteLine(Tree_1.GetHeight(Tree_1.Root));
            Console.WriteLine(Tree_1.GetHeight(Tree_2.Root));      
          */

        }
    }
}
