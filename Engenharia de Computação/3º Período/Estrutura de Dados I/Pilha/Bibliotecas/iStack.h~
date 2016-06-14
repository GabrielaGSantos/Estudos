/**************************************************************************
 * Biblioteca de Pilha		                                              *
 *                                                                        *
 * Biblioteca com operações de pilha							 		  *
 * Data: 30/05/2016			                                              *
 * Autor: João Paulo D. Preti                                             *
 **************************************************************************/

#ifndef ISTACK_H_
#define ISTACK_H_

#define SIZE 10

typedef struct iStack {
    int elements[SIZE];
    int top;
}iStack;

void init(iStack *stack);
void push(iStack *stack, int element);
int pop(iStack *stack);
int top(iStack *stack);
int isEmpty(iStack *stack);
int isFull(iStack *stack);
int size(iStack *stack);
int capacity(iStack *stack);
void show(iStack *stack);

void init(iStack *stack) {
    stack->top = -1;
}

void push(iStack *stack, int element) {
    if (!isFull(stack)) {
        stack->top++;
        stack->elements[stack->top]=element;
    } else
        printf("Push not allowed: stack is full.\n");
}

int pop(iStack *stack) {
    if (!isEmpty(stack)) {
        stack->top--;
        return stack->elements[stack->top+1];
    } else {
        printf("Pop not allowed: stack is empty.\n");
        return -1;
    }
}

int top(iStack *stack) {
    return isEmpty(stack)?-1:stack->elements[stack->top];
}

int isEmpty(iStack *stack) {
    return stack->top==-1;
}

int isFull(iStack *stack) {
    return stack->top==SIZE-1;
}

int size(iStack *stack) {
    return stack->top+1;
}

int capacity(iStack *stack) {
    return SIZE;
}

void show(iStack *stack) {
    while (!isEmpty(stack)) {
        printf("%d", pop(stack));
    }
}

#endif /* ISTACK_H_ */
