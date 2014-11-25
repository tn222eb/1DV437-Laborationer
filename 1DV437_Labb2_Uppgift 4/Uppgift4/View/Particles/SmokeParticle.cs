using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Uppgift4.View.Particles
{
    class SmokeParticle
    {
        private Vector2 position;
        private Vector2 velocity;
        private Vector2 acceleration = new Vector2(0, -0.4f);
        private static float maxSpeed = 0.2f;
        private float timeLived = 0;
        private float size = 0;
        private float maxTimeToLive = 3.0f;
        private float lifePercent;
        private float minSize = 3f;
        private float maxSize = 8f;
        private float rotation = 0;

        public SmokeParticle(Vector2 position)
        {
            this.position = position;
            Spawn();
        }

        public void Update(float timeElapsed)
        {
            timeLived += timeElapsed;

            lifePercent = timeLived / maxTimeToLive;
            size = minSize + lifePercent * maxSize;
            rotation += 0.02f;

            velocity.X = velocity.X + timeElapsed * acceleration.X;
            velocity.Y = velocity.Y + timeElapsed * acceleration.Y;
            position.X = position.X + timeElapsed * velocity.X;
            position.Y = position.Y + timeElapsed * velocity.Y;
        }

        public void Spawn()
        {
            timeLived = 0;

            size = 0;

            Random random = new Random();
            velocity = new Vector2(((float)random.NextDouble() - 0.5f), ((float)random.NextDouble() - 0.5f));
            velocity.Normalize();
            velocity = velocity * ((float)random.NextDouble() * maxSpeed);
        }

        public bool IsDead()
        {
            return timeLived >= maxTimeToLive;
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D smokeTexture, Camera camera)
        {
            float startValue = 1.0f;
            float endValue = 0.0f;
            float fade = endValue * lifePercent + (1.0f - lifePercent) * startValue;

            Color color = new Color(fade, fade, fade, fade);

            int visualX = (int)camera.ToVisualX(position.X);
            int visualY = (int)camera.ToVisualY(position.Y);

            Vector2 origin = new Vector2(smokeTexture.Width / 2, smokeTexture.Height / 2);
            Rectangle sourceRectangle = new Rectangle(0, 0, smokeTexture.Width, smokeTexture.Height);
            Vector2 visualPosition = new Vector2(visualX, visualY);

            spriteBatch.Begin();
            spriteBatch.Draw(smokeTexture, visualPosition, sourceRectangle, color, rotation, origin, size, SpriteEffects.None, 0);
            spriteBatch.End();
        }
    }
}
