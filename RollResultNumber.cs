namespace game
{
    public class RollResultNumber : IRollResult
    {
        public BugPart result { get; private set; }

        public RollResultNumber(BugPart result)
        {
            this.result = result;
        }

        public BugParts getResult()
        {
            return result.name;
        }

        public string getResultName()
        {
            return result.diceNumber.ToString();
        }

    }
}
