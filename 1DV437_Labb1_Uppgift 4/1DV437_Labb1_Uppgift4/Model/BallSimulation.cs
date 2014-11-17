using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1DV437_Labb1_Uppgift4.Model
{
    class BallSimulation
    {
        public const float LEVEL_SIZE_X = 1.0f;
        public const float LEVEL_SIZE_Y = 1.0f;

        private Ball m_ball = new Ball();

        internal void Update(float TimeElapsedSeconds) {
            m_ball.m_centerX +=  m_ball.m_speedX * TimeElapsedSeconds;

            if (m_ball.m_centerX + (m_ball.m_diameter / 2) > LEVEL_SIZE_X) {
                m_ball.m_speedX = m_ball.m_speedX * -1.0f;
            }

            if (m_ball.m_centerX - (m_ball.m_diameter / 2) < 0) {
                m_ball.m_speedX = m_ball.m_speedX * -1.0f;
            }

            m_ball.m_centerY += m_ball.m_speedY * TimeElapsedSeconds;

            if (m_ball.m_centerY + (m_ball.m_diameter / 2) > LEVEL_SIZE_Y) {
                m_ball.m_speedY = m_ball.m_speedY * -1.0f;
            }

            if (m_ball.m_centerY - (m_ball.m_diameter / 2) < 0)
            {
                m_ball.m_speedY = m_ball.m_speedY * -1.0f;
            }

        }

        internal float GetBallXPosition()
        {
            return m_ball.m_centerX;
        }

        internal float GetBallYPosition()
        {
            return m_ball.m_centerY;
        }

        internal float GetBallDiamater() 
        {
            return m_ball.m_diameter;
        }
    }
}
