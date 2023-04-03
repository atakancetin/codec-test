using Codec.Program.Utilities;

namespace Codec.Program.Model
{
    public class Robot
    {
        public int xPosition { get; set; }
        public int yPosition { get; set; }
        public Enums.Compass faceDirection { get; set; }

        public Robot()
        {
            xPosition = yPosition = 1;
            faceDirection = Enums.Compass.N;
        }
    }
}
