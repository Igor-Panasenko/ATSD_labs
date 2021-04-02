using System;

namespace Lab_1_Linked__List
{
    class Node {
        protected int data;
        protected Node next;
        public int Data { get { return data; }  }
        public Node Next { get { return next; } set { next = value; } }

        public Node(int d) {
            data = d;
            next = null;
        }
    }

    class Linked_List {
        public Node head;
        public Linked_List() { }

        protected int count = 0;
        public int Count{ get{ return count; } set { count = value; } }

        public void Delete_List()
        {
            this.Count = 0;
            this.head = null;
            Console.WriteLine("List was deleted" + "\n");
        }
        public void Add_node(int new_data)
        {
            Node new_node = new Node(new_data);
            Node temp = this.head;
            if (this.head == null)
            {
                this.Count++;
                this.head = new_node;
                return;
            }
            while (true)
            {
                if (temp.Data > new_data)
                {
                    this.head = new_node;
                    new_node.Next = temp;
                    this.Count++;
                    break;
                }
                if (temp.Next == null)
                {
                    temp.Next = new_node;
                    this.Count++;
                    break;
                }
                
                if (temp.Data <= new_data && temp.Next.Data>=new_data)
                {
                    this.Count++;
                    Node peremena = temp.Next;
                    temp.Next = new_node;
                    new_node.Next = peremena;
                    break;
                }
                temp = temp.Next;

            }
        }

        public void Print_List()
        {
            Node temp = head;
            if (head == null)
            {
                Console.WriteLine("List is empty, nothing to print");
            }
            else
            {
                while (temp != null)
                {
                    Console.Write(temp.Data+", ");
                    temp = temp.Next;
                }
                Console.WriteLine();
            }
        }

        public bool Is_Full()
        {
            Console.WriteLine(" Linked list can not be full");
            return false;
        }

        public bool Is_Empty()
        {
            if (this.head != null)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public int List_Size()
        {
            return Count;
        }

        public int? Search_Item(int search_for)
        {
            Node temp = this.head;
            if (temp == null)
            {
                Console.WriteLine("it is nothing in List now");
                return null;
            }
            else
            {
                while (temp != null)
                {
                    if (temp.Data == search_for)
                    {
                        Console.WriteLine("your item " + temp.Data + " is in the list");
                        return temp.Data;
                    }
                    temp = temp.Next;
                }
                Console.WriteLine("your item " + search_for + " is not in the list");
                return null;
            }

        }

        public bool Bool_Search (int search_for)
        {
            Node temp = this.head;
            if (temp == null)
            {
                Console.WriteLine("it is nothing in List now");
                return false;
            }
            else
            {
                while (temp != null)
                {
                    if (temp.Data == search_for)
                    {
                        return true;
                    }
                    temp = temp.Next;
                }
                return false;
            }

        }

        public int? Delete_Node(int What_delete)
        {
            Node temp = this.head;
            Node prev = null;
            if (temp.Data==What_delete && temp != null)
            {
                this.head = temp.Next;
                this.Count--;
                return temp.Data;
               
            }
            else
            {
                prev = temp;
                temp = temp.Next;
            }
            while (temp != null)
            {
                if (temp.Data == What_delete)
                {
                    prev.Next = temp.Next;
                    this.Count--;
                    return temp.Data;
                }
                prev = temp;
                temp = temp.Next;
            }
            Console.WriteLine("no nodes with data in the List");
            return null;
        }

        public int Get_last()
        {
            Node temp = this.head;
            for (int i=0; i<this.count-1; i++)
            {
                temp = temp.Next;
            }
            return temp.Data;
        }

        public void Reverse()
        {
            Linked_List List_temp = new Linked_List();
            int point = this.Count - 1;
            for (int i=0; i<=point; i++)
            {
                int delete = Get_last();
                List_temp.Add_node(delete);
                this.Delete_Node(delete);
            }
            this.head = List_temp.head;
        }

        public int Sum_nodes()
        {
            Node temp = this.head;
            int Sum = 0;
            while (temp != null)
            {
                Sum += temp.Data;
                temp = temp.Next;
            }
            return Sum;
        }

        public Linked_List Get_Part(int start_from, int end_at)
        {
            Linked_List My_list = new Linked_List();
            Node temp = this.head;
            int coursor = 0;
            while (coursor != start_from)
            {
                coursor++;
                temp = temp.Next;
            } 

            for(int i= start_from; i<=end_at; i++)
            {
                My_list.Add_node(temp.Data);
                temp = temp.Next;
            }
            return My_list;
        }

        public void read()
        {
            int number = Convert.ToInt32(Console.ReadLine());
            while (number!=-10000)
            { 
                Console.WriteLine("enter new number or -10000 to end");
                number = Convert.ToInt32(Console.ReadLine());
                if (number == -10000)
                {
                    break;
                }
                this.Add_node(number);
            }
        }

    }
   

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Linked_List List_A = new Linked_List();
            List_A.read();
            List_A.Print_List();


            List_A.Add_node(34);
            List_A.Add_node(68);
            List_A.Add_node(53);
            List_A.Add_node(46);
            List_A.Add_node(90);

            List_A.Print_List();

            /*List_A.Search_Item(53);
            List_A.Search_Item(35);

            Console.WriteLine("Item 90 is in the List: " + List_A.Bool_Search(90));

            List_A.Delete_Node(53);

            Console.WriteLine("Last node in the list is: "+List_A.Get_last());
            List_A.Print_List();
            List_A.Reverse();
            List_A.Print_List();
            List_A.Delete_Node(68);
            List_A.Print_List();
            List_A.Search_Item(34);
            Console.WriteLine("Item 34 is in the list " + List_A.Bool_Search(34));
            List_A.Print_List();
            Console.WriteLine("Sum of all nodes this list equal to: "+List_A.Sum_nodes());

            List_A.Add_node(5);
            List_A.Add_node(39);
            List_A.Add_node(78);
            List_A.Add_node(45);
            List_A.Add_node(55);
            List_A.Add_node(75);
            List_A.Print_List();

            Linked_List Copy = List_A.Get_Part(2, 5);
            Copy.Print_List();
            List_A.Print_List();
             List_A.Delete_Node(34);
             List_A.Print_List();
             List_A.Delete_Node(90);
            List_A.Print_List();

             List_A.Is_Full();
             Console.WriteLine("Now Linked list empty:"+List_A.Is_Empty());
             Console.WriteLine("now in list " + List_A.List_Size() + " Items");

             List_A.Delete_List();
             Console.WriteLine("Now Linked list empty:" + List_A.Is_Empty());*/


        }
    }
}
