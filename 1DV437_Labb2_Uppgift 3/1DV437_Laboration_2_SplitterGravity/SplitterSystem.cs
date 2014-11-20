using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace _1DV437_Laboration_2_Smoke
{
    class SplitterSystem
    {
        public SplitterSystem()
        {
        }

        private void RespawnSystem()
        {
            for (int i = 0; i < MAX_PARTICLES; i++)
            {
                m_particles[i] = new SplitterParticle();
            }
        }

        public void Update(float timeElapsed)
        {
            m_totalTime += timeElapsed;

                m_particles[i].Update(timeElapsed);
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
