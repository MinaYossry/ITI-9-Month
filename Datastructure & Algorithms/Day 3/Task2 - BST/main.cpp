#include <iostream>
#include <windows.h>
#include <conio.h>
#include <vector>

using namespace std;


struct Node {
  int data;
  Node *left, *right;
  Node(int _data) {
    data = _data;
    left = right = NULL;
  }
};

void Delete(Node* &root, int key);

int height(Node* root)
{
    if (root)
        return 1 + max(height(root->left), height(root->right));
    return 0;
}

bool isBalanced(Node*root)
{
    if (!root)
        return true;

    int leftHeight = height(root->left);
    int rightHeight = height(root->right);

    return (abs(leftHeight - rightHeight) && isBalanced(root->left) && isBalanced(root->right));
}


void TreeToArray(vector<Node*> &nodes, Node* root)
{
    if (!root)
        return;

    TreeToArray(nodes, root->left);
    nodes.push_back(root);
    TreeToArray(nodes, root->right);

}
Node* ArrayToTree(const vector<Node*> &nodes, int start, int end)
{
    if (start > end)
        return NULL;

    int mid = (start + end) / 2;
    Node* root = nodes[mid];

    root->left = ArrayToTree(nodes, start, mid - 1);
    root->right = ArrayToTree(nodes, mid + 1, end);

    return root;
}

Node* balanceTree(Node* root)
{
    vector<Node*> nodes;
    TreeToArray(nodes, root);
    int n = nodes.size();
    return ArrayToTree(nodes, 0, n - 1);
}


Node* new_node()
{
    int n;
    cout << "Enter new number: ";
    cin >> n;

    Node *nd = new Node(n);

    return nd;
}


int count_nodes(Node* root)
{
    if (root)
        return 1 + count_nodes(root->left) + count_nodes(root->right);
    return 0;
}

Node* tSearch(Node* root, int key)
{
    if (!root)
        return NULL;

    if (root->data == key)
        return root;
    else if (key > root->data)
        return tSearch(root->right, key);
    else
        return tSearch(root->left, key);
}

void TreeTraverse(Node* root)
{
    if (!root)
        return;

    cout << root->data << " ";
    TreeTraverse(root->left);
    TreeTraverse(root->right);
}

void insertRef(Node* &root, Node* _node)
{
    if (!root)
        root = _node;

    else if (_node->data > root->data)
        insertRef(root->right, _node);
    else if (_node->data < root->data)
        insertRef(root->left, _node);
    else
        cout << "Node already exist" << endl;

    root = isBalanced(root) ? root : balanceTree(root);
}

void insertTwoP(Node* &pRoot, Node* &pLeaf, Node* _node)
{
    if (!pLeaf)
    {
        if (!pRoot)
            pRoot = _node;
        else
        {
            if (_node->data > pRoot->data)
                pRoot->right = _node;
            else if (_node->data < pRoot->data)
                pRoot->left = _node;
            else
                cout << "Node already exist" << endl;
        }
    }
    else if (_node->data > pLeaf->data)
        insertTwoP(pLeaf, pLeaf->right, _node);
    else if (_node->data < pLeaf->data)
        insertTwoP(pLeaf, pLeaf->left, _node);
    else
        cout << "Node already exist" << endl;

    pRoot = isBalanced(pRoot) ? pRoot : balanceTree(pRoot);
}

Node* GetMin(Node* root)
{
    while (root->left)
        root = root->left;

    return root;
}

void DeleteNode(Node* &node)
{
    Node* temp = node;

    if (!node->left)
    {
        node = node->right;
        cout << temp->data << " Deleted" << endl;
        delete temp;
    }
    else if (!node->right)
    {
        node = node->left;
        cout << temp->data << " Deleted" << endl;
        delete temp;
    }
    else
    {
        Node* MinNode = GetMin(node->right);
        node->data = MinNode->data;
        Delete(node->right, MinNode->data);
    }
}

void Delete(Node* &root, int key)
{
    if (!root)
    {
        cout << "Key not found" << endl;
        return;
    }

    if (key > root->data)
        Delete(root->right, key);
    else if (key < root->data)
        Delete(root->left, key);
    else
        DeleteNode(root);
}




int main()
{
    Node *treeRoot = NULL;


    int input = 0;
    bool flag = true;
    while (flag)
    {
    system("cls");
    cout << "Task 2 - BST" << endl;
    cout << "1- Count Nodes" << endl;
    cout << "2- Search" << endl;
    cout << "3- TreeTraverse" << endl;
    cout << "4- Insert Node By Ref" << endl;
    cout << "5- Insert Node By Two Pointers" << endl;
    cout << "6- Delete" << endl;
    cout << "7- Exit" << endl;

        do
        {
            cout << "Enter your choice: ";
            cin >> input;
        }
        while (input < 1 || input > 7);


        switch(input)
        {
        case 1:
            system("cls");
            cout << count_nodes(treeRoot) << endl;
            _getch();
            break;

        case 2:
            system("cls");
            cout << "Enter Value: ";
            cin >> input;
            if (tSearch(treeRoot, input))
                cout << endl << input << " Found" << endl;
            else
                cout << endl << input << " Not Found" << endl;

            _getch();
            break;
        case 3:
            system("cls");
            TreeTraverse(treeRoot);
            _getch();
            break;
        case 4:
            system("cls");
            insertRef(treeRoot, new_node());
            _getch();
            break;
        case 5:
            system("cls");
            insertTwoP(treeRoot, treeRoot, new_node());
            _getch();
            break;
        case 6:
            system("cls");
            cout << "Enter key to delete: ";
            cin >> input;
            cout << endl;
            Delete(treeRoot, input);
            _getch();
            break;
        case 7:
            flag = false;
            break;
        }
    }


    return 0;
}

