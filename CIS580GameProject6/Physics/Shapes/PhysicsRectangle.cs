using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS580GameProject6.Physics.Shapes
{
    public class PhysicsRectangle
    {
        public Vector2 origin;
        public float halfWidth;
        public float halfHeight;

        public PhysicsRectangle(Vector2 origin, float width, float height)
        {
            this.origin = origin;
            this.halfWidth = width / 2;
            this.halfHeight = height / 2;
        }

        public static implicit operator Rectangle(PhysicsRectangle pr)
        {
            return new Rectangle(
                (int)(pr.origin.X - pr.halfWidth),
                (int)(pr.origin.Y - pr.halfHeight),
                (int)pr.halfWidth*2,
                (int)pr.halfHeight*2);
        }
    }
}
