namespace game
{
    public interface IRollResult
    {
        BugPart result { get; }
        BugParts getResult();

        string getResultName();
    }
}
