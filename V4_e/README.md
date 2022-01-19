Anton Paar V4_e solution
---
17.01.2022, Matthias G.
---

Program fulfill following conditions:

*** Scenario ***

-	User is able to specify which text file he want to process
-	all words within the file will be extracted and counted
-	the result is a two - column table, sorted by number of the occurrences of the words (Word	Occurrence)
-	User can always abort the process.

*** Technical ***

-	program reads an ANSI text file specified by user
-	words are seperated by char (set splitBy when calling function) ==> function ParsingLogic.parseFile(..., char splitBy, ...)
-	Class ComputeOutput
	-	get array with sorted and formated strings ==> getOutput(string path, ref bool cancelCurrentProcess)
	-	path: holds path to file
	-	cancelCurrentProcess: if true, function returns current sorted result
-	Class Parsinglogic
	-	get a unsorted Dicitonary holding <word, occurence>ParseFile(string path, char splitBy, ref bool cancelCurrentProcess)
	-	path: the path to the file
	-	cancelCurrentProcess: if true, function exits and returns current result
	-	splitby: Define the Character the String is split by	