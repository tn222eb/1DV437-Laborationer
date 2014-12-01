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

        public Ball(int i ) {
            this.m_isAlive = true;

            Random rand = new Random(i);

            this.m_centerX = (float)rand.NextDouble() * 0.8f + 0.1f;
            this.m_centerY = (float)rand.NextDouble() * 0.8f + 0.1f;

            this.m_speedX = (float)rand.NextDouble() * 0.8f + 0.2f;
            this.m_speedY = (float)rand.NextDouble() * 0.8f + 0.2f;

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
