using System.ComponentModel.DataAnnotations;

namespace FirstApiApp.DTOs
{
    public class Announcement
    {
        [Key]
        public Guid IdAnnouncement { get; set; }

        [Required(ErrorMessage = "Please complete this field!")]
        public DateTime ValidFrom { get; set; }

        [Required(ErrorMessage = "Please complete this field!")]
        public DateTime ValidTo { get; set; }

        [Required(ErrorMessage = "Please complete this field!")]
        [StringLength(250, ErrorMessage = "This field contains max 250 char")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please complete this field!")]
        [MaxLength(250, ErrorMessage = "This field contains max 250 char")]
        public string Text { get; set; }

        [Required(ErrorMessage = "Please complete this field!")]
        public DateTime EventDate { get; set; }

        [Required(ErrorMessage = "Please complete this field!")]
        [StringLength(1000, ErrorMessage = "This field contains max 250 char")]
        public string Tags { get; set; }

    }
}
