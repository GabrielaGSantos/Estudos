#include <stdio.h>

void main() {
	char bandeira[80][25];

	// DEFINE V PARA A BANDEIRA TODA
	for (int j = 0; j < 25; j++) {
		for (int i = 0; i < 80; i++) {
			bandeira[i][j] = 'v';
		}
	}

	// DEFINE A PARA A PARTE AMARELA
	for (int j = 0; j < 25; j++) {
		for (int i = 0; i < 80; i++) {
			if ((i == j+2 || i == j+1) && (i != 0&& j != 0) ) {
				bandeira[i+ (int)(j/i)][24-j] = 'a';
			}
		}
	}

	// IMPRIME
	for (int j = 0; j < 25; j++) {
		for (int i = 0; i < 80; i++) {
			printf("%c", bandeira[i][j]);
		}
		printf("\n");
	}
}
