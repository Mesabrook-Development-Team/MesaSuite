﻿using MesaSuite.Models.security;
using System;
using Towing.History;

namespace MesaSuite.Models.mesasys
{
    public class NotificationEvent
    {
        public long? NotificationEventID { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public string Parameters { get; set; }
        public string[] ParametersArray => Parameters?.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries) ?? new string[0];
        public ScopeTypes ScopeType { get; set; }
        public string DefaultNotificationText { get; set; }
        public Guid? SystemID { get; set; }
        public long? UserIDOwner { get; set; }
        public User UserOwner { get; set; }

        public enum ScopeTypes
        {
            Global,
            Company,
            Location,
            Government,
            Fleet
        }
    }
}
