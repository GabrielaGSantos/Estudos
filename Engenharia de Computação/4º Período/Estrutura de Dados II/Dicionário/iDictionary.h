//Dictionary Library

#ifndef I_DICTIONARY_H
#define I_DICTIONARY_H

#include <stdio.h>
#include <stdlib.h>

#define KEY_SIZE 50

typedef struct No {
    struct No *next;
    char key[KEY_SIZE];
    void *value;
} No;

typedef struct Dictionary {
    No *firstKey;
    void *firstValue;
    int size;
} Dictionary;

void init           (Dictionary *dictionary);
void *get           (Dictionary *dictionary, char *key);
No *getNo           (Dictionary *dictionary);
void* getValues     (Dictionary *dictionary);
int put             (Dictionary *dictionary, char key[], void *value);
void remove         (Dictionary *dictionary, char key[]);
int isEmpty         (Dictionary *dictionary);
int size            (Dictionary *dictionary);

#endif
