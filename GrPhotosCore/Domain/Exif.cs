namespace GrPhotosCore.Domain
{
    public class Exif
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? CameraModelName { get; set; }
        public string? ExposureTime { get; set; }
        public int ISO { get; set; }
        public DateTime CreateDate { get; set; }
        public double Aperture { get; set; }
        public string? FocalLength { get; set; }
        public string? FilmMode { get; set; }
        public string? LensMake { get; set; }
        public string? LensModel { get; set; }
    }
}
