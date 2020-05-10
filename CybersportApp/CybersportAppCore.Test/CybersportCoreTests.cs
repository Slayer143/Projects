using System;
using System.Linq;
using CybersportApp.Core;
using CybersportApp.Core.CybersportEntities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CybersportAppCore.Test
{
    [TestClass]
    public class CybersportCoreTests
    {
        [TestMethod]
        public void Check_Login_Function_Works_Correctly()
        {
            string loginOne = "Slayer143";
            string loginTwo = "Slar12141";

            var resOne = CybersportCore.CheckLogin(loginOne);
            var resTwo = CybersportCore.CheckLogin(loginTwo);

            Assert.IsFalse(resOne);
            Assert.IsTrue(resTwo);
        }

        [TestMethod]
        public void Check_User_Function_Works_Correctly()
        {
            string
                loginOne = "Slayer143",
                passwordOne = "Ybrbnf2025@",
                loginTwo = "Slayer143",
                passwordTwo = " ";

            Assert.IsNotNull(CybersportCore.CheckUser(loginOne, passwordOne));
            Assert.IsNull(CybersportCore.CheckUser(loginTwo, passwordTwo));
        }

        [TestMethod]
        public void Get_Roles_Function_Works_Correctly()
        {
            Assert.IsNotNull(CybersportCore.GetRoles());
        }

        [TestMethod]
        public void Get_Countries_Function_Works_Correctly()
        {
            Assert.IsNotNull(CybersportCore.GetCountries());
        }

        [TestMethod]
        public void Get_Team_Function_Works_Correctly()
        {
            int teamId = 1;

            string teamName = CybersportCore.GetTeam(teamId);

            Assert.IsNotNull(teamName);
            Assert.AreEqual(teamName, "Team Secret");
        }

        [TestMethod]
        public void Get_Teams_Collection_Function_Works_Correctly()
        {
            Assert.IsNotNull(CybersportCore.GetTeamsCollection());
        }

        [TestMethod]
        public void Get_Users_Function_Works_Correctly()
        {
            string login = "Slayer";

            var users = CybersportCore.GetUsers(login);

            Assert.IsNotNull(users);
            Assert.IsNull(users.FirstOrDefault(x => x.Login == login));
        }

        [TestMethod]
        public void Get_Tournaments_Function_Works_Correctly()
        {
            Assert.IsNotNull(CybersportCore.GetTournaments());
        }

        [TestMethod]
        public void Get_Rating_Names_Function_Works_Correctly()
        {
            CybersportCore.GetRaitingsNames();

            Assert.IsNotNull(CybersportCore.RatingsCollection);
        }

        [TestMethod]
        public void Get_Account_Statuses_Names_Function_Works_Correctly()
        {
            CybersportCore.GetAccountStatusesNames();

            Assert.IsNotNull(CybersportCore.AccountStatusesCollection);
        }

        [TestMethod]
        public void Get_Disciplines_Names_Function_Works_Correctly()
        {
            CybersportCore.GetDisciplinesNames();

            Assert.IsNotNull(CybersportCore.DisciplinesCollection);
        }

        [TestMethod]
        public void Get_User_Info_Function_Works_Correctly()
        {
            Guid id = Guid.Parse("13fbc11f-a8ab-4e45-8f43-001ba90861a9");
            string login = "Puppey";

            var firstRes = CybersportCore.GetUserInfo(id);
            var secondRes = CybersportCore.GetUserInfo(login);

            Assert.IsNotNull(firstRes);
            Assert.IsNotNull(secondRes);
        }

        [TestMethod]
        public void Get_Tournaments_Types_Function_Works_Correctly()
        {
            var collection = CybersportCore.GetTournamentsTypes();

            Assert.IsNotNull(collection);
        }

        [TestMethod]
        public void Get_User_Function_Works_Correctly()
        {
            string loginOne = "Puppey";
            string loginTwo = " ";
            Guid userId = Guid.Parse("13fbc11f-a8ab-4e45-8f43-001ba90861a9");

            var userOne = CybersportCore.GetUser(loginOne);
            var userTwo = CybersportCore.GetUser(loginTwo);

            Assert.IsNotNull(userOne);
            Assert.IsNull(userTwo);
            Assert.AreEqual(userOne.UserId, userId);
        }

        [TestMethod]
        public void Get_User_Id_Function_Works_Correctly()
        {
            string login = "Puppey";
            Guid userId = Guid.Parse("13fbc11f-a8ab-4e45-8f43-001ba90861a9");

            var id = CybersportCore.GetUserId(login);

            Assert.IsNotNull(id);
            Assert.AreEqual(id, userId);
        }

        [TestMethod]
        public void Get_Users_Id_Function_Works_Correctly()
        {
            Guid userId = Guid.Parse("22cb3320-89dd-4e0d-94fd-377857ee26ad");

            var collection = CybersportCore.GetUsersId(userId);

            Assert.IsNotNull(collection);
        }

        [TestMethod]
        public void Get_Full_Name_Function_Works_Correctly()
        {
            Guid userId = Guid.Parse("13fbc11f-a8ab-4e45-8f43-001ba90861a9");

            var name = CybersportCore.GetFullName(userId);

            Assert.IsNotNull(name);
            Assert.AreEqual(name, "Puppey");
        }

        [TestMethod]
        public void Get_Messages_Function_Works_Correctly()
        {
            Guid senderIdOne = Guid.Parse("d5007fec-8b41-4ee6-927f-a4a764f582c6");
            Guid recipientIdOne = Guid.Parse("68c736ce-aa56-4e1f-9266-5e4c5b331020");

            var collectionOne = CybersportCore.GetMessages(senderIdOne, recipientIdOne);

            Assert.IsNotNull(collectionOne);
        }
    }
}
