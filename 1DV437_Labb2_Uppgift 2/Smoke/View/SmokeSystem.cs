using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace Smoke.View
{
    class SmokeSystem
    {
        private List<SmokeParticle> smokeParticles = new List<SmokeParticle>();
        private float NUM_PARTICLES = 45;
        private float totalTime = 0;
        private float delayTime = 0.2f;

        public void Draw(SpriteBatch spriteBatch, Texture2D smokeTexture, Camera camera)
        {
            for (int i = 0; i < smokeParticles.Count; i++)
            {
                smokeParticles[i].Draw(spriteBatch, smokeTexture, camera);
            }
        }

        public void Update(float timeElapsed)
        {
            totalTime += timeElapsed;

            if (totalTime >= delayTime)
            {
                totalTime = 0;

                if (smokeParticles.Count < NUM_PARTICLES)
                {
                    smokeParticles.Add(new SmokeParticle());
                }
            }

            for (int i = 0; i < smokeParticles.Count; i++)
            {
                smokeParticles[i].Update(timeElapsed);

                if (smokeParticles[i].IsDead())
                {
                    smokeParticles[i].Spawn();
                }
            }
        }
    }
}
