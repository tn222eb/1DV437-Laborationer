using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Labb3.Model
{
    class Ball
    {
        private float m_diameter = 0.06f;
        private float m_centerX;
        private float m_centerY;
        private bool m_isAlive;
        private float m_speedY;
        private float m_speedX;

        public Ball(float centerX, float centerY, float speedX, float speedY) {
            this.m_isAlive = true;
            this.m_centerX = centerX;
            this.m_centerY = centerY;
            this.m_speedX = speedX;
            this.m_speedY = speedY;
        }

        public Vector2 GetBallPosition() {
            return new Vector2(m_centerX, m_centerY);
        }

        public float CenterX
        {
            get
            {
                return m_centerX;
            }

            set
            {
                m_centerX = value;
            }
        }

        public float CenterY
        {
            get
            {
                return m_centerY;
            }

            set
            {
                m_centerY = value;
            }
        }

        public float SpeedX
        {
            get
            {
                return m_speedX;
            }

            set 
            {
                m_speedX = value;
            }
        }

        public float SpeedY
        {
            get
            {
                return m_speedY;
            }

            set
            {
                m_speedY = value;
            }
        }

        public bool IsAlive 
        {
            get 
            {
                return m_isAlive;
            }

            set 
            {
                m_isAlive = value;
            }
        }

        public float Diamater
        {
            get
            {
                return m_diameter;
            }
        }
    }
}
