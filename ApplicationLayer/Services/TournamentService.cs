using ApplicationLayer.Dtos;
using DomainLayer.Models;
using ApplicationLayer.Interfaces;

namespace ApplicationLayer.Services
{
    public class TournamentService : ITournamentService
    {
        private readonly ITournamentRepository _repo;
        public TournamentService(ITournamentRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<TournamentResponseDTO>> GetAllAsync(string? search = null)
        {
            var tournaments = await _repo.GetAllAsync();

            // Apply search filtering in the service layer
            if (!string.IsNullOrWhiteSpace(search))
            {
                var cleanSearch = search.Trim().ToLower();

                tournaments = tournaments
                    .Where(t => t.Title.ToLower().Contains(cleanSearch))
                    .ToList();
            }

            return tournaments.Select(t => new TournamentResponseDTO
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                MaxPlayers = t.MaxPlayers,
            });
        }

        public async Task<TournamentResponseDTO?> GetByIdAsync(int id)
        {
            var t = await _repo.GetByIdAsync(id);

            if (t == null) return null;

            return new TournamentResponseDTO
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                MaxPlayers = t.MaxPlayers,

                // Map related games to DTOs
                Games = t.Games.Select(g => new GameResponseDTO
                {
                    Id = g.Id,
                    Title = g.Title,
                    Time = g.Time
                }).ToList()
            };
        }

        public async Task<TournamentResponseDTO> CreateAsync(TournamentCreateDTO dto)
        {
            var tournament = new Tournament
            {
                Title = dto.Title, 
                Description = dto.Description,
                MaxPlayers = dto.MaxPlayers,
                Date = dto.Date
            };

            await _repo.AddAsync(tournament);
            await _repo.SaveAsync();

            return new TournamentResponseDTO
            {
                Id = tournament.Id,
                Title = tournament.Title,
                Description = tournament.Description,
                MaxPlayers = tournament.MaxPlayers,
            };
        }

        public async Task<bool> UpdateAsync(int id, TournamentUpdateDTO dto)
        {
          

            var tournament = await _repo.GetByIdAsync(id);

            if (tournament == null)
                return false;

            // Apply updates to the tracked entity
            tournament.Title = dto.Title;
            tournament.Description = dto.Description;
            tournament.MaxPlayers = dto.MaxPlayers;
            tournament.Date = dto.Date;

            await _repo.SaveAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var tournament = await _repo.GetByIdAsync(id);

            if (tournament == null)
                return false;

            await _repo.DeleteAsync(tournament);
            await _repo.SaveAsync();

            return true;
        }
    }
}