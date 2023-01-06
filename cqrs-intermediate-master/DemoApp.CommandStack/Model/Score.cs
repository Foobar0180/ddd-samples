namespace DemoApp.CommandStack.Model
{
    public sealed class Score  
    {
        private const int MAX_GOALS = 99;

        public Score(int goals1 = 0, int goals2 = 0)
        {
            //Contract.Requires<ArgumentException>(goals1.BetweenWith(0, MaxGoals));
            //Contract.Requires<ArgumentException>(goals2.BetweenWith(0, MaxGoals));

            TotalGoals1 = goals1;
            TotalGoals2 = goals2;
        }

        public int TotalGoals1 { get; private set; }
        public int TotalGoals2 { get; private set; }

        #region Informational

        public override string ToString()
        {
            return $"{TotalGoals1} - {TotalGoals2}";
        }

        public bool IsLeading(TeamId id)
        {
            if (id == TeamId.Home)
                return TotalGoals1 > TotalGoals2;
            if (id == TeamId.Visitors)
                return TotalGoals2 > TotalGoals1;
            return false;
        }

        #endregion

        public override bool Equals(object obj)
        {
            if (!(obj is Score otherScore))
                return false;

            return otherScore.TotalGoals1 == TotalGoals1 && 
                otherScore.TotalGoals2 == TotalGoals2;
        }
        public override int GetHashCode()
        {
 	         return (TotalGoals2^TotalGoals2).GetHashCode();
        }
    }
}