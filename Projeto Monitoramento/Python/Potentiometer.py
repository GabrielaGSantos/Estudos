import RPi.GPIO as GPIO
import time

GPIO.setmode(GPIO.BCM)

a_pin = 23
b_pin = 24

GPIO.setup(a_pin, GPIO.IN)
GPIO.setup(b_pin, GPIO.OUT)
GPIO.output(
