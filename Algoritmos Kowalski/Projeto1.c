#include <stdio.h>
#include <math.h>
#define PI 3.1415

double FC(double t) {
	return cos(t)+2*sin(t);
}

void main() {
	double teste, vg, erroatu, erromax;
	erromax = 0.01;
	erroatu = 10;
	vg = 2;
	teste = 0;
	while (erromax <= sqrt(erroatu*erroatu)) {
		erroatu = FC(teste)-vg;
		teste =  teste + 0.0001;
}
		printf("\ncos(%f rad) + 2*sin(%f rad) = 2\n\n", teste, teste);

}
