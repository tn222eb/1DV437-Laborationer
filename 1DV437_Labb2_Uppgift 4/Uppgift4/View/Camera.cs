using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Uppgift4.View
{
    class Camera
    {
        private float scale;

        public Camera(int width, int height)
        {
            int scaleX = width;
            int scaleY = height;
            scale = scaleX;

            if (scaleY < scaleX)
            {
                scale = scaleY;
            }
        }

        public float ToVisualY(float y)
        {
            return scale * y;
        }

        public float ToVisualX(float x)
        {
            return scale * x;
        }

        public float GetScale()
        {
            return scale;
        }

    }
}
