/**************************************************************************
 * Programa ponteiros.c                                         	      *
 *                                                                        *
 * Demonstracão do uso de ponteiros        								  *
 * Data: 30/05/2016			                                              *
 * Autor: João Paulo D. Preti                                             *
 **************************************************************************/
/*
#include <stdio.h>
#include <stdlib.h>

int main() {
	//Exemplo 1
	long a = 5;
	long *aPtr = &a;
	printf("%ld\n",*aPtr);
	printf("%p\n",aPtr);
	printf("%p\n",&aPtr);

	//Exemplo 2
	int num, valor;
	int *p;
	num = 55;
	p=&num;
	valor=*p;
	printf("%d\n", valor);
	printf("Endereco para onde o ponteiro aponta: %p\n", p);
	printf("Valor da variavel apontada: %d\n", *p);

	//Exemplo 3
	*p = 100;
	printf("Valor final: %d\n", num);

	//Exemplo 4
	p++;
	printf("Valor da variavel p: %p\n", p);
	printf("Valor da variavel apontada: %d\n", *p);

	//Exemplo 5
	int vet[4];
	p = vet;
	for (int i=0; i < 4; i++) {
		*p=0;
		p++;
	}
	for (int i=0; i < 4; i++) {
		printf(" %d -", vet[i]);
	}

	//Exemplo 6
	float *pi;
	pi = (float *) malloc(sizeof(float));
	printf("Valor da variavel pi: %p\n", pi);
	printf("Valor da variavel apontada: %f\n", *pi);
	*pi=3.1415;
	printf("Valor da variavel apontada: %f\n", *pi);
	free(pi);
	printf("Valor da variavel pi: %p\n", pi);
	printf("Valor da variavel apontada: %f\n", *pi);

	return 0;
}
*/
