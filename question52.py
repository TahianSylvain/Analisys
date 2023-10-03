tab=[]
with open("ForTPalgo/liste_francais.txt", 'r') as file:
    for letter in file:
        tab.append(letter[:-2])
    file.close()
