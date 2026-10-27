using System;

class CircularList
{
    // Node structure
    private class Node
    {
        public int Value;
        public Node Next;

        public Node(int value)
        {
            Value = value;
            Next = null!;
        }
    }

    private Node? tail = null;

    // Constructor
    public CircularList()
    {
        tail = null;
    }

    // Insert at the end
    public void InsertEnd(int value)
    {
        Node newNode = new Node(value);

        if (tail == null)
        {
            tail = newNode;
            tail.Next = tail;
            return;
        }

        newNode.Next = tail.Next;
        tail.Next = newNode;
        tail = newNode;
    }

    // Insert at the beginning
    public void InsertBegin(int value)
    {
        Node newNode = new Node(value);

        if (tail == null)
        {
            tail = newNode;
            tail.Next = tail;
            return;
        }

        newNode.Next = tail.Next;
        tail.Next = newNode;
    }

    // Insert in ascending order
    public void InsertSorted(int value)
    {
        Node newNode = new Node(value);

        if (tail == null)
        {
            tail = newNode;
            tail.Next = tail;
            return;
        }

        Node head = tail.Next;

        if (value <= head.Value)
        {
            newNode.Next = head;
            tail.Next = newNode;
            return;
        }

        if (value >= tail.Value)
        {
            newNode.Next = head;
            tail.Next = newNode;
            tail = newNode;
            return;
        }

        Node current = head;

        while (current.Next != head &&
               current.Next.Value < value)
        {
            current = current.Next;
        }

        newNode.Next = current.Next;
        current.Next = newNode;
    }

    // Search for a value
    public bool Search(int value)
    {
        if (tail == null)
            return false;

        Node head = tail.Next;
        Node current = head;

        do
        {
            if (current.Value == value)
                return true;

            current = current.Next;
        }
        while (current != head);

        return false;
    }

    // Reverse the list
    public void Reverse()
    {
        if (tail == null || tail.Next == tail)
            return;

        Node head = tail.Next;
        Node previous = tail;
        Node current = head;

        do
        {
            Node next = current.Next;
            current.Next = previous;
            previous = current;
            current = next;
        }
        while (current != head);

        tail = head;
    }

    // Delete from the beginning
    public bool DeleteBeginning()
    {
        if (tail == null)
            return false;

        Node head = tail.Next;

        if (head == tail)
        {
            tail = null;
            return true;
        }

        tail.Next = head.Next;
        return true;
    }

    // Delete from the end
    public bool DeleteEnd()
    {
        if (tail == null)
            return false;

        Node head = tail.Next;

        if (head == tail)
        {
            tail = null;
            return true;
        }

        Node current = head;

        while (current.Next != tail)
        {
            current = current.Next;
        }

        current.Next = head;
        tail = current;

        return true;
    }

    // Delete a specific value
    public bool DeleteValue(int value)
    {
        if (tail == null)
            return false;

        Node head = tail.Next;
        Node current = head;
        Node previous = tail;

        do
        {
            if (current.Value == value)
            {
                if (current == tail && current == head)
                {
                    tail = null;
                }
                else
                {
                    previous.Next = current.Next;

                    if (current == tail)
                        tail = previous;
                }

                return true;
            }

            previous = current;
            current = current.Next;
        }
        while (current != head);

        return false;
    }

    // Display the list
    public void Display()
    {
        if (tail == null)
        {
            Console.WriteLine("List is empty.");
            return;
        }

        Node head = tail.Next;
        Node current = head;

        do
        {
            Console.Write(current.Value + " -> ");
            current = current.Next;
        }
        while (current != head);

        Console.WriteLine("(back to head)");
    }

    // Clear the list
    public void Clear()
    {
        tail = null;
    }
}

// Main program
class Program
{
    static void Main()
    {
        CircularList list = new CircularList();
        int choice, value;

        do
        {
            Console.WriteLine("\n=== CIRCULAR LINKED LIST ===");
            Console.WriteLine("1. Insert at end");
            Console.WriteLine("2. Insert at beginning");
            Console.WriteLine("3. Sorted insertion");
            Console.WriteLine("4. Search");
            Console.WriteLine("5. Delete a value");
            Console.WriteLine("6. Delete from beginning");
            Console.WriteLine("7. Delete from end");
            Console.WriteLine("8. Reverse list");
            Console.WriteLine("9. Display list");
            Console.WriteLine("10. Clear list");
            Console.WriteLine("11. Exit");
            Console.Write("Enter your choice: ");

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Enter a valid number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.Write("Enter value: ");
                    if (int.TryParse(Console.ReadLine(), out value))
                    {
                        list.InsertEnd(value);
                        Console.WriteLine("Inserted successfully.");
                    }
                    else
                        Console.WriteLine("Invalid value.");
                    break;

                case 2:
                    Console.Write("Enter value: ");
                    if (int.TryParse(Console.ReadLine(), out value))
                    {
                        list.InsertBegin(value);
                        Console.WriteLine("Inserted successfully.");
                    }
                    else
                        Console.WriteLine("Invalid value.");
                    break;

                case 3:
                    Console.Write("Enter value: ");
                    if (int.TryParse(Console.ReadLine(), out value))
                    {
                        list.InsertSorted(value);
                        Console.WriteLine("Inserted in sorted order.");
                    }
                    else
                        Console.WriteLine("Invalid value.");
                    break;

                case 4:
                    Console.Write("Enter value to search: ");
                    if (int.TryParse(Console.ReadLine(), out value))
                    {
                        Console.WriteLine(list.Search(value)
                            ? "Value found."
                            : "Value not found.");
                    }
                    else
                        Console.WriteLine("Invalid value.");
                    break;

                case 5:
                    Console.Write("Enter value to delete: ");
                    if (int.TryParse(Console.ReadLine(), out value))
                    {
                        Console.WriteLine(list.DeleteValue(value)
                            ? "Value deleted."
                            : "Value not found.");
                    }
                    else
                        Console.WriteLine("Invalid value.");
                    break;

                case 6:
                    Console.WriteLine(list.DeleteBeginning()
                        ? "First node deleted."
                        : "List is empty.");
                    break;

                case 7:
                    Console.WriteLine(list.DeleteEnd()
                        ? "Last node deleted."
                        : "List is empty.");
                    break;

                case 8:
                    list.Reverse();
                    Console.WriteLine("List reversed.");
                    break;

                case 9:
                    list.Display();
                    break;

                case 10:
                    list.Clear();
                    Console.WriteLine("List cleared.");
                    break;

                case 11:
                    Console.WriteLine("Program ended.");
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

        } while (choice != 11);
    }
}