using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemorizer
{
    // Class to store and format scripture reference
    class Reference
    {
        public string Book { get; }
        public int Chapter { get; }
        public int StartVerse { get; }
        public int? EndVerse { get; }

        public Reference(string book, int chapter, int startVerse, int? endVerse = null)
        {
            Book = book;
            Chapter = chapter;
            StartVerse = startVerse;
            EndVerse = endVerse;
        }

        public string GetDisplayText()
        {
            if (EndVerse.HasValue)
            {
                return $"{Book} {Chapter}:{StartVerse}-{EndVerse}";
            }
            return $"{Book} {Chapter}:{StartVerse}";
        }
    }

    // Class to represent a single word in the scripture
    class Word
    {
        public string Text { get; }
        public bool IsHidden { get; private set; }

        public Word(string text)
        {
            Text = text;
            IsHidden = false;
        }

        public void Hide()
        {
            IsHidden = true;
        }

        public string GetDisplayText()
        {
            return IsHidden ? new string('_', Text.Length) : Text;
        }
    }

    // Class to manage the scripture and its words
    class Scripture
    {
        private Reference _reference;
        private List<Word> _words;

        public Scripture(Reference reference, string text)
        {
            _reference = reference;
            _words = text.Split(' ').Select(word => new Word(word)).ToList();
        }

        public string GetDisplayText()
        {
            string scriptureText = string.Join(" ", _words.Select(word => word.GetDisplayText()));
            return $"{_reference.GetDisplayText()}\n{scriptureText}";
        }

        public bool HideRandomWords(int count = 3)
        {
            // Get all visible words
            var visibleWords = _words.Where(word => !word.IsHidden).ToList();
            if (!visibleWords.Any())
            {
                return false; // No words left to hide
            }

            // Hide random words
            var random = new Random();
            var wordsToHide = visibleWords.OrderBy(_ => random.Next()).Take(count);
            foreach (var word in wordsToHide)
            {
                word.Hide();
            }

            return true;
        }

        public bool AreAllWordsHidden()
        {
            return _words.All(word => word.IsHidden);
        }
    }

    // Main program
    class Program
    {
        static void Main(string[] args)
        {
            // Create some scriptures
            var scriptures = new List<Scripture>
            {
                new Scripture(new Reference("John", 3, 16), "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life."),
                new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight.")
            };

            // Choose a random scripture
            var random = new Random();
            var scripture = scriptures[random.Next(scriptures.Count)];

            // Main loop
            while (true)
            {
                // Clear the console and display the scripture
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());

                // Check if all words are hidden
                if (scripture.AreAllWordsHidden())
                {
                    Console.WriteLine("\nYou've memorized the scripture!");
                    break;
                }

                // Prompt the user
                Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit.");
                string userInput = Console.ReadLine().Trim().ToLower();

                if (userInput == "quit")
                {
                    break;
                }

                // Hide random words
                scripture.HideRandomWords();
            }
        }
    }
}
