using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS580GameProject6
{
    public class ParticleEngine
    {
        /// <summary>
        /// The collection of particles
        /// </summary>
        public ParticleSystem rocketSystem;
        public ParticleSystem explosionSystem;
        Random random = new Random();

        public void LoadContent(GraphicsDevice graphicsDevice, ContentManager content)
        {
            Texture2D particleTexture = content.Load<Texture2D>("particle");


            rocketSystem = new ParticleSystem(graphicsDevice, 1000, particleTexture);
            rocketSystem.Emitter[0] = new Vector2(100, 100);
            rocketSystem.SpawnPerFrame = 4;

            explosionSystem = new ParticleSystem(graphicsDevice, 1000, particleTexture);
            rocketSystem.SpawnPerFrame = 1;

            // Set the SpawnParticle method
            rocketSystem.SpawnParticle = (ref Particle particle, ref Vector2 emmitter) =>
            {
                particle.Position = emmitter;
                particle.Velocity = new Vector2(
                    MathHelper.Lerp(-50, 50, (float)random.NextDouble()), // X between -50 and 50
                    MathHelper.Lerp(0, 100, (float)random.NextDouble()) // Y between 0 and 100
                    );
                particle.Acceleration = 0.1f * new Vector2(0, (float)-random.NextDouble());
                particle.Color = Color.Gold;
                particle.Scale = 1f;
                particle.Life = 1.0f;
            };

            // Set the UpdateParticle method
            rocketSystem.UpdateParticle = (float deltaT, ref Particle particle) =>
            {
                particle.Velocity += deltaT * particle.Acceleration;
                particle.Position += deltaT * particle.Velocity;
                particle.Scale -= deltaT;
                particle.Life -= deltaT;
            };

            // Set the SpawnParticle method
            explosionSystem.SpawnParticle = (ref Particle particle, ref Vector2 emmitter) =>
            {
                for (int i = 0; i < 100; i++)
                {
                    particle.Position = emmitter;
                    particle.Velocity = new Vector2(
                        MathHelper.Lerp(-50, 50, (float)random.NextDouble()), // X between -50 and 50
                        MathHelper.Lerp(0, 100, (float)random.NextDouble()) // Y between 0 and 100
                        );
                    particle.Acceleration = 0.1f * new Vector2(0, (float)-random.NextDouble());
                    particle.Color = Color.Gold;
                    particle.Scale = 1f;
                    particle.Life = 1.0f;
                }
            };

            // Set the UpdateParticle method
            explosionSystem.UpdateParticle = (float deltaT, ref Particle particle) =>
            {
                particle.Velocity += deltaT * particle.Acceleration;
                particle.Position += deltaT * particle.Velocity;
                particle.Scale -= deltaT;
                particle.Life -= deltaT;
            };
        }

        public void Update(GameTime gameTime)
        {
            rocketSystem.Update(gameTime);
        }
                

        public void Draw()
        {
            rocketSystem.Draw();
        }
    }
}
