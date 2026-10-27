#include <iostream>
#include <stdexcept>
#include <limits>
using namespace std;

// Node structure
struct Node {
    int data;
    Node* next;

    Node(int val) : data(val), next(nullptr) {}
};

// Circular Linked List class
class CircularLinkedList {
private:
    Node* head;

public:
    // Constructor
    CircularLinkedList() : head(nullptr) {}

    // Insert at the end
    void insertEnd(int value) {
        Node* newNode = new Node(value);

        if (!head) {
            head = newNode;
            head->next = head;
            return;
        }

        Node* temp = head;
        while (temp->next != head) {
            temp = temp->next;
        }

        temp->next = newNode;
        newNode->next = head;
    }

    // Insert at the beginning
    void insertBegin(int value) {
        Node* newNode = new Node(value);

        if (!head) {
            head = newNode;
            head->next = head;
            return;
        }

        Node* temp = head;
        while (temp->next != head) {
            temp = temp->next;
        }

        newNode->next = head;
        temp->next = newNode;
        head = newNode;
    }

    // Insert in ascending order
    void insertSorted(int value) {
        Node* newNode = new Node(value);

        if (!head) {
            head = newNode;
            head->next = head;
            return;
        }

        if (value <= head->data) {
            Node* temp = head;
            while (temp->next != head) {
                temp = temp->next;
            }

            newNode->next = head;
            temp->next = newNode;
            head = newNode;
            return;
        }

        Node* temp = head;
        while (temp->next != head &&
               temp->next->data < value) {
            temp = temp->next;
        }

        newNode->next = temp->next;
        temp->next = newNode;
    }

    // Search for a value
    bool search(int value) const {
        if (!head) {
            return false;
        }

        Node* temp = head;
        do {
            if (temp->data == value) {
                return true;
            }
            temp = temp->next;
        } while (temp != head);

        return false;
    }

    // Reverse the list
    void reverse() {
        if (!head || head->next == head) {
            return;
        }

        Node* oldHead = head;
        Node* prev = nullptr;
        Node* current = head;
        Node* next = nullptr;

        do {
            next = current->next;
            current->next = prev;
            prev = current;
            current = next;
        } while (current != oldHead);

        oldHead->next = prev;
        head = prev;
    }

    // Delete from the beginning
    bool deleteBeginning() {
        if (!head) {
            return false;
        }

        if (head->next == head) {
            delete head;
            head = nullptr;
            return true;
        }

        Node* temp = head;
        Node* last = head;

        while (last->next != head) {
            last = last->next;
        }

        head = head->next;
        last->next = head;
        delete temp;

        return true;
    }

    // Delete from the end
    bool deleteEnd() {
        if (!head) {
            return false;
        }

        if (head->next == head) {
            delete head;
            head = nullptr;
            return true;
        }

        Node* temp = head;

        while (temp->next->next != head) {
            temp = temp->next;
        }

        Node* last = temp->next;
        temp->next = head;
        delete last;

        return true;
    }

    // Delete a particular value
    bool deleteValue(int value) {
        if (!head) {
            return false;
        }

        if (head->data == value) {
            return deleteBeginning();
        }

        Node* prev = head;
        Node* current = head->next;

        while (current != head &&
               current->data != value) {
            prev = current;
            current = current->next;
        }

        if (current == head) {
            return false;
        }

        prev->next = current->next;
        delete current;

        return true;
    }

    // Display the list
    void display() const {
        if (!head) {
            cout << "List is empty." << endl;
            return;
        }

        Node* temp = head;

        do {
            cout << temp->data << " -> ";
            temp = temp->next;
        } while (temp != head);

        cout << "(back to head)" << endl;
    }

    // Memory cleanup
    ~CircularLinkedList() {
        if (!head) {
            return;
        }

        Node* current = head->next;

        while (current != head) {
            Node* next = current->next;
            delete current;
            current = next;
        }

        delete head;
        head = nullptr;
    }
};

// Read and validate integer input
int readInt(const string& prompt) {
    int value;

    while (true) {
        cout << prompt;

        if (cin >> value) {
            return value;
        }

        if (cin.eof()) {
            throw runtime_error("Input ended.");
        }

        cin.clear();
        cin.ignore(numeric_limits<streamsize>::max(), '\n');

        cout << "Invalid input. Enter a whole number.\n";
    }
}

// Main function
int main() {
    try {
        CircularLinkedList list;
        int choice, value;

        do {
            cout << "\n===== CIRCULAR LINKED LIST =====\n";
            cout << "1. Insert at the end\n";
            cout << "2. Insert at the beginning\n";
            cout << "3. Sorted insertion\n";
            cout << "4. Search for a value\n";
            cout << "5. Delete a value\n";
            cout << "6. Delete from beginning\n";
            cout << "7. Delete from end\n";
            cout << "8. Reverse the list\n";
            cout << "9. Display the list\n";
            cout << "10. Exit\n";

            choice = readInt("Enter your choice: ");

            switch (choice) {
                case 1:
                    value = readInt("Enter value: ");
                    list.insertEnd(value);
                    cout << "Inserted successfully.\n";
                    break;

                case 2:
                    value = readInt("Enter value: ");
                    list.insertBegin(value);
                    cout << "Inserted successfully.\n";
                    break;

                case 3:
                    value = readInt("Enter value: ");
                    list.insertSorted(value);
                    cout << "Inserted in ascending order.\n";
                    break;

                case 4:
                    value = readInt("Enter value to search: ");
                    if (list.search(value)) {
                        cout << "Value found.\n";
                    } else {
                        cout << "Value not found.\n";
                    }
                    break;

                case 5:
                    value = readInt("Enter value to delete: ");
                    if (list.deleteValue(value)) {
                        cout << "Value deleted.\n";
                    } else {
                        cout << "Value not found.\n";
                    }
                    break;

                case 6:
                    if (list.deleteBeginning()) {
                        cout << "First node deleted.\n";
                    } else {
                        cout << "List is empty.\n";
                    }
                    break;

                case 7:
                    if (list.deleteEnd()) {
                        cout << "Last node deleted.\n";
                    } else {
                        cout << "List is empty.\n";
                    }
                    break;

                case 8:
                    list.reverse();
                    cout << "List reversed.\n";
                    break;

                case 9:
                    list.display();
                    break;

                case 10:
                    cout << "Exiting program.\n";
                    break;

                default:
                    cout << "Invalid choice. Try again.\n";
            }

        } while (choice != 10);

    } catch (const exception& e) {
        cerr << "Program ended: " << e.what() << endl;
        return 1;
    }

    return 0;
}