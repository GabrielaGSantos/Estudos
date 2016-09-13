import RPi.GPIO as GPIO
import time
GPIO.setmode(GPIO.BCM)
GPIO.setup(4, GPIO.OUT)

for i in range (0, 5):
	print "LED ON"
	GPIO.output(4, True)
	time.sleep(1)
	print "LED OFF"
	GPIO.output(4, False)
	time.sleep(1)
