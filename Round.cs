using System.Collections.Generic;
using System.Linq;

namespace game
{
    public class Round
    {
        private List<Turn> turnsOfPlayer { get; set; } = new List<Turn>();

        public Round() { }

        public void addTurn(Turn turn)
        {
            turnsOfPlayer.Add(turn);
        }
        public Turn getLastTurn()
        {
            return turnsOfPlayer.Last();
        }
    }
}
