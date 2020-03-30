using CIS580GameProject6.Physics.Shapes;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS580GameProject6.Physics.Collisions
{
    public static class Nearest
    {
        public static Vector2 pointOnSegment(Vector2 point, Vector2 linePoint1, Vector2 linePoint2)
        {
            var cx = point.X - linePoint1.X;
            var cy = point.Y - linePoint1.Y;
            var dx = linePoint2.X - linePoint1.X;
            var dy = linePoint2.Y - linePoint1.Y;

            var d = (dx * dx) + (dy * dy);
            if (d == 0)
                return linePoint1;

            var u = ((cx * dx) + (cy * dy)) / d;

            if (u < 0)
                u = 0;
            else if (u > 1)
                u = 1;

            return new Vector2((linePoint1.X + (u * dx)), (linePoint1.Y + (u * dy)));
        }

        public static Vector2 pointOnCircle(Vector2 point, PhysicsCircle circle)
        {
            var dx = point.X - circle.origin.X;
            var dy = point.Y - circle.origin.Y;
            var d = Math.Sqrt((dx * dx) + (dy * dy));

            if (d <= circle.radius)
                return point;

            return new Vector2(((float)(dx / d * circle.radius) + circle.origin.X), ((float)(dy / d * circle.radius) + circle.origin.Y));
        }

        public static Vector2 pointOnRectangle(Vector2 point, PhysicsRectangle rect)
        {
            var qx = point.X - rect.origin.X;
            var qy = point.Y - rect.origin.Y;

            if (qx > rect.halfWidth)
                qx = rect.halfWidth;
            else if (qx < -rect.halfWidth)
                qx = -rect.halfWidth;

            if (qy > rect.halfHeight)
                qy = rect.halfHeight;
            else if (qy < -rect.halfHeight)
                qy = -rect.halfHeight;

            return new Vector2(qx + rect.origin.X, qy + rect.origin.Y);
        }
    }
}
