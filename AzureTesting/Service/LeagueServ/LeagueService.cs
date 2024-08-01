using AzureTesting.Database;
using AzureTesting.DTO.League;
using AzureTesting.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AzureTesting.Service.LeagueServ
{
    public class LeagueService : ILeagueService
    {
        private readonly DatabaseContext databaseContext;

        public LeagueService(DatabaseContext _databaseContext)
        {
            databaseContext = _databaseContext;
        }

        public League? GetLeagueById(int id) => databaseContext.Leagues.Where(l => l.Id == id)
               // .Include(l => l.Teams)
                .FirstOrDefault();

        public void AddLeague(CreateLeague createLeague, string? blobUrl)
        {
            Image? image = null;
            if (blobUrl != null)
            {
                image = new Image(blobUrl, createLeague.Name);
                databaseContext.Images.Add(image);
            }

            League newLeaue = new League(createLeague.Name, createLeague.ShortName);
            newLeaue.Image = image;

            databaseContext.Leagues.Add(newLeaue);
            databaseContext.SaveChanges();

        }

        public IEnumerable<LeagueInfoDTO> GetLeagues() => databaseContext.Leagues.Select(l => new LeagueInfoDTO(l.Name, l.ShortName, l.Year)
        {
            Id = l.Id,
            BlobUrl = l.Image != null ? l.Image.BlobUrl : null
        });

        public void RemoveLeague([FromRoute] int leagueId)
        {
            var league = databaseContext.Leagues.FirstOrDefault(l => l.Id == leagueId);
            if (league != null)
            {
                databaseContext.Leagues.Remove(league);
                databaseContext.SaveChanges();
            }
        }

        public void PatchLeague(PatchLeague patched, [FromRoute] int editedLeagueId)
        {
            var league = databaseContext.Leagues.First(l => l.Id == editedLeagueId);
            if(patched.Name != null && patched.Name != "")
            {
                league.Name = patched.Name;
            }

            if(patched.ShortName != null && patched.ShortName != "")
            {
                league.ShortName = patched.ShortName;
            }

            if(patched.Year != null)
            {
                league.Year = patched.Year.Value;
            }
            databaseContext.Leagues.Update(league);
            databaseContext.SaveChanges();
        }
    }
}
