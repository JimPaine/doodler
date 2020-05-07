namespace doodler.Client
{
    public class Payload
    {
        public double PrevX { get; set; }

        public double NewX { get; set; }

        public double PrevY { get; set; }

        public double NewY { get; set; }
    }

    public class Point 
    {
        public double x { get; set; }

        public double y { get; set; }
    }
}