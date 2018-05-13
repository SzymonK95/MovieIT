using System;

namespace SM_Project.Model
{
    public partial class Reminder
    {
        public Guid ReminderGuid { get; set; }
        public DateTime? NotifyDate { get; set; }
        public Guid? UserGuid { get; set; }
        public Guid? MovieGuid { get; set; }

        public Movie MovieGu { get; set; }
    }
}
