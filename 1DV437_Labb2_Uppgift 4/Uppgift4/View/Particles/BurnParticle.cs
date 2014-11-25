using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Uppgift4.View.Particles
{
    class BurnParticle
    {
        private Vector2 position;
        private float size = 0.1f;

        public BurnParticle(Vector2 position)
        {
            this.position = position;
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D burnTexture, Camera camera)
        {
            int visualX = (int)camera.ToVisualX(position.X);
            int visualY = (int)camera.ToVisualY(position.Y);

            int visualSize = (int)camera.ToVisualY(size);

            Rectangle destinationRectangle = new Rectangle(visualX - (visualSize / 2), visualY - (visualSize / 2), visualSize, visualSize);
            spriteBatch.Begin();
            spriteBatch.Draw(burnTexture, destinationRectangle , Color.Black);
            spriteBatch.End();
        }
    }
}
