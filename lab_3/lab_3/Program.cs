using System;

namespace lab_3
{

    class MinHeap<T> where T : IComparable {

        public T[] HeapArray;
        private int sizeOfHeap;
        public int SizeOfHeap
        {
            get
            {
                return sizeOfHeap;
            }
            set
            {
                sizeOfHeap = value;
            }
        }
        public MinHeap (int size){
            this.HeapArray = new T [size + 1];
            this.sizeOfHeap = 0;
            Console.WriteLine("Min Heap structure was created");
            }
        public MinHeap()
        {
            this.HeapArray = new T[9];
            this.SizeOfHeap = 0;
            Console.WriteLine("Min Empty heap structure was created");
        }
        public MinHeap(T[] arr , int number_items)
        {
            this.HeapArray = new T[number_items];
            for (int i = 0; i < number_items; i++)
            {
                this.insertKey(arr[i]);
            }
        }

        public T PeekOfHeap()
        {
            if (SizeOfHeap == 0)
            {
                return default(T);
            }
            else
            {
                return HeapArray[1];
            }
        }

       private int ParentByIndex(int key)
        {
            return (key - 1) / 2;
        }

        private static void swap(ref T value_1, ref T value_2)
        {
            T temp = value_1;
            value_1 = value_2;
            value_2 = temp;
        }
        private int GetLeft(int key)
        {
            return 2 * key + 1;
        }
        private int GetRight(int key)
        {
            return 2 * key + 2;
        }

        public void insertKey (T value)
        {
            if (this.SizeOfHeap == HeapArray.Length - 1)
            {
                T[] temp = new T[HeapArray.Length * 2];
                for(int j=0; j<HeapArray.Length; j++)
                {
                    temp[j] = HeapArray[j];
                }
                this.HeapArray = temp;
                Console.WriteLine("max size of heap array increased");
            }
            int i = SizeOfHeap;
            HeapArray[i] = value;
            SizeOfHeap += 1;
            while (i != 0 && HeapArray[i].CompareTo(HeapArray[ParentByIndex(i)])<0){
                swap(ref HeapArray[i], ref HeapArray[ParentByIndex(i)]);
                i = ParentByIndex(i);
            }
        }


        public T getMin()
        {
            return HeapArray[0];
        }

        public T ExtractMin()
        {
            if (SizeOfHeap == 0)
            {
                return default(T);
            }
            if (SizeOfHeap == 1)
            {
                SizeOfHeap--;
                return HeapArray[0];
            }

            T root = HeapArray[0];
            HeapArray[0] = HeapArray[SizeOfHeap - 1];
            SizeOfHeap--;
            MinHeapify(0);
            return root;
            
        }

        public void MinHeapify(int key)
        {
            int left = GetLeft(key);
            int right = GetRight(key);

            int smallest = key;
            if (left < SizeOfHeap && HeapArray[left].CompareTo(HeapArray[smallest]) < 0)
            {
                smallest = left;
            }
            if(right<SizeOfHeap&& HeapArray[right].CompareTo(HeapArray[smallest]) < 0)
            {
                smallest = right;
            }
            if (smallest != key)
            {
                swap(ref HeapArray[key], ref HeapArray[smallest]);
                MinHeapify(smallest);
            }
        }

        public void DeleteByKey(int key)
        {
            DecreaseKey(key, default(T));
            ExtractMin();
        }

        private void IncreaseKey(int key, T new_value)
        {
            HeapArray[key] = new_value;
            MinHeapify(key);
        }
        private void DecreaseKey(int key, T new_val)
        {
            if (new_val.CompareTo(HeapArray[key]) > 0)
            {
                Console.WriteLine("new value must be less");
            }
            HeapArray[key] = new_val;
            while (key != 0 && HeapArray[key].CompareTo(HeapArray[ParentByIndex(key)]) < 0)
            {
                swap(ref HeapArray[key], ref HeapArray[ParentByIndex(key)]);
                key = ParentByIndex(key);
            }
        }
        public void changeValueOnKey(int key, T new_value)
        {
            if (HeapArray[key].CompareTo(new_value) == 0)
            {
                return;
            }
            if (HeapArray[key].CompareTo(new_value) < 0)
            {
                this.IncreaseKey(key, new_value);
                
            }
            if (HeapArray[key].CompareTo(new_value) > 0)
            {
                this.DecreaseKey(key, new_value);
            }
        }
        public void PrintHeap()
        {
            int n = SizeOfHeap;
            Console.WriteLine();
            for (int i = 0; i < n; i++)
            {
                Console.Write(HeapArray[i] + ",  ");
            }
        }
    }
    public class Max_heap<T> where T : IComparable
    {

        public T[] HeapArray;
        private int sizeOfHeap;
        public int SizeOfHeap
        {
            get
            {
                return sizeOfHeap;
            }
            set
            {
                sizeOfHeap = value;
            }
        }
        public Max_heap(int size)
        {
            this.HeapArray = new T[size + 1];
            this.sizeOfHeap = 0;
            Console.WriteLine("Max Heap structure was created");
        }
        public Max_heap()
        {
            this.HeapArray = new T[9];
            this.SizeOfHeap = 0;
            Console.WriteLine("Empty Max heap structure was created");
        }
        public Max_heap(T[] arr, int number_items)
        {
                this.HeapArray = new T[number_items];
                for (int i = 0; i < number_items; i++)
                {
                    this.insertKey(arr[i]);
                }
        }

        private int ParentByIndex(int key)
        {
            return (key - 1) / 2;
        }
        private int GetLeft(int key)
        {
            return 2 * key + 1;
        }
        private int GetRight(int key)
        {
            return 2 * key + 2;
        }
        public void insertKey(T value)
        {
            if (this.SizeOfHeap == HeapArray.Length - 1)
            {
                T[] temp = new T[HeapArray.Length * 2];
                for (int j = 0; j < HeapArray.Length; j++)
                {
                    temp[j] = HeapArray[j];
                }
                this.HeapArray = temp;
                Console.WriteLine("max size of heap array increased");
            }
            int i = SizeOfHeap;
            HeapArray[i] = value;
            SizeOfHeap += 1;
            while (i != 0 && HeapArray[i].CompareTo(HeapArray[ParentByIndex(i)]) > 0)
            {
                swap(ref HeapArray[i], ref HeapArray[ParentByIndex(i)]);
                i = ParentByIndex(i);
            }
        }
        private static void swap(ref T value_1, ref T value_2)
        {
            T temp = value_1;
            value_1 = value_2;
            value_2 = temp;
        }
        public void MaxHeapify(int key)
        {
            int left = GetLeft(key);
            int right = GetRight(key);

            int largest = key;
            if (left < SizeOfHeap && HeapArray[left].CompareTo(HeapArray[largest]) > 0)
            {
                largest = left;
            }
            if (right < SizeOfHeap && HeapArray[right].CompareTo(HeapArray[largest]) > 0)
            {
                largest = right;
            }
            if (largest != key)
            {
                swap(ref HeapArray[key], ref HeapArray[largest]);
                MaxHeapify(largest);
            }
        }
        public T ExtractMax()
        {
            if (SizeOfHeap == 0)
            {
                return default(T);
            }
            if (SizeOfHeap == 1)
            {
                SizeOfHeap--;
                return HeapArray[0];
            }

            T root = HeapArray[0];
            HeapArray[0] = HeapArray[SizeOfHeap - 1];
            SizeOfHeap--;
            MaxHeapify(0);
            return root;
        }



        public void PrintHeap()
        {
            int n = SizeOfHeap;
            Console.WriteLine();
            for (int i = 0; i < n; i++)
            {
                Console.Write(HeapArray[i] + ",  ");
            }
        }
    }

    public class Array_List<T> where T : IComparable {
        public T[] arr = new T[10];
        public int number_items;
        public int max_size = 100;

          public Array_List(){
            number_items = 0;
            }
        public void AddItem(T item)
        {
            if (number_items < arr.Length)
            {
                arr[number_items] = item;
                number_items++;
            }
            else
            {
               if(increase(ref arr))
                {
                    arr[number_items] = item;
                    number_items++;
                }
            }
        }
        private bool increase(ref T[] arr)
        {
            T[] temp_arr;
            if (arr.Length * 2 < 100)
            {
                temp_arr = new T[arr.Length * 2];
            }
            else
            {
                if (arr.Length < 100)
                {
                    temp_arr = new T[100];
                }
                else
                {
                    Console.WriteLine("array is full");
                    return false;
                }
            }
            for (int i = 0; i < arr.Length; i++)
            {
                temp_arr[i] = arr[i];
            }
            
            arr = temp_arr;
            return true;
        }
        public bool Is_Empty()
        {
            if (number_items == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Is_Full()
        {
            if (number_items == max_size)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Print_List()
        {
            Console.WriteLine();
            for(int i=0; i<number_items; i++)
            {
                Console.Write(arr[i] + ", ");
            }
            Console.WriteLine();
        }
        public int Size()
        {
            return number_items;
        }
        public void Heap_sort_desc()
        {
            Max_heap<T> heap = new Max_heap<T>(arr, number_items);
            for(int i=0; i < arr.Length; i++)
            {
                arr[i] = heap.ExtractMax();
            }
        }
        public void Heap_sort_asc()
        {
            MinHeap<T> heap = new MinHeap<T>(arr, number_items);
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = heap.ExtractMin();
            }
        }
    }

    


    public class Heap_Sort<T> where T:IComparable
    {
     public void Sort_ascending( ref T[] arr)
        {
            MinHeap<T> heap = new MinHeap<T>(arr.Length);
            for(int i=0; i<arr.Length; i++)
            {
                heap.insertKey(arr[i]);
            }
            T[] temp_arr = new T[heap.SizeOfHeap];
            for(int i=0; i<temp_arr.Length; i++)
            {
                temp_arr[i] = heap.ExtractMin();
            }
            arr = temp_arr;
        }

        public void Sort_descending(ref T [] arr)
        {
            Max_heap<T> heap = new Max_heap<T>(arr.Length);
            for(int i=0; i<arr.Length; i++)
            {
                heap.insertKey(arr[i]);
            }
            T[] temp_arr = new T[heap.SizeOfHeap];
            for(int i=0; i < arr.Length; i++)
            {
                temp_arr[i] = heap.ExtractMax();
            }
            arr = temp_arr;

        }   
    }

    class priority_node<U> :IComparable where U:IComparable  {
        private int data_priority;
        private U data;
        public int Data_priority { get { return data_priority; } }
        public U Data { get { return data; } }

        public priority_node(int priority, U data)
        {
            data_priority = priority;
            this.data = data;
        }
        public int CompareTo(object o)
        {
            priority_node<U> node = (priority_node<U>)o;
            if (node != null)
            {
                if (this.data_priority > node.data_priority)
                {
                    return 1;
                }
                if (this.data_priority < node.data_priority)
                {
                    return -1;
                }
                if (this.data_priority == node.data_priority)
                {
                    if (this.data.CompareTo(node.data) > 0)
                    {
                        return 1;
                    }
                    if (this.data.CompareTo(node.data) < 0)
                    {
                        return -1;
                    }
                }
            }
            throw new Exception("caanot be compared"); 
        }
    }

    public class Priority_Queue<U> where U:IComparable
    {
        Max_heap<priority_node<U>> heap = new Max_heap<priority_node<U>>();
         public Priority_Queue(int priority, U data)
        {
            priority_node<U> node = new priority_node<U>(priority, data);
            heap.insertKey(node);
        }
        public Priority_Queue()
        {
            
        }
        public bool Is_full()
        {
            Console.WriteLine("heap has infinite number of data in it");
            return false;
        }
        public bool Is_Empty()
        {
            if (heap.SizeOfHeap == 0)
            {
                return true;
            }
            return false;
        }

        public int Size()
        {
            return heap.SizeOfHeap;
        }

        public void Enqueue (int priority, U data)
        {
            priority_node<U> node = new priority_node<U>(priority, data);
            heap.insertKey(node);
        }

        public U Dequeue_Max()
        {
            priority_node<U> temp = heap.ExtractMax();
            return temp.Data;
        }

        public void Print_Queue()
        {
            Max_heap<priority_node<U>> temp_heap = new Max_heap<priority_node<U>>();
            int n = heap.SizeOfHeap;
            for(int i=0; i< n; i++)
            {
                temp_heap.insertKey(heap.HeapArray[i]);
            }
            string s = "";
            for(int i=0; i<n; i++)
            {
                priority_node<U> temp = temp_heap.ExtractMax();
                s += "priority: " + temp.Data_priority + " data: " + temp.Data + ", ";
            }
            Console.WriteLine(s);

        } 
    }

    class Program
    {
        static void Main(string[] args)
        {
            Array_List<int> array_List = new Array_List<int>();
            array_List.AddItem(45);
            array_List.AddItem(56);
            array_List.AddItem(78);
            array_List.AddItem(1);
            array_List.AddItem(415);
            array_List.AddItem(16);
            array_List.AddItem(34);
            array_List.Print_List();
            array_List.Heap_sort_desc();
            array_List.Print_List();
            array_List.Heap_sort_asc();
            array_List.Print_List();

            Priority_Queue<int> queue = new Priority_Queue<int>();
            Console.WriteLine(queue.Is_Empty());
            queue.Enqueue(2, 45);
            queue.Enqueue(6, 5);
            queue.Enqueue(1, 15);
            queue.Enqueue(3, 17);
            queue.Enqueue(4, 19);
            queue.Enqueue(8, 20);

            Console.WriteLine("Max priority elemet is: " +queue.Dequeue_Max());
            Console.WriteLine();
            queue.Print_Queue();
        }
    }
}
