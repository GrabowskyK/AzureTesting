﻿using AzureTesting.DTO.Image;

namespace AzureTesting.DTO.League
{
    public class LeagueInfoDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public int Year { get; set; }
        public string? BlobUrl { get; set; }

        public LeagueInfoDTO(string name, string shortName, int year)
        {
            Name = name;
            ShortName = shortName;
            Year = year;
        }

    }
}
