#include "Ultrasonic.h"
Ultrasonic ultrasonic(12, 13);

const int vermelho = 11;
const int verde = 10;
const int amarelo = 9;


void setup() {
  pinMode(11, OUTPUT);
  pinMode(10, OUTPUT);
  pinMode(9, OUTPUT);
  Serial.begin(9600);
  Serial.println("Lendo dados do sensor...");
}

void loop()
{ float cmMsec, inMsec;
  long distancia = (ultrasonic.timing());
  cmMsec = ultrasonic.convert(distancia, Ultrasonic::CM);
  inMsec = ultrasonic.convert(distancia, Ultrasonic::IN);
  Serial.print("Distancia em cm: ");
  Serial.print(cmMsec);
  Serial.print(" - Distancia em polegadas: ");
  Serial.println(inMsec);
  delay(700);

  //Apagando todos os leds
  digitalWrite(verde,LOW);  
  digitalWrite(amarelo,LOW);
  digitalWrite(vermelho,LOW);

  
if (cmMsec > 45) {
    digitalWrite(verde,HIGH); 
  }
   
  if (cmMsec<=45 and cmMsec>= 20) {
    digitalWrite(amarelo,HIGH);
  }
   
  if (cmMsec <= 20) {
    digitalWrite(vermelho,HIGH);
  }
}
