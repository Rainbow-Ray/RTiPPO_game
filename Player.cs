using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game
{
    public class Player
    {
        public string name { get; private set; }
        public int id { get; private set; }
        public int score { get; private set; } = 0;
        public int numberOfBugs { get; private set; } = 0;
        public Bug currentBug { get; private set; } = null;

        public Player(string name, int id) {
            this.name = name;
            this.id = id;
        }

        private void addScore(int value) { score += value; }
        private void addNumberOfBugs(int value) { numberOfBugs += value; }
        public void createCurrentBug() {
            var bug = new Bug();
            this.currentBug = bug; 
        }

        public bool isBugComplete() { return currentBug.getState() == BugState.complete; }

        public bool addPart(BugPart result)
        {
            var isAdded = currentBug.changeState(result);

            if (isAdded)
            {
                var value = 1;
                if (isBugComplete())
                {
                    value = 14;
                    addNumberOfBugs(1);
                }
                addScore(value);
            }
            return isAdded;
        }

    }
}
