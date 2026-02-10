namespace Decks
{
    public class Hands
    {
        /// <summary>
        /// The normal size of the hand
        /// </summary>
        private int HandSize;

        /// <summary>
        /// The array representing the hand(s) of cards
        /// </summary>
        private string[][] _Hand = [[]];

        /// <summary>
        /// Constructor for the Hand class
        /// </summary>
        /// <param name="HandSize">The maximum size of the hand. Defaults to 0 as not defigned</param>
        public Hands(int HandSize = 0)
        {
            this.HandSize = HandSize;
            if (HandSize > 0)
                _Hand = new string[HandSize][];
        }

        /// <summary>
        /// Changes the size of the hand
        /// </summary>
        /// <param name="NewSize">The new maximum size of a hand. Defualts to 0 as not defigned</param>
        public void ChangeHandSize(int NewSize = 0)
        {
            HandSize = NewSize;
            if (NewSize > 0)
                _Hand = new string[NewSize][];
            else _Hand = [[]];
        }

        /// <summary>
        /// Returns the current hand of cards.
        /// </summary>
        /// <returns>All the cards in the hand</returns>
        public string[][] GetHand()
        {
            return _Hand;
        }

        /// <summary>
        /// Returns the card at the specified position in the hand.
        /// </summary>
        /// <param name="Position">The position of the card you want to grab</param>
        /// <returns></returns>
        public string[] GetCardFromHand(int Position)
        {
            return _Hand[Position];
        }

        /// <summary>
        /// Alters the card at the specified position in the hand with the provided card.
        /// </summary>
        /// <param name="Card">The new card to place in the hand</param>
        /// <param name="Position">The lcoation to put the card</param>
        public void AlterHand(string[] Card, int Position)
        {
            _Hand[Position] = Card;
        }

        /// <summary>
        /// Returns the card at the specified position in the hand and replaces it with the provided card.
        /// </summary>
        /// <param name="Card">The new card to place in the hand</param>
        /// <param name="Position">The lcoation to put the card</param>
        /// <returns>The card that you just replaced</returns>
        public string[] GetAndAlterHand(string[] Card, int Position)
        {
            string[] OldCard = _Hand[Position];
            _Hand[Position] = Card;
            return OldCard;
        }

        /// <summary>
        /// Clears the hand of all cards, resetting it to an empty state with the current hand size.
        /// </summary>
        public void ClearHand()
        {
            ChangeHandSize(HandSize);
        }
    }
}