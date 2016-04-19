#include <stdio.h>
#define KYEL  "\x1B[33m"
#define KGRN  "\x1B[32m"
#define KBLU  "\x1B[34m"

void main() {
	char bandeira[74][25];

	// DEFINE V PARA A BANDEIRA TODA
	for (int j = 0; j < 25; j++) {
		for (int i = 0; i < 74; i++) {
			bandeira[i][j] = 'v';
		}
	}

	int borda = 0;
	// DEFINE A PARA A PARTE AMARELA
	for (int i = 0; i < 74; i+=3) {
		if (i < 36) {
			for (int j = 12-borda; j < 13+borda; j++) {
				bandeira[i][j] = 'a';
				bandeira[i+1][j] = 'a';
				bandeira[i+2][j] = 'a';
			}
			borda++;
		}	
		if (i >= 36) {
			for (int j = 12-borda; j < 13+borda; j++) {
				bandeira[i][j] = 'a';
				bandeira[i+1][j] = 'a';
				bandeira[i+2][j] = 'a';
			}
			borda--;
		}
	}
			
	borda = -2;
	// DEFINE A PARA A PARTE AZUL
	for (int i =10-borda; i < 74; i++) {
		if (i < 37) {
			for (int j = 26-borda; j < borda-1; j++) {
				bandeira[i][j] = 'z';
			}
			borda++;
		}	
		if (i >= 37) {
			for (int j = 26-borda; j < borda-1; j++) {
				bandeira[i][j] = 'z';
			}
			borda--;
		}
	}	
	

	// IMPRIME
	for (int j = 0; j < 25; j++) {
		for (int i = 0; i < 74; i++) {
			if (bandeira[i][j] == 'a')
				printf("%s#", KYEL);
			if (bandeira[i][j] == 'v')
				printf("%s#", KGRN);
			if (bandeira[i][j] == 'z')
				printf("%s#", KBLU);
		}
		printf("\n");
	}
}
