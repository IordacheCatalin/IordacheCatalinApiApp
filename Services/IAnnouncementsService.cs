using FirstApiApp.DTOs;

namespace FirstApiApp.Services
{
    public interface IAnnouncementsService
    {
        public Task<IEnumerable<Announcement>> GetAnnouncementsAsync();

    }
}
