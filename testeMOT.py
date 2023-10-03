separators = [' ', '.', '\n']

sentence = input("Enter a sentence: ")
words = sentence.split()

cleaned_words = [word.strip(str(separators)).lower() for word in words]

print("Words in the sentence:")
print(cleaned_words)
