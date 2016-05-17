#include <stdio.h>
#include <stdlib.h>
#define T 100

void ordena (int vetor[T]);
int buscaBinaria(int vetor[T], int busca);

int main() {
	
	int vetor[T];

	for (int i = 0; i < T; i++) {		
		int r = rand() % 10000;  
		vetor[i] = r;
		printf("(%d, %d) ", i, vetor[i]);
		if (i % 10 == 0 && i != 0)
			printf ("\n");
	}
	
	ordena(vetor);
	
	printf ("\n\n");
	
	for (int i = 0; i < T; i++) {
		printf("(%d, %d) ", i, vetor[i]);
		if (i % 10 == 0 && i != 0)
			printf ("\n");
	}
		
	int busca;
	printf("\n\n Digite o valor a ser buscado: ");
	scanf("%d", &busca);
	
	int achou = buscaBinaria(vetor, busca);

	if (achou == -1) {
		printf("\nValor nao encontrado");
	}
	
	return 0;
}

void ordena(int vetor[T]) {
	for (int i = 0; i < T; i++) {
		for (int j = 1; j < T; j++) {
			if (vetor[j] < vetor[j-1]) {
				int aux = vetor[j];
				vetor[j] = vetor[j-1];
				vetor[j-1] = aux;
			}
		}
	}
}

int buscaBinaria(int vetor[T], int busca) {
	int inicio = 0, meio, fim = T-1;
	
	while (inicio <=fim) {
		meio = (int) (inicio+fim)/2;
		
		if (vetor[meio] == busca) {
			printf("O valor %d esta na posicao %d", busca, meio);
			return meio;
		}
		
		if (busca > vetor[meio])  
			inicio = meio+1;

		if (busca < vetor[meio])
			fim = meio-1;		
	}	
	
	return -1;
}
