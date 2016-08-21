import sys

nteste = 1
i = 0
while i < 10001:
	nteste = nteste+1
	divisors = [x for x in range(2, int(round(nteste**0.5)+3))]
	if (nteste%3 != 0 or nteste%5 !=0 or nteste%7 != 0 or nteste%11 != 0):
		if(all(nteste%x != 0 for x in divisors)):
			i = i+1
			print nteste

print nteste
