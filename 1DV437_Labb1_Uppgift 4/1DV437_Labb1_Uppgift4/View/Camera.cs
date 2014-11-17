using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _1DV437_Labb1_Uppgift4.View
{
    class Camera
    {
        private int m_screenWidth;
        private int m_screenHeight;
        private float m_scale;
        private int m_levelWidth;
        private int m_levelHeight;
        private int m_borderWidth = 1;

        public Camera(int levelWidth, int levelHeight)
        {
            this.m_levelWidth = levelWidth;
            this.m_levelHeight = levelHeight;
        }

        internal void SetDimension(int height, int width)
        {
            this.m_screenWidth = width;
            this.m_screenHeight = height;
            int scaleX = m_screenWidth - (m_borderWidth * 2) / m_levelWidth;
            int scaleY = m_screenHeight - (m_borderWidth * 2) / m_levelHeight;

            this.m_scale = scaleX;

            if (scaleY < scaleX)
            {
                this.m_scale = scaleY;
            }
        }

        internal float GetScale() {
            return this.m_scale;
        }

        internal float ToVisualX(float x) {
            return x * m_scale + m_borderWidth;
        }

        internal float ToVisualY(float y) {
            return y * m_scale + m_borderWidth;
        }

        internal int GetBorderWidth() {
            return this.m_borderWidth;
        }
    }
}
