namespace game
{
    public class Turn
    {
        public Player currentPlayer { get; private set; }

        public IRollResult rollResult { get; private set; }

        public Turn(Player player)
        {
            currentPlayer = player;
        }

        public IRollResult rollDice(Dice dice)
        {
            rollResult = dice.Roll();
            return rollResult;
        }

        public bool addPart()
        {
            return currentPlayer.addPart(rollResult.result);
        }
    }
}
