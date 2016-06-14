#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "../Bibliotecas/cStack.h"
#include "../Bibliotecas/OrdemExpressao.h"

void empilha(char *expressao, cStack *pilha);
int desempilha(cStack *pilha);

int main() {
	cStack pilha;
	init(&pilha, 1);
	
	char expressao[100] = "5 3 * 10 15 / 2 + -";
	
	empilha(expressao, &pilha);

	return EXIT_SUCCESS;	
}

void empilha(char *expressao, cStack *pilha) {
	for (int i = 0; expressao[i]; i++) {
		if(in(expressao[i], "+-/*") >= 0) 
			push(pilha, expressao[i]);
		else if(in(expressao[i], " ") < 0) {
			push(pilha, desempilha(pilha));
		}
	}
	printf("%d", top(pilha));			
}

int desempilha(cStack *pilha) {
	char operacao = pop(pilha);
	if(operacao == '+')
		return pop(pilha) + pop(pilha);	
	if(operacao == '-')
		return pop(pilha) - pop(pilha);	
	if(operacao == '*')
		return pop(pilha) * pop(pilha);
	if(operacao == '/')
		return pop(pilha) / pop(pilha);
	else
		return -1;
}
