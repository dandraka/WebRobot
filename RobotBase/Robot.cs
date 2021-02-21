using System;
using System.Drawing;

namespace RobotBase
{
    public class Robot
    {
        public string Name { get; set; }

        public int SizeX { get; set; }

        public int SizeY { get; set; }

        public int PosX { get; set; }

        public int PosY { get; set; }

        public int DistanceFromObstacle { get; set; }

        public Point CornerTopLeft { get => new Point(PosX, PosY); }

        public Point CornerTopRight { get => new Point(PosX + SizeX, PosY); }

        public Point CornerBottomLeft { get => new Point(PosX, PosY + SizeY); }

        public Point CornerBottomRight { get => new Point(PosX + SizeX, PosY + SizeY); }

        public void Move(int deltaX, int deltaY)
        {
            this.PosX += deltaX;
            this.PosY += deltaY;

            Console.WriteLine($"New position: {this.PosX}, {this.PosY}");
        }

    }
}
