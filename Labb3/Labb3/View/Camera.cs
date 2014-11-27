using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labb3.View
{
    class Camera
    {
        private float m_scale;
        private int m_borderWidth = 1;

        public Camera(int width, int height)
        {
            int scaleX = width - m_borderWidth * 2;
            int scaleY = height - m_borderWidth * 2;

            m_scale = scaleX;

            if (scaleY < scaleX)
            {
                m_scale = scaleY;
            }
        }

        internal float GetScale()
        {
            return this.m_scale;
        }

        internal float ToVisualX(float x)
        {
            return x * m_scale + m_borderWidth;
        }

        internal float ToVisualY(float y)
        {
            return y * m_scale + m_borderWidth;
        }

        internal int GetBorderWidth()
        {
            return this.m_borderWidth;
        }
    }
}
