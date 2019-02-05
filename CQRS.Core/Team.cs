namespace CQRS.Core
{
    public class Team
    {
        public Team(string name)
        {
            Name = name;
        }

        protected Team()
        {
        }

        public string Name { get; protected set; }

        public int Matches { get; protected set; }

        public int Points { get; protected set; }

        public int GoalsScored { get; protected set; }

        public int GoalsLost { get; protected set; }

        public int GoalsBalance => GoalsScored - GoalsLost;

        public void InsertResult(int goalsScored, int goalsLost)
        {
            Matches++;
            GoalsScored += goalsScored;
            GoalsLost += goalsLost;

            if (goalsScored > goalsLost)
            {
                Points += 3;
            }
            else if (goalsScored == goalsLost)
            {
                Points += 1;
            }
        }
    }
}
