using ConsoleApp1;
using Microsoft.EntityFrameworkCore;

namespace BoxWeb.Data
{
    public class dbstorage
    {
        private readonly BoxContext _context;

        public dbstorage(BoxContext context)
        {
            _context = context;
        }

        //Coach
        public async Task<List<Coach>> GetCoachAsync()
        {
            return await _context.Coaches.ToListAsync();
        }

        public async Task<Coach?> GetCoachByIdAsync(int id)
        {
            return await _context.Coaches.FirstOrDefaultAsync(x => x.CoachID == id);
        }

        public async Task AddCoachAsync(Coach coach)
        {
            _context.Coaches.Add(coach);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCoachAsync(Coach coach)
        {
            _context.Coaches.Update(coach);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCoachAsync(int id)
        {
            var coach = await GetCoachByIdAsync(id);
            if (coach != null)
            {
                _context.Coaches.Remove(coach);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> CoachExistsAsync(int id)
        {
            return await _context.Coaches.AnyAsync(co => co.CoachID == id);
        }

        //Club

        public async Task<List<Club>> GetClubAsync()
        {
            return await _context.Clubs.ToListAsync();
        }

        public async Task<Club?> GetClubByIdAsync(int id)
        {
            return await _context.Clubs.FirstOrDefaultAsync(cl => cl.ClubID == id);
        }

        public async Task AddClubAsync(Club club)
        {
            _context.Clubs.Add(club);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateClubAsync(Club club)
        {
            _context.Clubs.Update(club);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteClubAsync(int id)
        {
            var club = await GetClubByIdAsync(id);
            if (club != null)
            {
                _context.Clubs.Remove(club);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ClubExistsAsync(int id)
        {
            return await _context.Clubs.AnyAsync(cl => cl.ClubID == id);
        }

        //Sportsman

        public async Task<List<Sportsman>> GetSportsmanAsync()
        {
            return await _context.Sportmen.ToListAsync();
        }

        public async Task<Sportsman?> GetSportsmanByIdAsync(int id)
        {
            return await _context.Sportmen.FirstOrDefaultAsync(sp => sp.SportsmanID == id);
        }

        public async Task AddSportsmanAsync(Sportsman sportsman)
        {
            _context.Sportmen.Add(sportsman);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSportsmanAsync(Sportsman sportsman)
        {
            _context.Sportmen.Update(sportsman);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSportsmanAsync(int id)
        {
            var sportsman = await GetSportsmanByIdAsync(id);
            if (sportsman != null)
            {
                _context.Sportmen.Remove(sportsman);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> SportsmanExistsAsync(int id)
        {
            return await _context.Sportmen.AnyAsync(sp => sp.SportsmanID == id);
        }

        //SF

        public async Task<List<SF>> GetSFAsync()
        {
            return await _context.SFs.ToListAsync();
        }

        public async Task<SF?> GetSFByIdAsync(int id)
        {
            return await _context.SFs.FirstOrDefaultAsync(sfs => sfs.ID == id);
        }

        public async Task AddSFAsync(SF sf)
        {
            _context.SFs.Add(sf);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSFAsync(SF sf)
        {
            _context.SFs.Update(sf);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSFAsync(int id)
        {
            var sf = await GetSFByIdAsync(id);
            if (sf != null)
            {
                _context.SFs.Remove(sf);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> SFExistsAsync(int id)
        {
            return await _context.SFs.AnyAsync(sfs => sfs.ID == id);
        }

        //Fight

        public async Task<List<Fight>> GetFightAsync()
        {
            return await _context.Fights.ToListAsync();
        }

        public async Task<Fight?> GetFightByIdAsync(int id)
        {
            return await _context.Fights.FirstOrDefaultAsync(fi => fi.FightID == id);
        }

        public async Task AddFightAsync(Fight fight)
        {
            _context.Fights.Add(fight);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateFightAsync(Fight fight)
        {
            _context.Fights.Update(fight);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFightAsync(int id)
        {
            var fight = await GetFightByIdAsync(id);
            if (fight != null)
            {
                _context.Fights.Remove(fight);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> FightExistsAsync(int id)
        {
            return await _context.Fights.AnyAsync(fi => fi.FightID == id);
        }

        //Tournament

        public async Task<List<Tournament>> GetTournamentAsync()
        {
            return await _context.Tournaments.ToListAsync();
        }

        public async Task<Tournament?> GetTournamentByIdAsync(int id)
        {
            return await _context.Tournaments.FirstOrDefaultAsync(to => to.TournamentID == id);
        }

        public async Task AddTournamentAsync(Tournament tournament)
        {
            _context.Tournaments.Add(tournament);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTournamentAsync(Tournament tournament)
        {
            _context.Tournaments.Update(tournament);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTournamentAsync(int id)
        {
            var tournament = await GetTournamentByIdAsync(id);
            if (tournament != null)
            {
                _context.Tournaments.Remove(tournament);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> TournamentExistsAsync(int id)
        {
            return await _context.Tournaments.AnyAsync(to => to.TournamentID == id);
        }

        //Refeere

        public async Task<List<Refeere>> GetRefeereAsync()
        {
            return await _context.Refeeres.ToListAsync();
        }

        public async Task<Refeere?> GetRefeereByIdAsync(int id)
        {
            return await _context.Refeeres.FirstOrDefaultAsync(re => re.RefeereID == id);
        }

        public async Task AddRefeereAsync(Refeere refeere)
        {
            _context.Refeeres.Add(refeere);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRefeereAsync(Refeere refeere)
        {
            _context.Refeeres.Update(refeere);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRefeereAsync(int id)
        {
            var refeere = await GetRefeereByIdAsync(id);
            if (refeere != null)
            {
                _context.Refeeres.Remove(refeere);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> RefeereExistsAsync(int id)
        {
            return await _context.Refeeres.AnyAsync(re => re.RefeereID == id);
        }
    }
}
