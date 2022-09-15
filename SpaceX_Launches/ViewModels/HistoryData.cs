using System;

namespace SpaceX_Launch_Website.ViewModels
{
    public class HistoryData
    {
        public Links Links { get; set; }
        public string Title { get; set; }
        public DateTime Event_date_utc { get; set; }
        public int Event_date_unix { get; set; }
        public string Details { get; set; }
        public string Id { get; set; }
        public string Article { get; set; }
    }
}