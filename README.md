# Word Generator

## How to

* Start the program.

* Input 'y' for using default values. Default values can be viewed by pressing 'n' on this step.

* To change default values hit 'n'. You can make your own 'seed' word file to feed to the algorithm. To use custom seed file, go to 'Browse' button in the newly opened form and pick your file. You can also set the number of words to be generated and the frequency of word generation (in milliseconds). Click 'Save' button to continue.

* Now you can view the 'word matrix'. 

* By pressing 'y', the new form will open where you can watch all words being generated. Or by hitting 'n' - now only correctly generated English words will be shown on screen. In both cases, you can save generated words after the algorithm finishes.

## About

Word Generator is a small Windows based application, built in Visual Studio 2017 with C#.

It uses Markov chains based algorithm for generating new words. Learning part of this algorithm is realised with the 'word matrix', which is basically a table that tracks occurrences and frequency of every letter in the English alphabet (for a given dataset) and the 'space' or \0 sign (end of word). This matrix is later used for combining letters and creating new words randomly. The 'seed' file is a plain text file containing initial words that will be fed into the algorithm so it can 'learn'.

Apart from generating words, the app also contains feature for deciding if a newly generated word is English or not. It does this by comparing the newly generated word to a vast file of around 400.000 English words. https://github.com/dwyl/english-words

The algorithm is based on the code from the book _Artificial Intelligence -  A Systems Approach_ by _M. Tim Jones_, chapter 6., pages 177 - 184.
