using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace _2DAnimation
{
    class View
    {
        private Model model = new Model();
        private int numFramesX = 4;
        private SpriteBatch spriteBatch;
        private Texture2D texture;

        public View(int width, int height, SpriteBatch spritebatch, Texture2D texture)
        {
            this.spriteBatch = spritebatch;
            this.texture = texture;
        }

        public void Draw(float elapsedTime) {
             int frame = model.Update(elapsedTime);
             float frameX = frame % numFramesX;
             float frameY = frame / numFramesX;

             int frameSize = texture.Width / 4;

             int visualFrameX = (int)frameX * frameSize;
             int visualFrameY = (int)frameY * frameSize;

             Rectangle destinationRectangle = new Rectangle(0, 0, 120, 120);
             Rectangle sourceRectangle = new Rectangle(visualFrameX , visualFrameY, frameSize, frameSize);

             spriteBatch.Begin();
             spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
             spriteBatch.End();
        }
    }
}
