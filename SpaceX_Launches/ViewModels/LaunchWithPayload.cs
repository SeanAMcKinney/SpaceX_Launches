using System;

namespace SpaceX_Launch_Website.ViewModels
{
    public class LaunchWithPayload
    {
        public string Name { get; set; }
        public DateTime DateLocal { get; set; }
        public bool? Success { get; set; }
        public float? MassLbs { get; set; }
        public int Rank { get; set; }
    }
}