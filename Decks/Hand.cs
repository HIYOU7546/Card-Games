namespace Decks
{
    public class Hands
    {
        private int HandSize;
        private string[][] _Hand = [[]];
        public Hands(int HandSize)
        {
            this.HandSize = HandSize;
            _Hand = new string[HandSize][];
        }

        public void ChangeHandSize(int NewSize)
        {
            HandSize = NewSize;
            _Hand = new string[NewSize][];
        }

        public string[][] GetHand()
        {
            return _Hand;
        }

        public string[] GetCardFromHand(int Position)
        {
            return _Hand[Position];
        }

        public void AlterHand(string Card, int Position)
        {
            _Hand[Position] = new string[] { Card };
        }

        public void ClearHand()
        {
            ChangeHandSize(HandSize);
        }
    }
}