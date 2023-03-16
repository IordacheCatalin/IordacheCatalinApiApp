using FirstApiApp.DTOs;

namespace FirstApiApp.Repositories
{
    public interface IAnnouncementsRepository
    {
        public Task<IEnumerable<Announcement>> GetAnnouncementsAsync();
    }
}
