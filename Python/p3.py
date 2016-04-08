n = 600851475143
i = 2 
mult = 1
while i < n:
	teste = 1
	j = 2
	while j < i and teste == 1:
		if i % j == 0:
			teste = 0
		j = j+1
	if teste == 1:
		if n % i == 0:
			print i
			mult = i*mult
	if mult > n/2:
		break
	i = i+1
