#include <stdio.h>
#include <stdlib.h>
#include <windows.h>
#define T 100000

void ordena (int vetor[T]);
int buscaBinaria(int vetor[T], int busca);
int buscaBinariaRecursiva(int vetor[T], int busca, int inicio, int fim);

int main() {
	
	int vetor[T];

	int Tinicio = GetTickCount(); 
	
	for (int i = 0; i < T; i++) {		
		int r = rand() % 1000000;  
		vetor[i] = r;
		//printf("(%d, %d) ", i, vetor[i]);
		//if (i % 10 == 0 && i != 0)
		//	printf ("\n");
	}
	
	int Tfinal = GetTickCount();
	
	printf("\nTINICIAL: %d", Tinicio);
	printf("\nTFINAL: %d", Tfinal);
	printf("\nTEMPO GERAR VETOR: %d", Tfinal-Tinicio);
	
	printf ("\n");
	
	Tinicio = GetTickCount(); 
	ordena(vetor);
	Tfinal = GetTickCount();
	
	printf("\nTINICIAL: %d", Tinicio);
	printf("\nTFINAL: %d", Tfinal);
	printf("\nTEMPO ORDENAR VETOR: %d", Tfinal-Tinicio);
	
	printf ("\n");
	
	//for (int i = 0; i < T; i++) {
	//	printf("(%d, %d) ", i, vetor[i]);
	//	if (i % 10 == 0 && i != 0)
	//		printf ("\n");
	//}
		
	int busca;
	printf("\n\nDigite o valor a ser buscado: ");
	scanf("%d", &busca);
	
	printf("\n");
	
	Tinicio = GetTickCount(); 
	int achou = buscaBinaria(vetor, busca);
	Tfinal = GetTickCount();
	
	printf("\nTINICIAL: %d", Tinicio);
	printf("\nTFINAL: %d", Tfinal);
	printf("\nTEMPO BUSCA NORMAL: %d", Tfinal-Tinicio);

	if (achou == -1) {
		printf("\nValor nao encontrado");
	}
	
	printf("\n\n");
	
	Tinicio = GetTickCount();
	achou = buscaBinariaRecursiva(vetor, busca, 0, T-1);
	Tfinal = GetTickCount();
	
	printf("\nTINICIAL: %d", Tinicio);
	printf("\nTFINAL: %d", Tfinal);
	printf("\nTEMPO BUSCA RECURSIVA: %d", Tfinal-Tinicio);

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
			printf("BUSCA NORMAL O valor %d esta na posicao %d", busca, meio);
			return meio;
		}
		
		if (busca > vetor[meio])  
			inicio = meio+1;

		if (busca < vetor[meio])
			fim = meio-1;		
	}	
	
	return -1;
}

int buscaBinariaRecursiva(int vetor[T], int busca, int inicio, int fim) {
	int meio = (inicio + fim)/2;
			
	if (inicio > fim)
		return -1;
	
	if (vetor[meio] == busca) {
		printf("BUSCA RECURSIVA O valor %d esta na posicao %d", busca, meio);
		return meio;
	}
	
	else {
		if (busca > vetor[meio])
			buscaBinariaRecursiva(vetor, busca, meio+1, fim);
		else
			buscaBinariaRecursiva(vetor, busca, inicio, meio-1);
	}
}
