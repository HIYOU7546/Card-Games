namespace Decks
{
    public class Discard : Deck
    {
        /// <summary>
        /// Constructor for the Discard class
        /// </summary>
        /// <param name="includeJokers">The defualt is False.</param>
        /// <param name="decks">The defualt is 2 decks.</param>
        public Discard(bool includeJokers = false, int decks = 2) : base(includeJokers, decks)
        {
            this.includeJokers = includeJokers;
            this.decks = decks;
        }
    }
}