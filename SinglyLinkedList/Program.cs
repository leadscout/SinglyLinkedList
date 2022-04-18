using System;

namespace SinglyLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            SinglyLinkedList list1 = new SinglyLinkedList();
            list1.AddLast(18);
            list1.AddLast(45);
            list1.AddLast(12);
            list1.AddLast(8);
            list1.AddLast(3);

            list1.AddFirst(90);
            list1.Print();
            list1.AddFirst(500);

            list1.Insert(5, 100);

            Console.WriteLine("-- After inserting into list1 --");
            list1.Print();

            Node deleted1 = list1.Pop();
            Node deleted2 = list1.Pop();

            Console.WriteLine("-- After 2x pop on list1 --");
            list1.Print();

            int index1 = list1.Search(16);
            int index2 = list1.Search(12);

            Console.WriteLine("Index of 16: " + index1);
            Console.WriteLine("Index of 12: " + index2);

            SinglyLinkedList list2 = new SinglyLinkedList();
            // Printing out empty list, and trying to insert at index 1 on empty list
            list2.Print();
            list2.Pop();
            int index3 = list2.Search(5);
            Console.WriteLine("Index of 5: " + index3);

            list2.Insert(1, 5);
        }
    }



    public class Node
    {
        public int data;
        public Node next;
    }


    public class SinglyLinkedList
    {
        Node head;

        // Prints out all node values.
        public void Print()
        {
            Node node = head;

            if (node == null)
            {
                Console.WriteLine("The list is empty.");
                return;
            }

            while (node.next != null)
            {
                Console.WriteLine(node.data);
                node = node.next;
            }
            Console.WriteLine(node.data);
        }

        //Adds node to the start of linked list.
        public void AddFirst(int data)
        {
            Node node = new Node();
            node.data = data;
            node.next = head;
            head = node;
        }

        //Adds node to the end of linked list.
        public void AddLast(int data)
        {
            Node node = new Node();
            node.data = data;

            if (head == null)
            {
                head = node;
            }
            else
            {
                Node nd = head;
                while (nd.next != null)
                {
                    nd = nd.next;
                }
                nd.next = node;
            }
        }

        // Removes and returns the last node of linked list.
        public Node Pop()
        {
            Node node = head;

            if (node == null)
            {
                Console.WriteLine("The list is empty.");
                return null;
            }

            int indexOfBeforeLast = GetLength()-2;
            if (indexOfBeforeLast < 0)
            {
                Console.WriteLine("Given index is greater than length of the list.");
                return null;
            }

            for (int i= 0; i < indexOfBeforeLast; i++)
            {
                node = node.next;
            }
            Node deletedNode = node.next;
            node.next = null;
            return deletedNode;
        }

        // Finds the index of data, returns -1 if no such data exists in linked list.
        public int Search(int dataToFind)
        {
            Node node = head;
            int indexCount = 0;

            if (node == null)
            {
                return -1;
            }

            while (node.next != null)
            {
                if (node.data == dataToFind)
                {
                    return indexCount;
                }
                indexCount++;
                node = node.next;
            }
            if (node.data == dataToFind)
            {
                return indexCount;
            }
            return -1;
        }

        //Inserts value at a specific index location in linked list.
        public void Insert(int index, int data)
        {
            Node node = new Node();
            Node nd = head;
            node.data = data;
            node.next = null;

            int idx = GetLength();
            if (index > idx)
            {
                Console.WriteLine("Given index is greater than length of the list.");
                return;
            }

            if (index == 0)
            {
                AddFirst(data);
            }
            else
            {
                for (int i = 0; i < index-1; i++)
                {
                    nd = nd.next;
                }
                node.next = nd.next;
                nd.next = node;
            }
        }

        //Helper function that returns length of linked list.
        public int GetLength()
        {
            Node node = head;
            int counter = 0;

            try
            {
                while (node.next != null)
                {
                    counter++;
                    node = node.next;
                }
                counter++;
            }
            catch (Exception e)
            {
                return 0;
            }
            return counter;
        }
    }

}
