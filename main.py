from chargeTEXT import tab



ls = lambda a, b: len(b) if not a else len(a) if not b else min(ls(a[1:], b[1:])+(a[0]!=b[0]), ls(a[1:], b)+1, ls(a, b[1:])+1)


def propose_levenshtein(x):
    COEFFICIENT_MAX = 2
    right = []
    for y in tab:
        if ls(x, y) <= COEFFICIENT_MAX:
            right.append(y)
    return str(right)


def question4(e="ForTPalgo/Texte.txt"):
    separators = [' ', '.']
    with open(e, 'r') as s:
        words = str([x for x in s]).split()
        cleaned_words = [word.strip(str(separators)).lower() for word in words]
    s.close()
    with open("ForTPalgo/Texte.err", 'w') as corrections:
        """question3"""
        for bad_word in cleaned_words:
            if bad_word in tab:
                print(f'skype {bad_word}')
                continue
            else:
                line = f'{bad_word}-'
                line += str(propose_levenshtein(bad_word))
                line += '\n'
                corrections.write(line)
    corrections.close()


# question4()




# entry = str(input('Insérer un mot:'))
# verity = True
# if entry not in tab:
#     verity = False
#     print("Il n'est pas dans le dico!")
#     propose_levenshtein(entry)
# else:
#     print("C'est dans le dico!")