using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Labb_1.View
{
    class Camera
    {
        private int m_borderSize = 64;
        private int m_width;
        private int m_height;
        private int m_scale;

        public void SetDimension(Viewport port)
        {
            this.m_width = port.Width;
            this.m_height = port.Height;

            int scaleX = m_width - (2 * m_borderSize) / Model.Level.SIZE_X;
            int scaleY = m_height - (2 * m_borderSize) / Model.Level.SIZE_Y;

            this.m_scale = scaleX;
            if (scaleY < scaleX)
            {
                this.m_scale = scaleY;
            }
        }

        public Vector2 ToVisualCoordinate(Vector2 logicalCoordinate) {
            float visualCoordinateX = logicalCoordinate.X * m_scale + m_borderSize;
            float visualCoordinateY = logicalCoordinate.Y * m_scale + m_borderSize;

            return new Vector2(visualCoordinateX, visualCoordinateY);
        }

        // 512, 512
        // 128, 512 
        // 384, 64 
        // 64, 64
        public Vector2 RotateLogicalCoordinate(Vector2 logicalCoordinate) {
            float logicalCoordinateX = Model.Level.SIZE_X - logicalCoordinate.X;
            float logicalCoordinateY = Model.Level.SIZE_Y - logicalCoordinate.Y;
            Vector2 RotatedLogicalCoordinate = new Vector2(logicalCoordinateX, logicalCoordinateY);

            Vector2 visualCoordinate = ToVisualCoordinate(RotatedLogicalCoordinate);
            return visualCoordinate;
        }
    }   
}