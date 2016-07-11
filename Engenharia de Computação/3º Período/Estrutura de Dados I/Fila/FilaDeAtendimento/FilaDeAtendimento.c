#include "../Bibliotecas/iQueue.h"

int chamaCaixa(iQueue *fila, int *caixas, int nCaixas);

int main() {
	int caixas[10];
	iQueue fila;
	init(&fila);
	enqueue(&fila,20);
	enqueue(&fila,10);
	enqueue(&fila,5);
	enqueue(&fila,50);
	enqueue(&fila,15);
	enqueue(&fila,25);
	enqueue(&fila,20);
	enqueue(&fila,12);
	enqueue(&fila,18);
	enqueue(&fila,7);
	
	int tempo = 0;

	while(!isEmpty(&fila)) {
		caixas[chamaCaixa(&fila, caixas, sizeof(caixas))] = dequeue(&fila);	
		tempo++;
	}
}

int chamaCaixa(iQueue *fila, int *caixas, int nCaixas) {
	for (int i = 0; i < nCaixas; i++) {
		if (caixas[i] == 0)
			return i;
	
}

