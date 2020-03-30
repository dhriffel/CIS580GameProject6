using CIS580GameProject6.Physics.Shapes;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS580GameProject6.Physics.Collisions
{
    public static class Within
    {
        public static bool pointInCircle(Vector2 point, PhysicsCircle circle)
        {
            var dx = point.X - circle.origin.X;
            var dy = point.Y - circle.origin.Y;

            return (((dx * dx) + (dy * dy)) <= (circle.radius * circle.radius));
        }
    }
}
