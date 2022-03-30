namespace Album.Domain.Shared.DataTransfer
{
    public class RotateOrFlipImageDto :BasicImage
    {
        public float RotationAngle { get; set; } = 0;
    }
}
