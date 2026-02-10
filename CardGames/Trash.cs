using Decks;

namespace CardGames
{
    public class TrashGame
    {
        public async Task Play()
        {
            bool timerDone = false;
            Console.Clear();
            Console.WriteLine("Starting Trash...");
            var timer = new System.Timers.Timer(2000);
            timer.Elapsed += (s, e) =>
                Console.Clear();
                timerDone = true;
            timer.AutoReset = false; // Ensure it only runs once
            timer.Start();
        }

        private Deck _Deck = new Deck(false, 1);
        private Hands _PlayerHand = new Hands(4);
        private Hands _ComputerHand = new Hands(4);

        private void Deal(int cardsForPlayer, Hands HandForPlayer, int cardsForDealer, Hands HandForDealer)
        {
            int l = 0;
            int levelForBlank = 0;
            int levelForCard = 1;
            for (int i = 0; i < Math.Max(cardsForPlayer, cardsForDealer); i++)
            {
                if (cardsForPlayer < i)
                {
                    HandForPlayer.AlterHand(CardAscii.GetCardAscii("faceDown"), l * levelForBlank);
                    HandForPlayer.AlterHand(CardAscii.GetCardAscii(_Deck.DrawNextFromDeck()), l * levelForCard);
                }
                if (cardsForDealer < i)
                {
                    HandForPlayer.AlterHand(CardAscii.GetCardAscii("faceDown"), l * levelForBlank);
                    HandForDealer.AlterHand(CardAscii.GetCardAscii(_Deck.DrawNextFromDeck()), l * levelForCard);
                }
                if (l == 5)
                {
                    levelForBlank++;
                    levelForCard++;
                    l = 0;
                }
                else l++;
            }
        }
    }
}