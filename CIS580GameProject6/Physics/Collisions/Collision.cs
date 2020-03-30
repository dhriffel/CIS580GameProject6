using CIS580GameProject6.Physics.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS580GameProject6.Physics.Collisions
{
    public static class Collision
    {
        public static bool Collides(PhysicsRectangle rect1, PhysicsRectangle rect2)
        {
            if (Math.Abs(rect1.origin.X - rect2.origin.X) > rect1.halfWidth + rect2.halfWidth)
                return false;
            if (Math.Abs(rect1.origin.Y - rect2.origin.Y) > rect1.halfHeight + rect2.halfHeight)
                return false;
            
            return true;
        }

        public static bool Collides(PhysicsCircle circle, PhysicsRectangle rect)
        {
            var point = Nearest.pointOnRectangle(circle.origin, rect);
            return Within.pointInCircle(point, circle);
        }

        public static bool Collides(PhysicsCircle circle1, PhysicsCircle circle2)
        {
            return Within.pointInCircle(circle1.origin, new PhysicsCircle(circle2.origin, circle1.radius + circle2.radius));
        }
    }
}
