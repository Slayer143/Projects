using CybersportApp.Core.CybersportEntities;
using CybersportApp.Core.ModelsForList;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;

namespace CybersportApp.Core
{
    public static class CybersportCore
    {
        public static ObservableCollection<Countries> CountriesCollection { get; set; }

        public static ObservableCollection<Roles> RolesCollection { get; set; }

        public static ObservableCollection<Teams> TeamsCollection { get; set; }

        public static ObservableCollection<Ratings> RatingsCollection { get; set; }

        public static ObservableCollection<AccountStatuses> AccountStatusesCollection { get; set; }

        public static ObservableCollection<Disciplines> DisciplinesCollection { get; set; }

        public static void AddUser(Users user, PlayersInformation userInformation)
        {
            using (var context = new CybersportConnection())
            {
                context.Users.Add(user);
                context.SaveChanges();

                context.PlayersInformation.Add(userInformation);
                context.SaveChanges();
            }
        }

        public static bool CheckLogin(string login)
        {
            if (login == "Try another login"
                || login == string.Empty
                || login.Contains(' '))
                return false;

            using (var context = new CybersportConnection())
            {
                var user = context.Users.FirstOrDefault(x => x.Login == login);

                return user == null
                    ? true
                    : false;
            }
        }

        public static Users CheckUser(string login, string password)
        {
            var user = new Users();

            using (var context = new CybersportConnection())
            {
                return context.Users
                   .FirstOrDefault(x =>
                   x.Login == login
                   && x.Password == password);
            }
        }

        public static ObservableCollection<string> GetRoles()
        {
            var roles = new ObservableCollection<string>();
            RolesCollection = new ObservableCollection<Roles>();

            using (var context = new CybersportConnection())
            {
                foreach (var role in context.Roles)
                {
                    RolesCollection.Add(role);

                    if (role.RoleId != 1)
                        roles.Add(role.Name);
                }
            }

            return roles;
        }

        public static ObservableCollection<string> GetCountries()
        {
            var countries = new ObservableCollection<string>();
            CountriesCollection = new ObservableCollection<Countries>();

            using (var context = new CybersportConnection())
            {
                foreach (var country in context.Countries)
                {
                    CountriesCollection.Add(country);

                    if (country.CountryId != 100)
                        countries.Add(country.Name);
                }
            }

            return countries;
        }

        public static void SaveTeamChange(string teamName, Guid id)
        {
            using (var context = new CybersportConnection())
            {
                var user = context.Users.FirstOrDefault(x => x.UserId == id);
                user.TeamId = context.Teams.FirstOrDefault(x => x.Name == teamName).TeamId;
                context.SaveChanges();
            }
        }

        public static void SaveOtherTeamChange(string teamName, string login)
        {
            using (var context = new CybersportConnection())
            {
                var user = context.Users.FirstOrDefault(x => x.Login == login);
                user.TeamId = context.Teams.FirstOrDefault(x => x.Name == teamName).TeamId;
                context.SaveChanges();
            }
        }

        public static string GetTeam(int teamId)
        {
            using (var context = new CybersportConnection())
            {
                return context.Teams.Find(teamId).Name;
            }
        }

        public static ObservableCollection<string> GetTeamsCollection()
        {
            var teamsNames = new ObservableCollection<string>();

            using (var context = new CybersportConnection())
            {
                foreach (var teams in context.Teams)
                {
                    teamsNames.Add(teams.Name);
                }
            }

            return teamsNames;
        }

        public static ObservableCollection<TeamsForList> GetTeams()
        {
            var collection = new ObservableCollection<TeamsForList>();

            using (var context = new CybersportConnection())
            {
                var collectionFromDb = from teams in context.Teams
                                       join disciplines in context.Disciplines on teams.DisciplineId equals disciplines.DisciplineId
                                       join countries in context.Countries on teams.CountryId equals countries.CountryId
                                       select new TeamsForList
                                       {
                                           Name = teams.Name,
                                           ShortName = teams.ShortName,
                                           Discipline = disciplines.Name,
                                           Country = countries.Name
                                       };

                foreach (var team in collectionFromDb)
                {
                    if (team.Name != "No Team")
                        collection.Add(team);
                }
            }

            return collection;
        }

        public static ObservableCollection<UsersForList> GetUsers(string login)
        {
            var collection = new ObservableCollection<UsersForList>();

            using (var context = new CybersportConnection())
            {
                var collectionFromDb = from users in context.Users
                                       join countries in context.Countries on users.CountryId equals countries.CountryId
                                       join teams in context.Teams on users.TeamId equals teams.TeamId
                                       join roles in context.Roles on users.RoleId equals roles.RoleId
                                       select new UsersForList
                                       {
                                           Login = users.Login,
                                           FullName = $"{users.LastName} " +
                                           $"{users.Name} " +
                                           $"{users.SecondName}",
                                           BirthDate = $"{users.BirthDate}".Substring(0, 10),
                                           Country = countries.Name,
                                           Role = roles.Name,
                                           Team = teams.Name
                                       };

                foreach (var user in collectionFromDb)
                {
                    if (user.Login != login)
                        collection.Add(user);
                }
            }

            return collection;
        }

        public static ObservableCollection<TournamentsForList> GetTournaments()
        {
            var collection = new ObservableCollection<TournamentsForList>();

            using (var context = new CybersportConnection())
            {
                var collectionFromDb = from tournaments in context.Tournaments
                                       join tournamentsTypes in context.TournamentsTypes on tournaments.TournamentTypeId equals tournamentsTypes.TournamentTypeId
                                       join disciplines in context.Disciplines on tournaments.DisciplineId equals disciplines.DisciplineId
                                       select new TournamentsForList
                                       {
                                           Name = tournaments.Name,
                                           PrizePool = $"{Convert.ToInt32(tournaments.PrizePool)}$",
                                           FirstPlace = $"{Convert.ToInt32(tournaments.FirstPlacePrize)}$",
                                           SecondPlace = $"{Convert.ToInt32(tournaments.SecondPlacePrize)}$",
                                           ThirdPlace = $"{Convert.ToInt32(tournaments.ThirdPlacePrize)}$",
                                           StartDate = $"{tournaments.StartDate}".Substring(0, 10),
                                           EndDate = $"{tournaments.EndDate}".Substring(0, 10),
                                           Participants = tournaments.Participants,
                                           TournamentType = tournamentsTypes.Name,
                                           Discipline = disciplines.Name
                                       };

                foreach (var tournament in collectionFromDb)
                {
                    if (tournament.StartDate == DateTimeOffset.MinValue.ToString().Substring(0, 10))
                        tournament.StartDate = "Not stated";

                    if (tournament.EndDate == DateTimeOffset.MinValue.ToString().Substring(0, 10))
                        tournament.EndDate = "Not stated";

                    collection.Add(tournament);
                }
            }

            return collection;
        }

        public static void GetRaitingsNames()
        {
            RatingsCollection = new ObservableCollection<Ratings>();

            using (var context = new CybersportConnection())
            {
                foreach (var raiting in context.Ratings)
                {
                    RatingsCollection.Add(raiting);
                }
            }
        }

        public static void GetAccountStatusesNames()
        {
            AccountStatusesCollection = new ObservableCollection<AccountStatuses>();

            using (var context = new CybersportConnection())
            {
                foreach (var accountStatus in context.AccountStatuses)
                {
                    AccountStatusesCollection.Add(accountStatus);
                }
            }
        }

        public static void GetDisciplinesNames()
        {
            DisciplinesCollection = new ObservableCollection<Disciplines>();

            using (var context = new CybersportConnection())
            {
                foreach (var discipline in context.Disciplines)
                {
                    DisciplinesCollection.Add(discipline);
                }
            }
        }

        public static PlayersInformation GetUserInfo(Guid id)
        {
            using (var context = new CybersportConnection())
            {
                return context.PlayersInformation.FirstOrDefault(x => x.UserId == id);
            }
        }

        public static PlayersInformation GetUserInfo(string login)
        {
            using (var context = new CybersportConnection())
            {
                var id = context.Users.FirstOrDefault(x => x.Login == login).UserId;
                return context.PlayersInformation.FirstOrDefault(x => x.UserId == id);
            }
        }

        public static void AddDetailedInfo(
            Guid userId,
            string rating,
            string discipline,
            string accountStatus,
            decimal totalEarnings,
            int careerStart)
        {
            var info = new PlayersInformation();

            info.UserId = userId;

            info.RatingId = CybersportCore
            .RatingsCollection
            .FirstOrDefault(x => x.RatingValue == rating)
            .RatingId;

            info.DisciplineId = CybersportCore
            .DisciplinesCollection
            .FirstOrDefault(x => x.Name == discipline)
            .DisciplineId;

            info.AccountStatusId = CybersportCore
            .AccountStatusesCollection
            .FirstOrDefault(x => x.Status == accountStatus)
            .AccountStatusId;

            info.TotalEarnings = totalEarnings;

            info.CareerStartYear = careerStart;

            using (var context = new CybersportConnection())
            {
                context.PlayersInformation.Add(info);
                context.SaveChanges();
            }

        }

        public static void UpdateDetailedInfo(Guid userId,
            string rating,
            string discipline,
            string accountStatus,
            decimal totalEarnings,
            int careerStart)
        {
            var info = new PlayersInformation
            {
                UserId = userId,

                RatingId = CybersportCore
                .RatingsCollection
                .FirstOrDefault(x => x.RatingValue == rating)
                .RatingId,

                DisciplineId = CybersportCore
                .DisciplinesCollection
                .FirstOrDefault(x => x.Name == discipline)
                .DisciplineId,

                AccountStatusId = CybersportCore
                .AccountStatusesCollection
                .FirstOrDefault(x => x.Status == accountStatus)
                .AccountStatusId,

                TotalEarnings = totalEarnings,

                CareerStartYear = careerStart
            };

            using (var context = new CybersportConnection())
            {
                var oldInfo = context.PlayersInformation.FirstOrDefault(x => x.UserId == userId);
                oldInfo = info;
                context.SaveChanges();
            }
        }

        public static void UpdatePhoto(
            Guid userId,
            byte[] photo)
        {
            using (var context = new CybersportConnection())
            {
                var user = context.Users.FirstOrDefault(x => x.UserId == userId);
                user.Photo = photo;
                context.SaveChanges();
            }
        }

        public static void AddTeam(
            string name,
            string shortName,
            string discipline,
            string country)
        {
            using (var context = new CybersportConnection())
            {
                var team = new Teams
                {
                    TeamId = context.Teams.ToList().Count,
                    Name = name,
                    ShortName = shortName,
                    CountryId = context.Countries.First(x => x.Name == country).CountryId,
                    DisciplineId = context.Disciplines.First(x => x.Name == discipline).DisciplineId
                };

                if (team.TeamId == 100)
                    team.TeamId++;

                context.Teams.Add(team);
                context.SaveChanges();
            }
        }

        public static ObservableCollection<string> GetTournamentsTypes()
        {
            var collection = new ObservableCollection<string>();

            using (var context = new CybersportConnection())
            {
                foreach (var type in context.TournamentsTypes)
                {
                    collection.Add(type.Name);
                }
            }

            return collection;
        }

        public static void AddTournament(
            string name,
            string prizePool,
            string firstPrize,
            string secontPrize,
            string thirdPrize,
            string startDate,
            string endDate,
            string participants,
            string tournamentType,
            string discipline)
        {
            if (startDate == null)
                startDate = DateTimeOffset.MinValue.ToString();

            if (endDate == null)
                endDate = DateTimeOffset.MinValue.ToString();

            using (var context = new CybersportConnection())
            {
                var tournament = new Tournaments
                {
                    TournamentId = context.Tournaments.ToList().Count + 1,
                    Name = name,
                    PrizePool = Convert.ToDecimal(prizePool),
                    FirstPlacePrize = Convert.ToDecimal(firstPrize),
                    SecondPlacePrize = Convert.ToDecimal(secontPrize),
                    ThirdPlacePrize = Convert.ToDecimal(thirdPrize),
                    StartDate = DateTimeOffset.Parse(startDate),
                    EndDate = DateTimeOffset.Parse(endDate),
                    Participants = Convert.ToInt32(participants),
                    TournamentTypeId = context.TournamentsTypes.FirstOrDefault(x => x.Name == tournamentType).TournamentTypeId,
                    DisciplineId = context.Disciplines.FirstOrDefault(x => x.Name == discipline).DisciplineId
                };

                context.Tournaments.Add(tournament);
                context.SaveChanges();
            }
        }

        public static Users GetUser(string login)
        {
            using (var context = new CybersportConnection())
            {
                return context.Users.FirstOrDefault(x => x.Login == login);
            }
        }

        public static Guid GetUserId(string login)
        {
            using (var context = new CybersportConnection())
            {
                return context.Users.FirstOrDefault(x => x.Login == login).UserId;
            }
        }

        public static List<Guid> GetUsersId(Guid id)
        {
            var collection = new List<Guid>();

            using (var context = new CybersportConnection())
            {
                var list = context.Messages.Where(x => x.SenderId == id
                || x.RecipientId == id).ToList(); 

                foreach (var elem in list)
                {
                    if (elem.SenderId == id)
                        collection.Add(elem.RecipientId);

                    if (elem.RecipientId == id)
                        collection.Add(elem.SenderId);
                }
            }

            collection = collection.Distinct().ToList();

            return collection;
        }

        public static string GetFullName(Guid id)
        {
            using (var context = new CybersportConnection())
            {
                return context.Users.FirstOrDefault(x => x.UserId == id).Login;
            }
        }

        public static List<Messages> GetMessages(Guid senderId, Guid recipientId)
        {
            using (var context = new CybersportConnection())
            {
                return context.Messages.Where(x => (x.SenderId == senderId
                && x.RecipientId == recipientId)
                || (x.SenderId == recipientId
                && x.RecipientId == senderId)).ToList();
            }
        }

        public static void SendMessage(
            Guid senderId,
            string message,
            Guid _recipientId)
        {
            using (var context = new CybersportConnection())
            {
                var newMessage = new Messages
                {
                    SenderId = senderId,
                    RecipientId = _recipientId,
                    MessageTime = DateTime.Now,
                    MessageText = message,
                    MessageId = Guid.NewGuid()
                };

                context.Messages.Add(newMessage);
                context.SaveChanges();
            }
        }

        public static void VerifyAccount(string login)
        {
            using (var context = new CybersportConnection())
            {
                var userId = context.Users.FirstOrDefault(x => x.Login == login).UserId;

                var accountInfo = context.PlayersInformation.FirstOrDefault(x => x.UserId == userId);
                accountInfo.AccountStatusId = 1;
                context.SaveChanges();
            }
        }

        public static void AskToVerifyAccount(Guid userId)
        {
            using (var context = new CybersportConnection())
            {
                foreach (var admin in context.Users.Where(x => x.RoleId == 1).ToList())
                {
                    Messages message = new Messages
                    {
                        SenderId = userId,
                        RecipientId = admin.UserId,
                        MessageId = Guid.NewGuid(),
                        MessageText = "Hello, can you check and verify my account?",
                        MessageTime = DateTime.Now
                    };

                    context.Messages.Add(message);
                    context.SaveChanges();
                }
            }
        }

        public static void LeaveTeam(Guid id)
        {
            using (var context = new CybersportConnection())
            {
                var user = context.Users.FirstOrDefault(x => x.UserId == id);
                user.TeamId = 100;
                context.SaveChanges();
            }
        }

        public static void InviteToTheTeam(Guid senderId, string recipientLogin, int teamId)
        {
            using (var context = new CybersportConnection())
            {
                var message = new Messages
                {
                    SenderId = senderId,
                    RecipientId = context.Users.FirstOrDefault(x => x.Login == recipientLogin).UserId,
                    MessageId = Guid.NewGuid(),
                    MessageText = $"Hello, I am {context.Users.FirstOrDefault(x => x.UserId == senderId).Name } " +
                    $"from {context.Teams.FirstOrDefault(x => x.TeamId == teamId).Name} " +
                    $"and I want to invite you to our team",
                    MessageTime = DateTime.Now
                };

                context.Messages.Add(message);
                context.SaveChanges();
            }
        }
    }
}
