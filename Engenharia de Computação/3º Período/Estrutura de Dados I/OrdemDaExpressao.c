
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "cStack.h"

int main() {
	char expressao[] = "41 * 30 / 23 * {[]52 - 23 * (4 - 3) - (3 * 5)]} / 5";
	cStack pilha;
	
	init(&pilha);
	
	int bandeira = 0;
	
	for (int i = 0; expressao[i]; i++) {
		if (expressao[i] == '(' || expressao[i] == '[' || expressao[i] == '{') {
			printf("%c", expressao[i]);
			push(&pilha,expressao[i]);
		}
		
		if(expressao[i] == ')' || expressao[i] == ']' || expressao[i] == '}')
		{		
			printf("%c", expressao[i]);
			
			if (!isEmpty(&pilha)) {
				if (expressao[i] == ')' && top(&pilha) == '(') 
					pop(&pilha);
				else if (expressao[i] == ']' && top(&pilha) == '[') 
					pop(&pilha);
				else if (expressao[i] == '}' && top(&pilha) == '{') 
					pop(&pilha);
				else 
					bandeira = 1;
			}
			else
				 bandeira = 1;
		}
	}
	
	if (isEmpty(&pilha) && bandeira == 0)
		printf("A ORDEM ESTA OK");
	else
		printf("A ORDEM NAO ESTA OK");
		
	return EXIT_SUCCESS;
}
