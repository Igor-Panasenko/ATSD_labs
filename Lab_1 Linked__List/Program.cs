﻿using System;

namespace Lab_1_Linked__List
{
    class Node {
        protected int data;
        protected Node next;
        public int Data { get { return data; }  }
        public Node Next { get { return next; } set { } }

        public Node(int d) {
            data = d;
            next = null;
        }
    }

    class Linked_List {
        public Node head;
        public Linked_List() { }

        public void Delete_List()
        {
            this.head = null;
            Console.WriteLine("List was deleted" + "\n");
        }
        public void Add_node(int new_data)
        {
            Node new_node = new Node(new_data);
            if (this.head == null)
            {
                this.head = new_node;
                return;
            }
            Node temp = this.head;
            while (true)
            {
                if (temp.Next == null)
                {
                    temp.Next = new_node;
                    break;
                }
                if (temp.Data <= new_data && temp.Next.Data>=new_data)
                {
                    Node peremena = temp.Next;
                    temp.Next = new_node;
                    new_node.Next = peremena;
                }
                temp = temp.Next;

            }
        }

    }
   

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
