using System.ComponentModel.DataAnnotations.Schema;

namespace Anyar.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Profession { get; set; }
        public string Desc { get; set; }
        public string TiwiterUrl { get; set; }
        public string FacebookUrl { get; set; }
        public string InstagramUrl { get; set; }
        public string LinkedinUrl { get; set; }
        public string? Image { get; set; }
        [NotMapped]
        public IFormFile? ImageFile { get; set; }

    }
}
