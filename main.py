#!/usr/bin/env python3.9
a = str(input('Enter a word: '))
b = str(input('Enter another word: '))

ls = lambda a, b: len(b) if not a else len(a) if not b else min(ls(a[1:], b[1:])+(a[0]!=b[0]), ls(a[1:], b)+1, ls(a, b[1:])+1)

exit(f'Leveinshtein\'distance is: {ls(a, b)}')