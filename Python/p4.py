maior = 0
for i in range(100,999):
	for j in range(100,999):
		x = i*j
		if str(x)[::-1] == str(x):
			if (x > maior):
				maior = x
print "O maior: ", maior

