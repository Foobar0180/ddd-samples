using DemoApp.SharedKernel;
using System;
using DemoApp.SharedKernel.Extensions;

namespace DemoApp.CommandStack.Model
{
    public class Match  
    {
        // Id, Team1, Team2 immutable => if they change, it is another match. 
        // Consider adding a new type for these 3 properties.
        public static Match Undefined = new Match("", "", "");

        // Constants
        private const int TOTAL_PERIODS_IN_MATCH = 4;
        private const int MAX_TIMEOUTS_PER_PERIOD = 1;

        public Match()
        {
            InitializeAsDefault();
        }

        public Match(string id, string team1, string team2)
        {
            InitializeAsDefault();
            Id = id;
            Team1 = team1;
            Team2 = team2;
            State = MatchState.ToBePlayed;
        }

        public string Id { get; private set; }
        public string Team1 { get; private set; }
        public string Team2 { get; private set; }
        public int TimeoutCount1 { get; internal set; }
        public int TimeoutCount2 { get; internal set; }
        public Score CurrentScore { get; internal set; }
        public bool IsBallInPlay { get; private set; }
        public int CurrentPeriod { get; internal set; }
        public MatchState State { get; internal set; }
        public string Venue { get; set; }
        public DateTime Day { get; set; }   // deserves further thinking in relationship with Score/State

        #region Informational

        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(Id) &&
                   !string.IsNullOrWhiteSpace(Team1) &&
                   !string.IsNullOrWhiteSpace(Team2) &&
           
                   State != MatchState.Unknown;
        }

        public bool CanRequestTimeout(TeamId id)
        {
            if (id == TeamId.Home && TimeoutCount1 < MAX_TIMEOUTS_PER_PERIOD)
                return true;
            if (id == TeamId.Visitors && TimeoutCount2 < MAX_TIMEOUTS_PER_PERIOD)
                return true;
            return false;
        }

        public bool IsInProgress()
        {
            return State > MatchState.ToBePlayed && State < MatchState.Finished;
        }

        public Boolean IsFinished()
        {
            return State == MatchState.Finished;
        }

        public Boolean IsScheduled()
        {
            return State == MatchState.ToBePlayed;
        }

        public string TimeoutSummary(TeamId id)
        {
            if (id == TeamId.Unknown)
                return string.Empty;

            var count = id == TeamId.Home ? TimeoutCount1 : TimeoutCount2;
            return $"{count}/{MAX_TIMEOUTS_PER_PERIOD}";
        }

        public string Tostring()
        {
            return IsScheduled()
                ? $"{Team1} vs. {Team2}"
                : $"{Team1} / {Team2}  {CurrentScore}";
        }

        #endregion

        #region Behavior

        public Match Start()
        {
            if (!IsValid())
                return this;

            State = MatchState.Warmup;
            return this;
        }

        public void Finish()
        {
            if (!IsValid())
                return;

            State = MatchState.Finished;
        }

        public Match Goal(TeamId id)
        {
            if (!IsValid())
                return this;

            if (id == TeamId.Home)
            {
                CurrentScore = new Score(CurrentScore.TotalGoals1.Increment(), CurrentScore.TotalGoals2);
            }
            if (id == TeamId.Visitors)
            {
                CurrentScore = new Score(CurrentScore.TotalGoals1,  CurrentScore.TotalGoals2.Increment());
            }

            return this;
        }

       public Match StartPeriod()
        {
            if (!IsValid())
                return this;
            
            ResetTimeouts();
            CurrentPeriod = CurrentPeriod.Increment(TOTAL_PERIODS_IN_MATCH);
            State = MatchState.PlayInProgress;
            IsBallInPlay = true;
            return this;
        }

        public Match EndPeriod()
        {
            if (!IsValid())
                return this;

            IsBallInPlay = false;
            State = MatchState.Interval;

            if (CurrentPeriod == TOTAL_PERIODS_IN_MATCH)
                Finish();

            return this;
        }

        public Match Timeout(TeamId id)
        {
            if (!IsValid())
                return this;

            // Should we do it?
            if (!CanRequestTimeout(id))
                return this;

            switch (id)
            {
                case TeamId.Home:
                    TimeoutCount1 = TimeoutCount1.Increment(MAX_TIMEOUTS_PER_PERIOD);
                    break;
                case TeamId.Visitors:
                    TimeoutCount2 = TimeoutCount2.Increment(MAX_TIMEOUTS_PER_PERIOD);
                    break;
            }

            IsBallInPlay = false;
            State = MatchState.Timeout;
            return this;
        }

        public Match Resume()
        {
            if (!IsValid())
                return this;

            IsBallInPlay = true;
            State = MatchState.PlayInProgress;
            return this;
        }

        #endregion

        #region Internal

        private void InitializeAsDefault()
        {
            State = MatchState.Unknown;
            CurrentScore = new Score();
            Venue = string.Empty;
            Day = DateTime.Today;
            IsBallInPlay = false;
            CurrentPeriod = 0;
            ResetTimeouts();
        }

        private void ResetTimeouts()
        {
            TimeoutCount1 = 0;
            TimeoutCount2 = 0;
        }

        #endregion
    }
}
