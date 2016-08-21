#include <Servo.h> 
  
 Servo servo1;
  
void setup() 
{ 
   servo1.attach(9);
} 
  
  
  void loop() 
{ 
     servo1.write(45);              // tell servo to go to position in variable 'pos' 
                // tell servo to go to position in variable 'pos' 
     delay(1000); 
     servo1.write(105);
      delay(1000);
      servo1.write(20);
       delay(1000);
     // waits 15ms for the servo to reach the position 

}
