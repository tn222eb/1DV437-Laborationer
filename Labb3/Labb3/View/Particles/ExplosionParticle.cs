using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Labb3.View.Particles
{
    class ExplosionParticle
    {
        private int numFramesX = 4;
        private float timeElapsed;
        private float maxTime = 0.5f;
        private float numberOfFrames = 24;
        private int frame;
        private float size = 0.2f;
        private Vector2 position;

        public ExplosionParticle(Vector2 position)
        {
            this.position = position;
        }

        public void Update(float elapsedTime)
        {
            timeElapsed += elapsedTime;
            float percentAnimated = timeElapsed / maxTime;
            frame = (int)(percentAnimated * numberOfFrames);
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D explosionTexture, Camera camera)
        {
            float frameX = frame % numFramesX;
            float frameY = frame / numFramesX;

            int frameSize = explosionTexture.Width / 4;

            int visualFrameX = (int)frameX * frameSize;
            int visualFrameY = (int)frameY * frameSize;
            int visualX = (int)camera.ToVisualX(position.X);
            int visualY = (int)camera.ToVisualY(position.Y);

            int wholeFrameSize = (int)camera.ToVisualY(size);

            Rectangle destinationRectangle = new Rectangle(visualX - (wholeFrameSize / 2), visualY - (wholeFrameSize / 2), wholeFrameSize, wholeFrameSize);
            Rectangle sourceRectangle = new Rectangle(visualFrameX, visualFrameY, frameSize, frameSize);

            spriteBatch.Begin();
            spriteBatch.Draw(explosionTexture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
