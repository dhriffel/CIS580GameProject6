using CIS580GameProject6.Physics.Shapes;
using CIS580GameProject6.Physics.Collisions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS580GameProject6
{
    public struct Projectile
    {
        public Texture2D texture;
        PhysicsCircle circle;
        float xVelocity;
        float yVelocity;
        Game1 game;
        public bool active;

        public Projectile(Game1 game, Vector2 origin, int size, int initialVelocity, double initialAngle, Texture2D texture)
        {
            active = true;
            circle = new PhysicsCircle(origin, size / 2);
            this.texture = texture;
            var radians = initialAngle * (Math.PI/180.0);
            xVelocity = (float)(initialVelocity * Math.Cos(radians));
            yVelocity = (float)(initialVelocity * Math.Sin(radians)) ;
            this.game = game;
            game.particleEngine.rocketSystem.Emitter.Add(circle.origin);
         }

        public void Update(GameTime gameTime)
        {
            if (active)
            {
                circle.origin.X += xVelocity;
                yVelocity += 0.1f;
                circle.origin.Y += yVelocity;
                game.particleEngine.rocketSystem.Emitter[0] = circle.origin;

                if (Collision.Collides(this.circle, game.floor) || circle.origin.X > game.GraphicsDevice.Viewport.Width || circle.origin.X < 0)
                {
                    active = false;
                    game.particleEngine.explosionSystem.Emitter.Add(circle.origin);
                    game.particleEngine.explosionSystem.life = 1000;
                    game.particleEngine.rocketSystem.Emitter.RemoveAt(0);
                }
            }
        }
        
        public void Draw(SpriteBatch spriteBatch)
        {
            //if(active)
                //spriteBatch.Draw(texture, new PhysicsRectangle(circle.origin, circle.radius * 2, circle.radius * 2),Color.LimeGreen);
        }
    }
}
