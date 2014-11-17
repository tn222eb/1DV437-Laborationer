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
        private float m_elapsedTime;
        private float m_maxTime = 0.5f;
        private float percentAnimated;
        private float numberOfFrames = 24;
        private float m_explosion = 0.2f; 

        public SplitterParticle()
        {

        }

        public void Update(float timeElapsed)
        {
            m_elapsedTime += timeElapsed;
            percentAnimated = timeElapsed / m_maxTime;
            int frame = (int)(percentAnimated * numberOfFrames);
        }

        public void Draw(SpriteBatch spriteBatch, Camera camera, Texture2D splitterTexture)
        {
      
                int visualX = (int)camera.ToVisualX(m_splitterPosition.X);
                int visualY = (int)camera.ToVisualY(m_splitterPosition.Y);
                int visualSize = (int)camera.ToVisualX(m_explosion);


                spriteBatch.Begin();

                Rectangle rectangle = new Rectangle(visualX, visualY, visualSize, visualSize);
                spriteBatch.Draw(splitterTexture, rectangle, Color.White);
                spriteBatch.End();
            
        }
    }
}
