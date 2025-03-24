﻿using Hall_App.Enums;

namespace Hall_App.Models
{
    public class ArcadeHall
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public int MaxCapacity { get; set; }
        public HallAvailability HallStatus { get; set; }



    }
}
