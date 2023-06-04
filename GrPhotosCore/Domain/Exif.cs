using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace GrPhotosCore.Domain
{
    public class Exif
    {
        public int Id { get; set; }


        public string Location { get; set; }

        public string Gallery { get; set; }

        public string Category { get; set; }

        public bool ShowToHome { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        [Display(Name = "Camera")]
        public string CameraModelName { get; set; }

        [Display(Name = "Ταχύτητα")]
        public string ExposureTime { get; set; }
       
        public int ISO { get; set; }

        [Display(Name = "Ελήφθη στις")]
        public DateTime CreateDate { get; set; }

        [Display(Name = "Διάφραγμα")]
        public double Aperture { get; set; }

        [Display(Name = "Εστιακή απόσταση")]
        public string FocalLength { get; set; }

        [Display(Name = "Τύπος φίλμ")]
        public string FilmMode { get; set; }
        
        public string LensMake { get; set; }

        [Display(Name = "Φακός")]
        public string LensModel { get; set; }
    }
}
