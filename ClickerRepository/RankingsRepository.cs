using ClickerRepository.Interfaces;
using ClickerService.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ClickerRepository
{
    public class RankingsRepository : IRankingsRepository
    {
        private DatabaseProvider databaseProvider;

        public RankingsRepository(DatabaseProvider databaseProvider)
        {
            this.databaseProvider = databaseProvider;
        }

        public Dictionary<int, RankingPlayer> GetRanking(string idPlayer, Ranking ranking)
        {
            switch (ranking.rankingType)
            {
                case RankingType.AllPlayers:
                    return GetAllPlayersRanking(idPlayer, ranking, out int playerPlace);
                case RankingType.ByOffset:
                    return GetPlayersByOffset(idPlayer, ranking);
                case RankingType.FromTo:
                    return GetPlayersFromTo(idPlayer, ranking);
            }
            return null;
        }

        private Dictionary<int, RankingPlayer> GetPlayersByOffset(string idPlayer, Ranking ranking)
        {
            int playerPlace;
            var allPlayersRanking = GetAllPlayersRanking(idPlayer, ranking, out playerPlace);
            var playersByOffset = new Dictionary<int, RankingPlayer>();

            playersByOffset.Add(playerPlace, allPlayersRanking.GetValueOrDefault(playerPlace));
            for (int i = 1; i < ranking.offsetBackward; i++)
            {
                playersByOffset.Add(playerPlace - i, allPlayersRanking.GetValueOrDefault(playerPlace - i));
            }
            for (int i = 1; i < ranking.offsetForward; i++)
            {
                playersByOffset.Add(playerPlace + i, allPlayersRanking.GetValueOrDefault(playerPlace + i));
            }
            return playersByOffset;
        }

        private Dictionary<int, RankingPlayer> GetPlayersFromTo(string idPlayer, Ranking ranking)
        {
            int playerPlace;
            var allPlayersRanking = GetAllPlayersRanking(idPlayer, ranking, out playerPlace);
            var playersFromTo = new Dictionary<int, RankingPlayer>();
            for (int i = ranking.offsetBackward; i < ranking.offsetForward; i++)
            {
                playersFromTo.Add(i, allPlayersRanking.GetValueOrDefault(i));
            }
            playersFromTo.Add(playerPlace, allPlayersRanking.GetValueOrDefault(playerPlace));
            return playersFromTo;
        }

        private Dictionary<int, RankingPlayer> GetAllPlayersRanking(string idPlayer, Ranking ranking, out int playerPlace)
        {
            playerPlace = -1;
            using (var connection = databaseProvider.OpenConnection())
            {
                SqlCommand sqlCommand = new SqlCommand("dbo.GetAllPlayersRanking", connection);
                sqlCommand.Parameters.Add(new SqlParameter("@statName", ranking.statName));
                sqlCommand.CommandType = CommandType.StoredProcedure;
                using (var sqlReader = sqlCommand.ExecuteReader())
                {
                    int placeInRanking = 1;
                    Dictionary<int, RankingPlayer> allPlayersRanking = new Dictionary<int, RankingPlayer>();
                    while (sqlReader.Read())
                    {
                        if (idPlayer == Convert.ToString(sqlReader["Id"]))
                        {
                            playerPlace = placeInRanking;
                        }
                        allPlayersRanking.Add(placeInRanking, new RankingPlayer
                        {
                            Id = Convert.ToString(sqlReader["Id"]),
                            IdFacebook = Convert.ToString(sqlReader["IdFacebook"]),
                            Name = Convert.ToString(sqlReader["Name"]),
                            ImageUrl = Convert.ToString(sqlReader["ImageUrl"]),
                            Country = Convert.ToString(sqlReader["Country"]),
                            Score = Convert.ToDouble(sqlReader["Score"])
                        });
                        placeInRanking++;
                    }
                    return allPlayersRanking;
                }
            }
        }
    }
}