using FirstApiApp.DTOs;
using Microsoft.EntityFrameworkCore;
using FirstApiApp.DataContext;
using FirstApiApp.DTOs.CreateUpdateObjects;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using AutoMapper;

namespace FirstApiApp.Repositories
{
    public class AnnouncementsRepository : IAnnouncementsRepository
    {
        private readonly ProgrammingClubDataContext _context;
        private readonly IMapper _mapper;
        //const -> compile time - asigneaza valoarea cand declaram
        //readonly -> runtime time - asigneaza valoarea in constructor
         
        public AnnouncementsRepository(ProgrammingClubDataContext context, IMapper mapper) //IMapper se instaleaza si mapeaza doua obiecte
        {
            _context = context;
            _mapper = mapper;
        }
        //Get all announcements
        public async Task<IEnumerable<Announcement>> GetAnnouncementsAsync()
        {
            return await _context.Announcements.ToListAsync();
        }
        //Get announcements by id
        public async Task<Announcement> GetAnnouncementByIdAsync(Guid id)
        {
            return await _context.Announcements.SingleOrDefaultAsync(x => x.IdAnnouncement == id);
        }

        //Create announcements
        public async Task CreateAnnouncementAsync(Announcement announcement)
        {
            announcement.IdAnnouncement = Guid.NewGuid();
            _context.Announcements.Add(announcement);
            await _context.SaveChangesAsync();
        }

        //Delete announcements
        public async Task<bool> DeleteAnnouncementAsync(Guid id)
        {
            Announcement announcement = await GetAnnouncementByIdAsync(id);
            if(announcement == null) 
            {
                return false;
            }
            _context.Announcements.Remove(announcement);
            await _context.SaveChangesAsync();
            return true;

        }
        //Update announcements
        public async Task<CreateUpdateAnnouncement> UpdateAnnouncementAsync(Guid id, CreateUpdateAnnouncement announcement)
        {
            Announcement announcementFromDb = await GetAnnouncementByIdAsync(id);
            if(announcementFromDb == null)
            {
                return null;
            }

            //announcementFromDb.IdAnnouncement = id;
            //announcementFromDb.EventDate = announcement.EventDate;
            //announcementFromDb.Text = announcement.Text;
            //announcementFromDb.Title = announcement.Title;
            //announcementFromDb.ValidFrom = announcement.ValidFrom;
            //announcementFromDb.ValidTo = announcement.ValidTo;
            //announcementFromDb.Tags = announcement.Tags;

            var updatedAnnouncement = _mapper.Map<Announcement>(announcement);
            

            _context.Announcements.Update(updatedAnnouncement);
            await _context.SaveChangesAsync();
            return announcement;
        }
        //PATCH announcements
        public async Task<CreateUpdateAnnouncement> UpdatePartiallyAnnouncementAsync(Guid id, CreateUpdateAnnouncement announcement)
        {
            var announcementFromDb = await GetAnnouncementByIdAsync(id);
            if(announcementFromDb == null) { return null; }

            if(!string.IsNullOrEmpty(announcement.Title) && announcement.Title != announcementFromDb.Title)
            {
                announcementFromDb.Title = announcement.Title;
            }

            if (!string.IsNullOrEmpty(announcement.Text) && announcement.Text != announcementFromDb.Text)
            {
                announcementFromDb.Text = announcement.Text;
            }
            if (!string.IsNullOrEmpty(announcement.Tags) && announcement.Tags != announcementFromDb.Tags)
            {
                announcementFromDb.Tags = announcement.Tags;
            }
            if (announcement.ValidFrom.HasValue && announcement.ValidFrom != announcementFromDb.ValidFrom)
            {
                announcementFromDb.ValidFrom = (DateTime)announcement.ValidFrom;
            }
            if (announcement.ValidTo.HasValue && announcement.ValidTo != announcementFromDb.ValidTo)
            {
                announcementFromDb.ValidTo = (DateTime)announcement.ValidTo;
            }
            if (announcement.EventDate.HasValue && announcement.EventDate != announcementFromDb.EventDate)
            {
                announcementFromDb.EventDate = (DateTime)announcement.EventDate;
            }

            _context.Announcements.Update(announcementFromDb);
            await _context.SaveChangesAsync();
            return announcement;
        }
        public async Task<bool> ExistAnnouncementAsync(Guid id)
        {
            return await _context.Announcements.CountAsync(x => x.IdAnnouncement == id) > 0;
        }




    }
}
