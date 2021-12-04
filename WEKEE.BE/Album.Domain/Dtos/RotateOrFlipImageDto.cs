namespace Album.Domain.Dtos
{
    public class RotateOrFlipImageDto :BasicImage
    {
        public float RotationAngle { get; set; } = 0;
    }
}
