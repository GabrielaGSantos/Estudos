#ifndef CSTACK_H_
#define CSTACK_H_

#define SIZE 10

typedef struct Stack {
	char elements[SIZE];
	int top;
}Stack;

void init(Stack *stack);
int isEmpty(Stack *stack);
int isFull(Stack *stack);
char top(Stack *stack);
void push(Stack *stack, char element);
char pop(Stack *stack);
int size(Stack *stack);
int capacity(Stack *stack);
void show(Stack *stack);

void init(Stack *stack) {
	stack->top = -1;
}

bool isEmpty(Stack *stack) {
	if (top(stack) == -1)
		return true;
	else
		return false;
}

int isFull(Stack *stack) {
	if (top(stack) == 9)
		return true;
	else
		return false;
}

char top(Stack *stack) {
	if (!isEmpty(stack))
		return stack->elements[stack->top];
}

void push(Stack *stack, char element) {
	if (!isFull(stack)) {
		stack->top++;
		stack->elements[top(stack)] = element;
		//printf(" %c", stack->elements[top(stack)]);
	} else 
		printf("Push not allowd: stack is full \n");
}

char pop(Stack *stack) {
	if (isEmpty(stack) != 1) {
		stack->top--;
		printf(" %c", stack->elements[top(stack)]);
		return stack->elements[top(stack)+1];
	} else {
		printf("Pop not allowd: stack is empty \n");
		return ' ';
	}
}

int size(Stack *stack) {
	return stack->top;
}
	
int capacity(Stack *stack) {
	return SIZE;
}

void show(Stack *stack) {
	while (isEmpty(stack) != 1)
		pop(stack);
}

#endif
