#include <stdio.h>
#include <stdlib.h>
#include <math.h>

// Para executar o método serão passadas as seguintes informações:
// O limite inferior (lInferior) e limite superior (lSuperior)
// A tolerância (ou seja, o erro máximo) e o número maximo de iterações (iMaximo) 
// e a iteração atual (iAtual) 
// o iAtual tem que começar em ZERO

void metodoDaBisseccao(float lInferior, float lSuperior, float erroMaximo, int iMaximo, int iAtual);
float funcao(float x);

void main() {
	metodoDaBisseccao(1, 2, 0.001, 13, 0);
}

void metodoDaBisseccao(float lInferior, float lSuperior, float erroMaximo, int iMaximo, int iAtual) {
	float lNovo = ((lInferior+lSuperior)/2);
	float erroAtual = sqrt((funcao(lNovo)-0)*(funcao(lNovo)-0));

	printf("\nITERAÇÃO %i: lInferior = %f, lSuperior = %f, erroAtual = %f, lNovo = %f, f(lNovo) = %f", iAtual, lInferior, lSuperior, erroAtual, lNovo, funcao(lNovo));

	// Qual limite (superior ou inferior) o lNovo substituirá
	if (funcao(lInferior)*funcao(lNovo) >= 0)
		lInferior = lNovo;
	else
		lSuperior = lNovo;
	
	// Condição de Parada ou Continuação
	if (erroAtual <= erroMaximo)
		printf("\n\nA FUNÇÃO TEM UMA RAIZ EM APROXIMADAMENTE %f \n\n", lNovo);
	else if (iAtual >= iMaximo)
		printf("\n\nO MÉTODO FALHOU: EM %d ITERAÇÕES O ERRO É MAIOR QUE %f\n\n", iAtual, erroMaximo);
	else 
		metodoDaBisseccao(lInferior, lSuperior, erroMaximo, iMaximo, iAtual+1);		
}

// E temos a subrotina abaixo onde será colocada a função qual se quer achar o zero
float funcao(float x) {
	return ((x*x*x)+(4*(x*x))-10);
}
