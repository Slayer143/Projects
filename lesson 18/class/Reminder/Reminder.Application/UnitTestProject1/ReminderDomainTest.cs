using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reminder.Storage.Core;
using Reminder.Storage.InMemory;
using System;
using Moq;
using Reminder.Receiever.Core;
using System.Collections.Generic;

namespace Reminder.Domain.Tests
{
    [TestClass]
    public class ReminderDomainTest
    {
        [TestMethod]
        public void Method_Run_Should_Update_Ready_To_Send_Reminders_To_Status_Ready()
        {
            var storage = new InMemoryReminderStorage();
			storage.Add(
				DateTimeOffset.Now, 
				null, 
				null, 
				ReminderItemStatus.Awaiting);

			var mockReceiver = new Mock<IReminderReceiever>();
			var fakeReceiver = mockReceiver.Object;

            using (var domain = new ReminderDomain(
                storage,
				fakeReceiver,
                TimeSpan.FromMilliseconds(50),
                TimeSpan.FromMilliseconds(1)))
            {
                domain.Run();
                System.Threading.Thread.Sleep(200);
            }

            var readyList = storage.Get(ReminderItemStatus.Ready);
            Assert.IsNotNull(readyList);
            Assert.AreEqual(1, readyList.Count);
        }

        [TestMethod]
        public void Method_Run_Should_Call_Failed_Event_When_Sending_Throw_Exception()
        {
            var storage = new InMemoryReminderStorage();
            storage.Add(
				DateTimeOffset.Now,
				null, 
				null,
				ReminderItemStatus.Awaiting);

            bool failedEventCalled = false;

			var mockReceiver = new Mock<IReminderReceiever>();
			var fakeReceiver = mockReceiver.Object;

			using (var domain = new ReminderDomain(
                storage,
				fakeReceiver,
                TimeSpan.FromMilliseconds(50),
                TimeSpan.FromMilliseconds(60)))
            {
                domain.SendReminder += (r) =>
                {
                    throw new Exception("Test Exception");
                };

                domain.SendingFailed += (s, e) =>
                {
                    if(e.SendingException.Message == "Test Exception")
                    failedEventCalled = true;
                };

                domain.Run();
                System.Threading.Thread.Sleep(1200);
            }
           
            Assert.IsTrue(failedEventCalled);
        }

        [TestMethod]
        public void Method_Run_Should_Call_Succeeded_Event_When_Sending_Is_Completed()
        {
            DateTimeOffset dateTime = DateTimeOffset.Now;
            const string readyMessage = "ready message",
                contactId = "ABCD123";

            var storage = new InMemoryReminderStorage();

            storage.Add(
                dateTime,
                readyMessage,
                contactId,
				ReminderItemStatus.Awaiting);

            bool secceddedEventCalled = false;

			var mockReceiver = new Mock<IReminderReceiever>();
			var fakeReceiver = mockReceiver.Object;

			using (var domain = new ReminderDomain(
                storage,
				fakeReceiver,
                TimeSpan.FromMilliseconds(50),
                TimeSpan.FromMilliseconds(60)))
            {
                domain.SendReminder += (item) => { };

                domain.SendingSucceeded += (s, e) =>
                {
                    secceddedEventCalled = true;
                };
                domain.Run();
                System.Threading.Thread.Sleep(1200);
            }

            Assert.IsTrue(secceddedEventCalled); 
        }

        [TestMethod]
        public void Method_Run_Should_Call_SendReminder_Method_When_Sending_Is_Completed()
        {
			//var storage = new InMemoryReminderStorage();

			//storage.Add(
			//	dateTime,
			//	readyMessage,
			//	contactId,
			//	ReminderItemStatus.Awaiting);

			var dictionaryForMock = new Dictionary<Guid, ReminderItem>();

			var mockStorage = new Mock<IReminderStorage>();
			mockStorage.Setup(
				x => x.Add(
					It.IsAny<DateTimeOffset>(),
					It.IsAny<string>(),
					It.IsAny<string>(),
					It.IsAny<ReminderItemStatus>()))
				.Returns<DateTimeOffset, string, string, ReminderItemStatus>((date, message, contactId, status) =>
				{
					var newGuid = Guid.NewGuid();
					dictionaryForMock.Add(newGuid, new ReminderItem(newGuid, date, message, contactId, status));
					return newGuid;
				});

			mockStorage.Setup(x => x.Get(
				It.IsAny<Guid>()))
				.Returns<Guid>(id =>
				{
					if (dictionaryForMock.ContainsKey(id))
						return dictionaryForMock[id];

					return null;
				});

			var fakeStorage = mockStorage.Object;

			bool SendReminderMethodCalled = false;

			var mockReceiver = new Mock<IReminderReceiever>();
			var fakeReceiver = mockReceiver.Object;

			using (var domain = new ReminderDomain(
                fakeStorage,
				fakeReceiver,
                TimeSpan.FromMilliseconds(50),
                TimeSpan.FromMilliseconds(60)))
            {
                domain.SendReminder += (ReminderItem reminder) => 
                {
                    if (reminder.Message == readyMessage)
                    {
                        SendReminderMethodCalled = true;
                    }
                };

                domain.Run();
                System.Threading.Thread.Sleep(1200);
            }

            Assert.IsTrue(SendReminderMethodCalled);
        }
	}
}
