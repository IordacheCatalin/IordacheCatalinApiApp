using FirstApiApp.DTOs;
using FirstApiApp.DTOs.CreateUpdateObjects;

namespace FirstApiApp.Repositories
{
    public interface IAnnouncementsRepository
    {
        public Task<IEnumerable<Announcement>> GetAnnouncementsAsync();


        public Task<Announcement> GetAnnouncementByIdAsync(Guid id);

        public Task CreateAnnouncementAsync(Announcement announcement);

        public Task<bool> DeleteAnnouncementAsync(Guid id);

        public Task<CreateUpdateAnnouncement> UpdateAnnouncementAsync(Guid id, CreateUpdateAnnouncement announcement);

        public Task<CreateUpdateAnnouncement> UpdatePartiallyAnnouncementAsync(Guid id, CreateUpdateAnnouncement announcement);
    }
}
