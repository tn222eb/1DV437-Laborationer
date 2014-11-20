using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _1DV437_Laboration_2_Smoke
{
    class SplitterParticle
    {
        private Vector2 m_splitterPosition;
        private Vector2 m_splitterVelocity;
        private Vector2 m_acceleration;
        private float m_splitterSize = 0.02f;
        private float m_timeLived;
        private float m_maxTimeToLive = 1.0f;
        private float m_maxSize = 0.2f;
        private float m_minSize = 0.02f;
        private float m_lifePercent;
        private float MAX_TIME;
        private float m_delayTimeSeconds;

        public SplitterParticle(Vector2 velocity, float MAX_TIME, float delayTimeSeconds)
        {
            this.m_splitterVelocity = velocity;
            this.MAX_TIME = MAX_TIME;
            m_splitterPosition = new Vector2(0.5f, 1.0f);
            m_acceleration = new Vector2(-0.8f, -1.6f);
            m_delayTimeSeconds = delayTimeSeconds;
        }

        public void Update(float timeElapsed)
        {
            m_timeLived += timeElapsed;
            m_lifePercent = getTimeLivedSeconds() / m_maxTimeToLive;
            m_splitterSize = m_minSize + m_lifePercent * m_maxSize;

            if (isAlive())
            {
                m_splitterVelocity.X = m_splitterVelocity.X + timeElapsed * m_acceleration.X;
                m_splitterVelocity.Y = m_splitterVelocity.Y + timeElapsed * m_acceleration.Y;

                m_splitterPosition.X = m_splitterPosition.X + timeElapsed * m_splitterVelocity.X;
                m_splitterPosition.Y = m_splitterPosition.Y + timeElapsed * m_splitterVelocity.Y;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Camera camera, Texture2D splitterTexture)
        {
      
                int visualX = (int)camera.ToVisualX(m_splitterPosition.X);
                int visualY = (int)camera.ToVisualY(m_splitterPosition.Y);
                int visualSize = (int)camera.ToVisualX(m_splitterSize);

                float t = getTimeLivedSeconds() / m_maxTimeToLive;
                if (t > 1.0f)
                {
                    t = 1.0f;
                    return;
                }

                float startValue = 1.0f;
                float endValue = 0.0f;

                float fade = endValue * t + (1.0f - t) * startValue;
                Color color = new Color(fade, fade, fade, fade);

                spriteBatch.Begin();

                Rectangle rectangle = new Rectangle(visualX, visualY, visualSize, visualSize);
                spriteBatch.Draw(splitterTexture, rectangle, color);
                spriteBatch.End();
            
        }

        private float getTimeLivedSeconds()
        {
            if (isAlive())
            {
                return m_timeLived - m_delayTimeSeconds;
            }
            else
            {
                return 0;
            }
        }
        private bool isAlive()
        {
            return m_timeLived > m_delayTimeSeconds;
        }

    }
}
