#include<iostream>
#include<bits/stdc++.h>
using namespace std;

typedef struct Node
{
    int data;
    Node *left, *right;
} node_t;

void Free(node_t*root)
{
    if(root = NULL)
    return;
    Free( root -> left);
    Free (root -> right);
    Free( root);
}
int LeftOf(const int value, const node_t*root)
{
    return value < root ->data;
}
int RightOf(const int value, const node_t *root)
{
    return value > root -> data;
}

node_t *Insert(node_t*root, int value){
    if( root == NULL){
        node_t*node = (node_t*) malloc(sizeof(node_t));
        node -> left = NULL;
        node -> right = NULL;
        node ->data = value;
        return node;
    }
    if( LeftOf(value, root)) root->left =Insert(root->left, value);
    else if (RightOf(value, root)) root -> right = Insert( root -> right, value);
    return root;
}
bool Search(const node_t*root, int value)
{
    if(root == NULL) return false;
    if(root ->data == value){
        return true;
    }
    else if( LeftOf (value, root)){
        return Search(root -> right, value);
    }
    else if( RightOf(value, root)){
        return Search(root -> left, value);
    }
}
int LeftMostValue(const node_t* root){
    while( root -> left != NULL)
    root = root -> left;
    return root -> data;
}
node_t* Delete( node_t *root, int value){
    if( root == NULL) return root;
    if(LeftOf(value, root)) root -> left = Delete (root ->left, value);
    else if ( RightOf( value, root)) root -> right = Delete(root -> right, value);
    else{
        if(root -> left == NULL){
            node_t* newRoot = root -> right;
            Free ( root );
            return newRoot;
        }
        if( root -> right == NULL){
            node_t*newRoot = root -> left;
            Free(root);
            return newRoot;
        }
        root -> data = LeftMostValue(root -> right);
        root -> right = Delete( root -> right, root -> data);
    }
    return root;
}
void PreOder(node_t* root){
    if(root != NULL){
        cout << root->data << endl;
        PreOder(root -> left);
        PreOder(root ->right);
    }
}
void InOder(node_t*root){
    if(root !=NULL){
        InOder(root -> left);
        cout << root -> data;
        InOder(root -> right);
    }
}
void PostOder(node_t *root)
{
    if(root != NULL){
        PostOder(root -> left);
        PostOder(root -> right);
        cout << root ->data;
    }
}
int main()
{
    node_t* root = NULL;
    root  = Insert(root, 22);
    root  = Insert(root, 22);
    root  = Insert(root, 22);
    root  = Insert(root, 22);
    root  = Insert(root, 22);
    root  = Insert(root, 22);
    root  = Insert(root, 22);
    root  = Insert(root, 22);
    root  = Insert(root, 22);
    root  = Insert(root, 22);
    root  = Insert(root, 22);
    root  = Insert(root, 22);
    cout << " Duyet PreOder";
    PreOder(root);
    cout << " Duyet InOder";
    InOder(root);
    PostOder(root);
    Delete(root, 50);
    return 0;
}