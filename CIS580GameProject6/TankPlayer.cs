using CIS580GameProject6.Physics.Shapes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS580GameProject6
{
    class TankPlayer
    {
        Game1 game;
        public Texture2D texture;
        public PhysicsRectangle tankRectangle;
        public PhysicsRectangle turretRectangle;
        Projectile bullet;

        KeyboardState oldKeyboardState;

        public double turretDegrees = 270;

        

        public TankPlayer(Game1 game, PhysicsRectangle tankRectangle)
        {
            this.game = game;
            this.tankRectangle = tankRectangle;
            turretRectangle = new PhysicsRectangle(new Vector2(tankRectangle.origin.X, tankRectangle.origin.Y - tankRectangle.halfHeight), 15, 25);

            game.particleEngine.exhaustSystem.Emitter.Add(tankRectangle.origin);
        }

        public void Update(GameTime gameTime)
        {
            var keyboardState = Keyboard.GetState();

            // Move the paddle up if the up key is pressed
            if (keyboardState.IsKeyDown(Keys.Left))
            {
                // move up
                tankRectangle.origin.X -= (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            }

            // Move the paddle down if the down key is pressed
            if (keyboardState.IsKeyDown(Keys.Right))
            {
                // move down
                tankRectangle.origin.X += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            }

            if (keyboardState.IsKeyDown(Keys.Up))
            {
                turretDegrees += 0.5;
            }
            if (keyboardState.IsKeyDown(Keys.Down))
            {
                turretDegrees -= 0.5;
            }

            if (keyboardState.IsKeyDown(Keys.Space) && oldKeyboardState.IsKeyUp(Keys.Space) && !bullet.active)
            {
                bullet = new Projectile(game, turretRectangle.origin, 20, 7, turretDegrees, texture);
            }

            // Stop the paddle from going off-screen
            if (tankRectangle.origin.X < 0 + tankRectangle.halfWidth)
            {
                tankRectangle.origin.X = 0 + tankRectangle.halfWidth;
            }
            if (tankRectangle.origin.X > game.GraphicsDevice.Viewport.Width - tankRectangle.halfWidth)
            {
                tankRectangle.origin.X = game.GraphicsDevice.Viewport.Width - tankRectangle.halfWidth;
            }

            if (turretDegrees > 360)
                turretDegrees = 360;
            if (turretDegrees < 180)
                turretDegrees = 180;

            turretRectangle.origin = new Vector2(tankRectangle.origin.X, tankRectangle.origin.Y - tankRectangle.halfHeight);


            if (bullet.texture != null)
                bullet.Update(gameTime);

            Debug.WriteLine(turretDegrees);

            game.particleEngine.exhaustSystem.Emitter[0] = turretRectangle.origin;

            oldKeyboardState = Keyboard.GetState();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, tankRectangle, Color.Orange);
            spriteBatch.Draw(texture, turretRectangle, Color.Green);
            if (bullet.texture != null)
                bullet.Draw(spriteBatch);
        }
    }
}
