#pragma warning disable CS1717 // Assignment made to same variable

namespace Decks
{
    public class Deck
    {
        /// <summary>
        /// The amount of decks to be used in the game
        /// </summary>
        private double decks;

        /// <summary>
        /// Whether or not to include jokers in the deck
        /// </summary>
        private bool includeJokers;

        /// <summary>
        /// The array representing the deck of cards
        /// </summary>
        private string[] deckArray = [];

        /// <summary>
        /// Constructor for the Deck class
        /// </summary>
        /// <param name="includeJokers">The defualt is False.</param>
        /// <param name="decks">The defualt is 2 decks.</param>
        public void Decks(bool includeJokers = false, int decks = 2)
        {
            this.includeJokers = includeJokers;
            this.decks = decks;
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
                    deckArray[index++] = "RJ";
                    deckArray[index++] = "BJ";
                }
            }
            this.deckArray = deckArray;
        }

        /// <summary>
        /// Shuffles the deck(s) to be used in the game
        /// </summary>
        public void ShuffleDeck()
        {
            Random.Shared.Shuffle(deckArray);
        }
    }
}