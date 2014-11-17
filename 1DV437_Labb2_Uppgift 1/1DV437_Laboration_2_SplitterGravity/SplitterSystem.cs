using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace _1DV437_Laboration_2_SplitterGravity
{
    class SplitterSystem
    {
        private SplitterParticle[] m_particles;
        private int MAX_PARTICLES = 100;
        private float m_totalTime = 0;
        private float MAX_TIME = 2;
        private float m_maxSpeed = 0.2f;

        public SplitterSystem()
        {
            m_particles = new SplitterParticle[MAX_PARTICLES];

            RespawnSystem();
        }

        private void RespawnSystem()
        {
            Random rand = new Random();

            for (int i = 0; i < MAX_PARTICLES; i++)
            {
                Vector2 randomDirection = new Vector2(((float)rand.NextDouble() - 0.5f), ((float)rand.NextDouble() - 0.5f));
                randomDirection.Normalize();
                randomDirection = randomDirection * ((float)rand.NextDouble() * m_maxSpeed);

                m_particles[i] = new SplitterParticle(randomDirection);
            }
        }

        public void Update(float timeElapsed)
        {
            m_totalTime += timeElapsed;

            for (int i = 0; i < MAX_PARTICLES; i++)
            {
                m_particles[i].Update(timeElapsed);
            }

            if (m_totalTime > MAX_TIME)
            {
                m_totalTime = 0;
                RespawnSystem();
            }
        }


        public void Draw(SpriteBatch spriteBatch, Texture2D splitterTexture, Camera camera)
        {
            for (int i = 0; i < MAX_PARTICLES; i++)
            {
                m_particles[i].Draw(spriteBatch, camera, splitterTexture);
            }    
        }
    }
}
