//Dictionary Library

#ifndef I_DICTIONARY_H
#define I_DICTIONARY_H

#include <stdio.h>
#include <stdlib.h>

#define KEY_SIZE 50

typedef struct Node {
    struct Node *next;
    struct Node *previous;
    char key[KEY_SIZE];
    void *value;
} Node;

typedef struct Dictionary {
    Node *firstNode;
    void *firstValue;
    int size;
} Dictionary;

void init           (Dictionary *dictionary);
void *get           (Dictionary *dictionary, char *key);
No *getPrevious     (Dictionary *dictionary);
void* getKeys       (Dictionary *dictionary);
void* getValues     (Dictionary *dictionary);
int put             (Dictionary *dictionary, char key[], void *value);
void remove         (Dictionary *dictionary, char key[]);
int isEmpty         (Dictionary *dictionary);
int size            (Dictionary *dictionary);

void init           (Dictionary *dictionary) {
    Node new_node = (Node) malloc(sizeof(Node));
    new_node->previous = *new_node;
    new_node->next = *new_node;
    dictionary->firstNode = *new_node;
    dictionary->size = 0;
}

void *get           (Dictionary *dictionary, char *key) {
    if (size == 0) return -1;

    Node testNode = dictionary->firstNode; 

    do {
        if (testNode->key == key)
            return testNode.value;
        else
            testNode = testNode->next;
    } while (testNode != dictionary->firstNode);

    return -1;
}

No *getPrevious     (Dictionary *dictionary, char *key) {    
    if (size == 0) return dictionary->firstNode;
    
    Node testNode = dictionary->firstNode; 

    do {
        if (testNode->next->key >= key)
            return testNode;
        else
            testNode = testNode->next;
    } while (testNode != dictionary->firstNode);

    return -1;
}

void* getKeys       (Dictionary *dictionary) {
    return dictionary->firstNode->key;
}
void* getValues     (Dictionary *dictionary) {
    return dictionary->firstValue;
}

int put             (Dictionary *dictionary, char key[], void *value) {
    Node newNode = malloc(sizeof(Node));
    Node previousNode = getPrevious(dictionary, key);

    if (key == previousNode->next->key)
        return -1;

    newNode->key = key;
    newNode->value = value;

    if (size(dictionary) == 0)
        previousNode->previous = *newNode;
    
    previousNode->next->previous = newNode;
    previousNode->next = newNode;

    return 0;
}

void remove         (Dictionary *dictionary, char key[]) {
    Node previousNode = getPrevious(dictionary, key);
    Node toBeRemovedNode = previousNode->next;
    previousNode->next = toBeRemovedNode->next;
    toBeRemovedNode->previous = previousNode;
    free(toBeRemovedNode);
    return 0;
}

int isEmpty         (Dictionary *dictionary) {
    return size(dictionary) == 0;
}

int size            (Dictionary *dictionary) {
    return size(dictionary);
}

int setFirstValue   (Dictionary *dictionary, char *key) {
    if (size > 0)
        dictionary->firstValue = get(dictionary, key);
    else 
        return -1;

    return 0;
}


#endif
