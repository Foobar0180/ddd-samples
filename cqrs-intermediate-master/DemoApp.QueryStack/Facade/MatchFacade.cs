using System.Collections.Generic;
using System.Linq;
using DemoApp.Infrastructure.Data;
using DemoApp.Infrastructure.Repositories;
using DemoApp.QueryStack.Dto;
using DemoApp.SharedKernel;

namespace DemoApp.QueryStack.Facade
{
    public class MatchFacade
    {
        private readonly MatchRepository _matchRepository = new MatchRepository();

        /*
         * Should be noted we ideally need a relational table with only three columns. 
         * In alternative, adding a CREATE event for match which should include a 
         * DATE of play to make query of scheduled matches reliable. It depends :)
         * 
         * Here I'm using the SAME db as previous examples also to feed the LIVE module
         * effectively.
         */ 
        public IList<MatchListItem> FindScheduled()
        {
            var queryForMatches = _matchRepository.Find();
            var scheduledMatches = (from m in queryForMatches
                where m.State == (int) MatchState.ToBePlayed
                select new MatchListItem()
                {
                    Id = m.Id,
                    Team1 = m.Team1,
                    Team2 = m.Team2
                }).ToList();
            return scheduledMatches;
        }

        public IList<MatchInProgress> FindInProgress()
        {
            var queryForMatches = _matchRepository.Find();
            const int CODE_IN_PROGRESS_FROM = (int) MatchState.ToBePlayed;
            const int CODE_IN_PROGRESS_TO = (int) MatchState.Finished;

            var matches = (from m in queryForMatches 
                           where m.State > CODE_IN_PROGRESS_FROM && m.State < CODE_IN_PROGRESS_TO
                           select m).ToList();
            var liveMatches = (from m in matches
                select new MatchInProgress
                {
                    Id = m.Id,
                    Team1 = m.Team1,
                    Team2 = m.Team2,
                    Goal1 = m.Score1.ToString(),
                    Goal2 = m.Score2.ToString(),
                    Period = m.Period.ToString(),
                    State = (MatchState) m.State,
                    TimeoutSummary1 = m.Timeouts1,
                    TimeoutSummary2 = m.Timeouts2
                }).ToList();
            return liveMatches;
        }

        public MatchInProgress FindById(string id)
        {
            var match = _matchRepository.FindById(id);
            return CopyToMatchInProgress(match);
        }

        #region Private

        private static MatchInProgress CopyToMatchInProgress(Match match)
        {
            var mip = new MatchInProgress
            {
                Id = match.Id,
                State = (MatchState)match.State,
                Team1 = match.Team1,
                Team2 = match.Team2,
                Goal1 = match.Score1 < 0 ? "" : match.Score1.ToString(),
                Goal2 = match.Score2 < 0 ? "" : match.Score2.ToString(),
                Period = match.Period <= 0 ? "" : match.Period.ToString(),
                TimeoutSummary1 = match.Timeouts1,
                TimeoutSummary2 = match.Timeouts2
            };
            return mip;
        } 

        #endregion
    }
}