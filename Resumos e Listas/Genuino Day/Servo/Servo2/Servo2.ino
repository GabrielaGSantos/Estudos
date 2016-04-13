#include <Servo.h> 
  
 Servo servo1;
 Servo servo2;
  
void setup() 
{ 
   servo1.attach(3);
   servo2.attach(5); 
} 
  
  
void loop() 
{ 
     servo1.write(85);              // tell servo to go to position in variable 'pos' 
     servo2.write(45);              // tell servo to go to position in variable 'pos' 
     delay(1000);                       // waits 15ms for the servo to reach the position 

}
