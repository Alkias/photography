using GrPhotosCore.Domain;

namespace GrPhotosCore.Models
{
    public class PortfolioModel
    {
        public List<string>? Geleries { get; set; }

        public string? ActiveGallery { get; set; }

        public List<string>? Categories { get; set; }

        public List<Exif>? Exifs { get; set; }
    }
}
