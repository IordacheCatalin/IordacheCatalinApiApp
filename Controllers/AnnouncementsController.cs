using FirstApiApp.DTOs;
using FirstApiApp.DTOs.CreateUpdateObjects;
using FirstApiApp.Helpers;
using FirstApiApp.Models;
using FirstApiApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FirstApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnouncementsController : ControllerBase
    {
        public readonly IAnnouncementsService _announcementsService;
        private readonly ILogger<AnnouncementsController> _logger;

        public AnnouncementsController(IAnnouncementsService announcementsService, ILogger<AnnouncementsController> logger)
        {
            _announcementsService = announcementsService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                _logger.LogInformation("GetAnnouncements started");

                var announcements = await _announcementsService.GetAnnouncementsAsync();

                if (announcements == null || !announcements.Any())
                {
                    return StatusCode((int)HttpStatusCode.NoContent, ErrorMessagesEnum.NoElementFound);
                }

                return Ok(announcements);
            }
            catch (Exception ex)
            {
                _logger.LogError($"GetAllAnnouncements error: {ex.Message}");
                return StatusCode((int)(HttpStatusCode.InternalServerError), ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnnouncementAsync([FromRoute] Guid id)
        {
            try
            {
                _logger.LogInformation("GetAnnouncementById started");
                var announcement = await _announcementsService.GetAnnouncementByIdAsync(id);

                if (announcement == null)
                {
                    return NotFound(ErrorMessagesEnum.NoElementFound);
                }
                return Ok(announcement);

            }
            catch (Exception ex)
            {
                _logger.LogError($"GetAnnouncementsById error: {ex.Message}");
                return StatusCode((int)(HttpStatusCode.InternalServerError), ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostAnnouncementAsync([FromBody] Announcement announcement)
        {
            try
            {
                _logger.LogInformation("CreateAnnouncementsAsync started");
                if (announcement == null)
                {
                    return BadRequest(ErrorMessagesEnum.BadRequest);
                }
                await _announcementsService.CreateAnnouncementAsync(announcement);
                return Ok(SuccessMessagesEnum.ElementSuccessfullyAdded);
            }
            catch (ModelValidationException ex)
            {
                _logger.LogError($"Validation exception {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Validation exception {ex.Message}");
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnnouncementsAsync([FromRoute] Guid id)
        {
            try
            {
                _logger.LogInformation("Delete Announcement Started");
                bool result = await _announcementsService.DeleteAnnouncementAsync(id);
                if (result)
                {
                    return Ok(SuccessMessagesEnum.ElementSuccessfullyDeleted);
                }
                return BadRequest(ErrorMessagesEnum.NoElementFound);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Validation exception {ex.Message}");
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnnouncement([FromRoute] Guid id, [FromBody] CreateUpdateAnnouncement announcement)
        {
            try
            {
                _logger.LogInformation("Update Announcement Started");
                if (announcement == null)
                {
                    return BadRequest(ErrorMessagesEnum.BadRequest);
                }
                CreateUpdateAnnouncement updatedAnnouncements = await _announcementsService.UpdateAnnouncementAsync(id, announcement);
                if(updatedAnnouncements == null)
                {
                    return StatusCode((int)HttpStatusCode.NoContent, ErrorMessagesEnum.NoElementFound);
                }
                return Ok(SuccessMessagesEnum.ElementSuccessfullyAdded);
            }
            catch (ModelValidationException ex)
            {
                _logger.LogError($"Validation exception {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            { 
                _logger.LogError($"Validation exception {ex.Message}");
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchAnnouncement([FromRoute] Guid id, [FromBody] CreateUpdateAnnouncement announcement)
        {
            try
            {
                _logger.LogInformation("Update Announcement Started");
                if (announcement == null)
                {
                    return BadRequest(ErrorMessagesEnum.BadRequest);
                }
                CreateUpdateAnnouncement updatedAnnouncements = await _announcementsService.UpdatePartiallyAnnouncementAsync(id, announcement);
                if (updatedAnnouncements == null)
                {
                    return StatusCode((int)HttpStatusCode.NoContent, ErrorMessagesEnum.NoElementFound);
                }
                return Ok(SuccessMessagesEnum.ElementSuccessfullyAdded);
            }
            catch (ModelValidationException ex)
            {
                _logger.LogError($"Validation exception {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Validation exception {ex.Message}");
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}


//Get all -> returnam si id-urile
//Get by id -> returnam obiectul si id
//POST -> id-ul se seteaza din backend => nu trimitem de pe UI => nu-l punem in body
//PUT -> id-ul se trimite in ruta, nu in body
//PATCH -> id-ul se trimite in ruta, nu in body