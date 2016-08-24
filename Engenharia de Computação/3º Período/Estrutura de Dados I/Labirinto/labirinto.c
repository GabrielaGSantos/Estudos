// Maze solver algorithm
// It creates a PPM Image of the Maze and a PPM Image of the way out
// H -> Height -> Altura // W -> Width -> Largura
// Developed by Luís Alexandre Ferreira Bueno and Vitor Bruno de Oliveira Barth
// Em 24/08/2016

#include <stdio.h>
#include <stdlib.h>
#include <string.h>

// Width of the maze
#define SIZEW 10
// Height of the maze
#define SIZEH 10

int writePPM(int maze[SIZEW][SIZEH], char *name);

int main() {
	int maze[SIZEW][SIZEH] = {
		  	{1, 0, 1, 1, 1, 1, 1, 1, 1, 0},
		  	{1, 0, 0, 0, 0, 1, 0, 0, 1, 0},
			{1, 1, 1, 1, 0, 1, 0, 1, 1, 0},
			{1, 0, 0, 0, 0, 1, 1, 0, 1, 1},
			{1, 0, 0, 0, 0, 0, 1, 0, 0, 1},
			{1, 1, 0, 0, 1, 1, 1, 0, 1, 1},
			{0, 1, 1, 1, 1, 0, 0, 0, 1, 0},
			{0, 0, 0, 1, 0, 1, 1, 0, 1, 1},
			{1, 1, 0, 1, 0, 1, 1, 1, 0, 1},
			{1, 1, 0, 1, 0, 1, 1, 1, 0, 1}
	}; // 1 stands for WAY and 0 stands for BLOCKAGE
	
	char *name = "NONSOLVED.ppm";

	writePPM(maze, name);

	int startPosition[2][2] = {{0,0}};
	int finalPosition[2][2] = {{(SIZEW-1),(SIZEH-1)}};
}

int writePPM(int maze[SIZEW][SIZEH], char *name) {
	int resolutionWidth = 800; // Width of the generated image
	int resolutionHeight = 600; // Height of the generated image

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
						fprintf(image, "0 0 1  ");
					else if (maze[i][k] == 1)
						fprintf(image, "0 1 0  ");
				}
			fprintf(image, "\n");
			}
		}
	}

	fclose(image);
}
