using FirstApiApp.DTOs;
using FirstApiApp.DTOs.CreateUpdateObjects;
using FirstApiApp.Helpers;
using FirstApiApp.Repositories;

namespace FirstApiApp.Services
{
    public class AnnouncementsService : IAnnouncementsService
    {
        private readonly IAnnouncementsRepository _repository;
        //const -> compile time - asigneaza valoarea cand declaram
        //readonly -> runtime time
        public AnnouncementsService(IAnnouncementsRepository repository)
        {
            _repository = repository;
        }

        //Get announcements by id
        public async Task<Announcement> GetAnnouncementByIdAsync(Guid id)
        {
            return await _repository.GetAnnouncementByIdAsync(id);
        }
        //Get all announcements
        public async Task<IEnumerable<Announcement>> GetAnnouncementsAsync()
        {
            return await _repository.GetAnnouncementsAsync();
        }
        //Create announcements
        public async Task CreateAnnouncementAsync(Announcement newAnnouncement)
        {
            ValidationFunctions.ExceptionWhenDateIsNotValid(newAnnouncement.ValidFrom, newAnnouncement.ValidTo);
            await _repository.CreateAnnouncementAsync(newAnnouncement);
        }
        //Delete announcements
        public async Task<bool> DeleteAnnouncementAsync(Guid id)
        {
            return await _repository.DeleteAnnouncementAsync(id);
        }
        //Update announcements
        public async Task<CreateUpdateAnnouncement> UpdateAnnouncementAsync(Guid id, CreateUpdateAnnouncement announcement)
        {
            ValidationFunctions.ExceptionWhenDateIsNotValid(announcement.ValidFrom, announcement.ValidTo);
            return await _repository.UpdateAnnouncementAsync(id, announcement);
        }
        //Patch announcements
        public async Task<CreateUpdateAnnouncement> UpdatePartiallyAnnouncementAsync(Guid id, CreateUpdateAnnouncement announcement)
        {
            return await _repository.UpdatePartiallyAnnouncementAsync(id, announcement);
        }
    }
}
 