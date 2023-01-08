using System;
using System.Collections.Generic;
using static System.Random;
using System.Text;


namespace Projekt
{
    internal class Hangmanprogram
    {
        //functions
        private static void outputHangman (int wrong)
        {
            //hangman graphics
            if (wrong == 0)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine("    |");
                Console.WriteLine("    |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 1)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine("O   |");
                Console.WriteLine("    |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 2)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine("O   |");
                Console.WriteLine("|   |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 3)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O  |");
                Console.WriteLine("/|  |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 4)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O  |");
                Console.WriteLine("/|\\ |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 5)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O  |");
                Console.WriteLine("/|\\ |");
                Console.WriteLine("/   |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 6)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O   |");
                Console.WriteLine("/|\\  |");
                Console.WriteLine("/ \\  |");
                Console.WriteLine("    ===");
            }
        }

        private static int writeWord(List<char>letters, String wordGen)
        {
            int counter = 0;
            int correctLetters = 0;
            Console.WriteLine("\r\n");//for spacing everything out
            foreach (char c in wordGen)  //looping through guessed letters and printing correct ones out
            {
                if (letters.Contains(c))
                {
                    Console.Write(c + " ");
                    correctLetters+=1; //incrementing correct letters
                }
                else
                {
                    Console.Write(" ");
                }
                counter +=1;
            }
            return correctLetters;   
        }

        private static void lines(String wordGen)
        {
            Console.WriteLine("\r");
            foreach(char c in wordGen)
            {
                Console.Write("_"); //printing out marked correct letters 
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Play a game of HANGMAN!");


            //creating a random word
            Random random = new Random();
            List<string> libraryOfWords = new List<string> { "flower", "programming", "people", "children", "chocolate", "cupcake", "pencil", "dictionary" };
            int index = random.Next(libraryOfWords.Count);
            String generatingWord = libraryOfWords[index];

            //printing out lines to display number of letters in word to be guessed
            foreach(char x in generatingWord)
            {
                Console.Write("_ ");
            }

            //getting lenght of word to guess
            int lengthOfWord = generatingWord.Length;
            
            //wrong letters
            int howManyWrongs = 0;
            List<char> guessedLetters = new List<char>();

            //letters guessed right
            int rightLetters = 0;


            while(howManyWrongs != 6 && rightLetters != lengthOfWord)
            {
                Console.WriteLine("\n Guessed letters: ");

                foreach(char letter in guessedLetters)
                {
                    Console.Write(letter + " ");
                }

                //Tell player to guess a letter
                Console.Write("\nGuess a letter: ");
                char inputLetter = Console.ReadLine()[0]; //only reading first letter guessed if user writes several

                //check if letters has already been guessed
                if(guessedLetters.Contains(inputLetter))
                {
                    Console.Write("\r\n This letter have already been used!");
                    outputHangman(howManyWrongs);
                    rightLetters = writeWord(guessedLetters, generatingWord);
                    lines(generatingWord);
                }
                else
                {
                    //checking if letter is in the word
                    bool right = false;

                    for (int i = 0; i < generatingWord.Length; i++) 
                    { if (inputLetter == generatingWord[i]) { right = true; } }

                        //if player guessed correct letter
                        if(right)
                        {
                            outputHangman(howManyWrongs);

                            //printing word
                            guessedLetters.Add(inputLetter);
                            rightLetters = writeWord(guessedLetters, generatingWord);
                            Console.Write("\r\n");
                            lines(generatingWord);

                        }

                        //if player is wrong
                        else
                        {
                            howManyWrongs += 1;
                            guessedLetters.Add(inputLetter);

                            //drawing of hangman
                            outputHangman(howManyWrongs);

                            //print word
                            rightLetters = writeWord(guessedLetters, generatingWord);
                            Console.Write("\r\n");
                            lines(generatingWord);
                        }
                    }
                }
                Console.WriteLine("\r\n GAME OVER");
            }            
        }
    }
