x1 = 0
x2 = 1
x3 = 1
soma = 0
while x1 < 4000000:
	if x1 % 2 == 0:
		soma = soma + x1	 
	x1 = x2
	x2 = x3
	x3 = x1 + x2 
print soma
			
