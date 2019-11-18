﻿using Reminder.Storage.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Reminder.Storage.WebApi.Core
{
	public class ReminderItemGetModel
	{
		public Guid Id { get; set; }

		public DateTimeOffset Date { get; set; }

		public string Message { get; set; }

		public string ContactId { get; set; }

		public ReminderItemStatus Status { get; set; }

        public ReminderItemGetModel() { }

        public ReminderItemGetModel(ReminderItem reminderItem)
        {
            Id = reminderItem.Id;
            Date = reminderItem.Date;
            Message = reminderItem.Message;
            ContactId = reminderItem.ContactId;
            Status = reminderItem.Status;
        }
	}
}
