using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS580GameProject6.Physics.Shapes
{
    public class PhysicsCircle
    {
        public Vector2 origin;
        public float radius;

        public PhysicsCircle(Vector2 origin, float radius)
        {
            this.origin = origin;
            this.radius = radius;
        }


    }
}
