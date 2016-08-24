// Maze solver algorithm
// It creates a PPM Image of the Maze and a PPM Image of the way out
// H -> Height -> Altura // W -> Width -> Largura
// Developed by Luís Alexandre Ferreira Bueno and Vitor Bruno de Oliveira Barth
// Em 24/08/2016

#include "iQueue.h"
#include <stdlib.h>
#include <string.h>

// Width of the maze
#define SIZEW 10
// Height of the maze
#define SIZEH 10

void writePPM(int maze[SIZEW][SIZEH], char *name);
void solveMaze(int maze[SIZEW][SIZEH], int startPosition[2], int finalPosition[2]);

void imprimirMatriz(int matriz[SIZEW][SIZEH]) {
	for (int i = 0; i < SIZEW; i++) {
		for (int j = 0; j< SIZEH; j++)
			printf("%2d ", matriz[i][j]);
		printf("\n");
	}
}

int main() {
	int maze[SIZEW][SIZEH] = {
		  	{1, 1, 1, 1, 1, 1, 1, 1, 1, 0},
		  	{1, 0, 0, 0, 0, 1, 0, 0, 1, 0},
			{0, 1, 1, 1, 0, 1, 0, 1, 1, 0},
			{1, 0, 1, 0, 0, 1, 1, 0, 1, 1},
			{1, 0, 0, 0, 0, 0, 1, 0, 0, 1},
			{1, 1, 0, 0, 1, 1, 1, 0, 1, 1},
			{0, 1, 1, 1, 1, 0, 0, 0, 1, 0},
			{0, 0, 0, 1, 0, 1, 1, 0, 1, 1},
			{1, 1, 0, 1, 0, 1, 1, 1, 0, 1},
			{1, 1, 0, 1, 0, 1, 1, 1, 0, 1}
	}; // 1 stands for WAY and 0 stands for BLOCKAGE
	
	writePPM(maze, "NONSOLVED.ppm");

	int startPosition[2] = {0,0};
	int finalPosition[2] = {(SIZEH-1),(SIZEW-1)};
	
	solveMaze(maze, startPosition, finalPosition);

}

void writePPM(int maze[SIZEW][SIZEH], char *name) {
	int resolutionWidth = 800; // Width of the generated image
	int resolutionHeight = 800; // Height of the generated image

	int blockSizeHeight = (int) resolutionHeight/SIZEH;
	int blockSizeWidth = (int) resolutionWidth/SIZEW;

	FILE *image = fopen(name, "w");

	if (image == NULL)
		printf("Error opening file!\n");

	char *header[4] = {
		"P3",
		"# P3 PPM Image Format",
		"# Using 1 for color in RGB format"
	};

	fprintf(image, "%s\n%s\n%s\n%d %d 1\n", header[0], header[1], header[2], resolutionWidth, resolutionHeight);

	for (int i = 0; i < SIZEH; i++) {
		for (int j = 0; j < blockSizeHeight; j++) {
			for (int k = 0; k < SIZEW; k++) {
				for (int l = 0; l < blockSizeWidth; l++) {
					if (maze[i][k] == 0)
						fprintf(image, "0 0 0  ");
					else if (maze[i][k] == -1 && (j > blockSizeHeight/3 && j < 2*blockSizeHeight/3 || l > blockSizeHeight/3 && l < 2*blockSizeHeight/3))
						fprintf(image, "1 0 0  ");
					else
						fprintf(image, "1 1 1  ");
				}
			}
		fprintf(image, "\n");
		}
	}

	fclose(image);
}

void solveMaze(int maze[SIZEW][SIZEH], int startPosition[2], int finalPosition[2]) {
	iQueue X, Y;

	init(&X, 0);
	init(&Y, 0);

	enqueue(&X, startPosition[0]);
	enqueue(&Y, startPosition[1]);

	maze[peek(&X)][peek(&Y)] = 2;

	do {

		int trilha = maze[peek(&X)][peek(&Y)];

		if(!isEmpty(&X) && (maze[peek(&X)+1][peek(&Y)] == 1  && peek(&X)+1 < SIZEH)) {
			maze[peek(&X)+1][peek(&Y)] = trilha+1;
			enqueue(&X, peek(&X)+1);
			enqueue(&Y, peek(&Y));	
		}

		if(!isEmpty(&X) && (maze[peek(&X)-1][peek(&Y)] == 1 && peek(&X)-1 >= 0)) {
			maze[peek(&X)-1][peek(&Y)] = trilha+1;
			enqueue(&X, peek(&X)-1);
			enqueue(&Y, peek(&Y));	
		}

		if(!isEmpty(&X) && (maze[peek(&X)][peek(&Y)+1] == 1 && peek(&Y)+1 < SIZEW)) {
			maze[peek(&X)][peek(&Y)+1] = trilha+1;
			enqueue(&X, peek(&X));
			enqueue(&Y, peek(&Y)+1);	
		}	
	
		if(!isEmpty(&X) && (maze[peek(&X)][peek(&Y)-1] == 1 && peek(&Y)-1 >= 0)) {
			maze[peek(&X)][peek(&Y)-1] 	= trilha+1;
			enqueue(&X, peek(&X));
			enqueue(&Y, peek(&Y)-1);	
		}

		if (!isEmpty(&X)) 
			maze[dequeue(&X)][dequeue(&Y)] = trilha;

		if (maze[finalPosition[0]][finalPosition[1]] != 1)
			break;

	} while (!isEmpty(&X));

	if (maze[finalPosition[0]][finalPosition[1]] == 1)
		printf("IMPOSSIBLE TO FIND A WAY FROM (%d, %d) to (%d, %d)\n\n", startPosition[0], startPosition[1], finalPosition[0], finalPosition[1]);

	enqueue(&X, finalPosition[0]);
	enqueue(&Y, finalPosition[1]);

	imprimirMatriz(maze);

	while (maze[peek(&X)][peek(&Y)] != 2) {

		int trilha = maze[peek(&X)][peek(&Y)];

		if(!isEmpty(&X) && (maze[peek(&X)+1][peek(&Y)] == maze[peek(&X)][peek(&Y)]-1  && peek(&X)+1 < SIZEH)) {
			enqueue(&X, peek(&X)+1);
			enqueue(&Y, peek(&Y));	
		}

		if(!isEmpty(&X) && (maze[peek(&X)-1][peek(&Y)] == maze[peek(&X)][peek(&Y)]-1 && peek(&X)-1 >= 0)) {
			enqueue(&X, peek(&X)-1);
			enqueue(&Y, peek(&Y));	
		}

		if(!isEmpty(&X) && (maze[peek(&X)][peek(&Y)+1] == maze[peek(&X)][peek(&Y)]-1 && peek(&Y)+1 < SIZEW)) {
			enqueue(&X, peek(&X));
			enqueue(&Y, peek(&Y)+1);	
		}	
	
		if(!isEmpty(&X) && (maze[peek(&X)][peek(&Y)-1] == maze[peek(&X)][peek(&Y)]-1 && peek(&Y)-1 >= 0)) {
			enqueue(&X, peek(&X));
			enqueue(&Y, peek(&Y)-1);	
		}

		if (!isEmpty(&X)) 
			maze[dequeue(&X)][dequeue(&Y)] =  -1;
	}

	maze[startPosition[0]][startPosition[1]] = -1;

	writePPM(maze, "SOLVED.ppm");

	imprimirMatriz(maze);
}
