using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Labb3.View.Particles;
using System.Threading.Tasks;
using System.Threading;

namespace Labb3.View.ParticleSystem
{
    class ParticleSystem
    {
        private SmokeSystem smokeSystem;
        private SplitterSystem splitterSystem;
        Texture2D explosionTexture;
        Texture2D splitterTexture;
        Texture2D smokeTexture;
        Camera camera;
        private ExplosionParticle explosionParticle;

        public ParticleSystem(ContentManager content, Camera camera)
        {
            this.explosionTexture = content.Load<Texture2D>("explosion");
            this.splitterTexture = content.Load<Texture2D>("spark");
            this.smokeTexture = content.Load<Texture2D>("smoke");
            this.camera = camera;

            Vector2 vector = new Vector2(0.5f, 0.5f);

            smokeSystem = new SmokeSystem(vector);
            explosionParticle = new ExplosionParticle(vector);
            splitterSystem = new SplitterSystem(vector);
        }

        public void Update(float elapsedTime)
        {
            explosionParticle.Update(elapsedTime);
            splitterSystem.Update(elapsedTime);
            smokeSystem.Update(elapsedTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            explosionParticle.Draw(spriteBatch, explosionTexture, camera);
            splitterSystem.Draw(spriteBatch, splitterTexture, camera);
            smokeSystem.Draw(spriteBatch, smokeTexture, camera);
        }
    }
}
