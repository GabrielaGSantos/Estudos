#include <stdio.h>
#include <stdlib.h>
#include <math.h> 

float function(float x);

void main() {
    system("clear");
    
    float xr_antigo, xr_atual, xl, xu, fxl, fxr, fxu;
    int i = 0;
    
    // Definir o intervalo
    xl = 0;
    xu = 3;
    
    // Executar a primeira vez pra fazer o teste
    fxr_atual = fxl = function(xl);
    fxu = function(xu); 
    
    printf("f(xl) = %f, f(xu) = %f, xl = %f, xu = %f, i = %d \n\n", fxl, fxu, xl, xu, i);
    
    if (fxl*fxu >= 0)
        printf("Não foi encontrada raíz nesse intervalo\n\n");
    
    else {
        printf("f(xl) = %f, f(xu) = %f, xl = %f, xu = %f, i = %d \n\n", fxl, fxu, xl, xu, i);
        printf("fxr = %f, fxu = %f, fxl = %f, i = %d \n\n", fxr, fxu, fxl, i);

        do {
            fxr = function(xr_atual);
            
            if (fxl*fxr > 0)
                fxu = fxr;
            else
                fxl = fxr;
                
            fxl = function(xl);
            fxu = function(xu); 
            
            i++;
            
            xr_atual = xr_antigo;

            xr_atual = fxl-fxu/2;
            
            printf("fxr = %f, fxu = %f, fxl = %f, i = %d, xr_atual = %d \n\n", fxr, fxu, fxl, i, xr_atual);
        } while ((abs(xr_atual-xr_antigo)/xr_atual) < 0.005);
        
        printf("PROVAVEL = %f", fxr);
    }
    
    printf("Pressione qualquer tecla para continuar... ");
    getchar();    
}

//Calcula f(x)
float function(float x) {
    x = exp(-x)-x;
    return x;
}
