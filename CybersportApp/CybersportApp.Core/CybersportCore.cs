using CybersportApp.Core.CybersportEntities;
using CybersportApp.Core.ModelsForList;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

                    if (country.CountryId != 1)
                        countries.Add(country.Name);
                }
            }

            return countries;
        }

        public static string GetTeam(int teamId)
        {
            using (var context = new CybersportConnection())
            {
                return context.Teams.Find(teamId).Name;
            }
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

        public static ObservableCollection<UsersForList> GetUsers()
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
                    if (user.Role != "Administrator")
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
                    if (tournament.StartDate == "10.10.1010")
                        tournament.StartDate = tournament.EndDate = "Not stated";

                    collection.Add(tournament);
                }
            }

            return collection;
        }

        public static ObservableCollection<string> GetRaitingsNames()
        {
            var collection = new ObservableCollection<string>();
            RatingsCollection = new ObservableCollection<Ratings>();

            using (var context = new CybersportConnection())
            {
                foreach (var raiting in context.Ratings)
                {
                    RatingsCollection.Add(raiting);

                    collection.Add(raiting.RatingValue);
                }
            }

            return collection;
        }

        public static ObservableCollection<string> GetAccountStatusesNames()
        {
            var collection = new ObservableCollection<string>();
            AccountStatusesCollection = new ObservableCollection<AccountStatuses>();

            using (var context = new CybersportConnection())
            {
                foreach (var accountStatus in context.AccountStatuses)
                {
                    AccountStatusesCollection.Add(accountStatus);

                    collection.Add(accountStatus.Status);
                }
            }

            return collection;
        }

        public static ObservableCollection<string> GetDisciplinesNames()
        {
            var collection = new ObservableCollection<string>();
            DisciplinesCollection = new ObservableCollection<Disciplines>();

            using (var context = new CybersportConnection())
            {
                foreach (var discipline in context.Disciplines)
                {
                    DisciplinesCollection.Add(discipline);

                    collection.Add(discipline.Name);
                }
            }

            return collection;
        }

        public static PlayersInformation GetUserInfo(Guid id)
        {
            using (var context = new CybersportConnection())
            {
                return context.PlayersInformation.FirstOrDefault(x => x.UserId == id);
            }
        }
    }
}
