#pragma warning disable CS1717 // Assignment made to same variable

namespace Decks
{
    public class Deck
    {
        /// <summary>
        /// The amount of decks to be used in the game
        /// </summary>
        protected double decks { get; set; }

        /// <summary>
        /// Whether or not to include jokers in the deck
        /// </summary>
        protected bool includeJokers { get; set; }

        /// <summary>
        /// The array representing the deck of cards
        /// </summary>
        protected string[] deckArray = [];

        private string[] deckArrayElements = [];

        /// <summary>
        /// Constructor for the Deck class
        /// </summary>
        /// <param name="includeJokers">The defualt is False.</param>
        /// <param name="decks">The defualt is 2 decks.</param>
        public Deck(bool includeJokers = false, double decks = 2)
        {
            this.includeJokers = includeJokers;
            this.decks = decks;
            
            CreateDeck(decks);
        }

        /// <summary>
        /// Updates the amount of decks to be used in the game
        /// </summary>
        /// <param name="decks">new value of decks</param>
        public void updateAmoountOfDecks(double decks)
        {
            this.decks = decks;
        }

        /// <summary>
        /// Updates whether or not to include jokers in the deck
        /// </summary>
        /// <param name="includeJokers">new value of includeJokers</param>
        public void updateIncludeJokers(bool includeJokers)
        {
            this.includeJokers = includeJokers;
        }

        /// <summary>
        /// Creates the deck(s) to be used in the game
        /// </summary>
        /// <param name="decks">if wanted the number of decks can be changed</param>
        public void CreateDeck(double decks)
        {
            int cards = (int)Math.Round(decks * (includeJokers ? 54 : 52), 0);
            deckArray = new string[cards];
            string[] suits = { "H", "D", "C", "S" };
            string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
            int index = -1;
            for (int i = 0; i < decks; i++)
            {
                for (int s = 0; s < suits.Length; s++)
                {
                    for (int r = 0; r < ranks.Length; r++)
                    {
                        deckArray[index++] = $"{ranks[r] + suits[s]}";
                    }
                }
                if (includeJokers)
                {
                    deckArray[index++] = "RJO";
                    deckArray[index++] = "BJO";
                }
            }
            this.deckArray = deckArray;
            deckArrayElements = deckArray;
        }

        /// <summary>
        /// Shuffles the deck(s) to be used in the game
        /// </summary>
        public void ShuffleDeck()
        {
            Random.Shared.Shuffle(deckArray);
        }

        /// <summary>
        /// Draws the next card from the top of the deck. [index 0]
        /// </summary>
        /// <returns>The card key for the card at that location.</returns>
        public string DrawNextFromDeck()
        {
            Array.Copy(deckArray, 1, deckArray, 0, deckArray.Length - 1); // shift left
            string card = deckArray.Last();
            deckArray[deckArray.Length - 1] = "0";
            return card;
        }

        /// <summary>
        /// Replace a card back into the deck.
        /// </summary>
        /// <param name="card">The card key you are puting back into the deck.</param>
        /// <param name="index">The index you are putting the card. Defualt is index 0 or the top of the deck.</param>
        public void ReplaceIntoDeck(string card, int index = 0)
        {
            if (index > 0)
            {
                Array.Copy(deckArray, 0, deckArray, 1, deckArray.Length - 1); // shift right
                deckArray[0] = card;
            }
            else
            {
                Array.Copy(deckArray, index, deckArray, index + 1, deckArray.Length - index - 1); // shift right
                deckArray[index] = card;
            }
        }

        public string DrawLastFromDeck()
        {
            string card = deckArray.Last();
            deckArray[deckArray.Length - 1] = "0";
            return card;
        }

        public string DrawFromIndex(int index)
        {
            if (index < 0 || index >= deckArray.Length)
                throw new Exception("Invalid start index");

            string valueToMove = deckArray[index];
            Array.Copy(deckArray, index + 1, deckArray, index, deckArray.Length - index - 1); // shift left
            deckArray[deckArray.Length - 1] = "0";
            return valueToMove;
        }
    }
}