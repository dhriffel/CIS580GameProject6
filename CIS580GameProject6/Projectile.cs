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

        public Projectile(Game1 game, Vector2 origin, int size, int initialVelocity, double initialAngle, Texture2D texture)
        {
            circle = new PhysicsCircle(origin, size / 2);
            this.texture = texture;
            var radians = initialAngle * (Math.PI/180.0);
            xVelocity = (float)(initialVelocity * Math.Cos(radians));
            yVelocity = (float)(initialVelocity * Math.Sin(radians));
            this.game = game;
            game.particleEngine.rocketSystem.Emitter[0] = circle.origin;
         }

        public void Update(GameTime gameTime)
        {
            circle.origin.X += xVelocity;
            yVelocity += 0.1f;
            circle.origin.Y += yVelocity;
            game.particleEngine.rocketSystem.Emitter[0] = circle.origin;

            if(Collision.Collides(this.circle, game.floor))
            {
                game.particleEngine.explosionSystem.Emitter[0] = circle.origin;
                game.particleEngine.rocketSystem.Emitter[0] = new Vector2(5000,5000);
            }
        }
        
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new PhysicsRectangle(circle.origin, circle.radius * 2, circle.radius * 2),Color.LimeGreen);
        }
    }
}
