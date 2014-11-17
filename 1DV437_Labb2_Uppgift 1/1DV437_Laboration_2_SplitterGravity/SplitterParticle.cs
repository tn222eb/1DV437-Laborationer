using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _1DV437_Laboration_2_SplitterGravity
{
    class SplitterParticle
    {
        private Vector2 m_splitterPosition;
        private Vector2 m_splitterVelocity;
        private Vector2 m_acceleration;
        private float m_splitterSize = 0.02f;

        public SplitterParticle(Vector2 velocity)
        {
            this.m_splitterVelocity = velocity;
            m_splitterPosition = new Vector2(0.5f, 0.5f);
            m_acceleration = new Vector2(0, 1f);
        }

        public void Update(float timeElapsed)
        {
            m_splitterVelocity.X = m_splitterVelocity.X + timeElapsed * m_acceleration.X;
            m_splitterVelocity.Y = m_splitterVelocity.Y + timeElapsed * m_acceleration.Y;

            m_splitterPosition.X = m_splitterPosition.X + timeElapsed * m_splitterVelocity.X;
            m_splitterPosition.Y = m_splitterPosition.Y + timeElapsed * m_splitterVelocity.Y;
        }

        public void Draw(SpriteBatch spriteBatch, Camera camera, Texture2D splitterTexture)
        {
            int visualX = (int) camera.ToVisualX(m_splitterPosition.X);
            int visualY = (int)camera.ToVisualY(m_splitterPosition.Y);
            int visualSize = (int)camera.ToVisualX(m_splitterSize);

            spriteBatch.Begin();

            Rectangle rectangle = new Rectangle(visualX, visualY, visualSize, visualSize);

            spriteBatch.Draw(splitterTexture, rectangle, Color.White);
            spriteBatch.End();
        }
    }
}
