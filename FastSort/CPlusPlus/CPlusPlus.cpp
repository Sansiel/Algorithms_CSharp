#include <iostream>
using namespace std;
//node declaration for doubly linked list
struct Node {
	int data;
	struct Node *prev, *next;
};

Node* newNode(int val)
{
	Node* temp = new Node;
	temp->data = val;
	temp->prev = temp->next = nullptr;
	return temp;
}
void displayList(Node* head)
{
	while (head->next != nullptr) {
		cout << head->data << " <==> ";
		head = head->next;
	}
	cout << head->data << endl;
}

// Insert a new node at the head of the list
void insert(Node** head, int node_data)
{
	Node* temp = newNode(node_data);
	temp->next = *head;
	(*head)->prev = temp;
	(*head) = temp;
}
void append(Node** head, int node_data)
{
	Node* temp = newNode(node_data);
	Node* tmp = (*head);
	while (tmp->next!=NULL)
	{
		tmp = tmp->next;
	}
	temp->prev = tmp;
	tmp->next = temp;
}



int main()
{
	Node* headNode = newNode(5);
	insert(&headNode, 4);
	insert(&headNode, 3);
	insert(&headNode, 2);
	insert(&headNode, 1);
	append(&headNode, 6);
	cout << "Original doubly linked list: " << endl;
	displayList(headNode);


	return 0;
}