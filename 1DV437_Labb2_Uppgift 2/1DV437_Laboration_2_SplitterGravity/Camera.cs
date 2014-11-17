using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace _1DV437_Laboration_2_Smoke
{
    class Camera
    {
        private float scale;

        public Camera(int width, int height)
        {
            int scaleX = width / (int)Level.SIZE_X;
            int scaleY = height / (int)Level.SIZE_Y;
            scale = scaleX;

            if (scaleY < scaleX)
            {
                scale = scaleY;
            }
        }

        public float ToVisualX(float x) {
            return x * scale;
        }

        public float ToVisualY(float y)
        {
            return y * scale;
        }
    }
}
