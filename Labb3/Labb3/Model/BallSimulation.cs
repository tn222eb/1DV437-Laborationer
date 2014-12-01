using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;

namespace Labb3.Model
{
    class BallSimulation
    {
        public const float LEVEL_SIZE_X = 1.0f;
        public const float LEVEL_SIZE_Y = 1.0f;
        public const int NUM_BALLS = 10;

        private float m_mouseArea = 0.3f;
        private List<Ball> m_ballList;

        public BallSimulation()
        {
            m_ballList = new List<Ball>();
            Random rand = new Random();

            for (int i = 0; i < NUM_BALLS; i++)
            {
                float centerX = (float)rand.NextDouble() * 0.9f + 0.1f;
                float centerY = (float)rand.NextDouble() * 0.9f + 0.1f;

                float speedX = (float)rand.NextDouble() * 0.8f + 0.2f;
                float speedY = (float)rand.NextDouble() * 0.8f + 0.2f;

                m_ballList.Add(new Ball(centerX, centerY, speedX, speedY));
            }
        }

        public List<Ball> getBallList() {
            return m_ballList;
        }

        internal void BallInsideMouseArea(Vector2 mousePosition)
        {
            foreach (var ball in m_ballList)
            {
                if (ball.IsAlive)
                {
                    if (Vector2.Distance(mousePosition, ball.GetBallPosition()) < m_mouseArea / 2)
                    {
                        ball.IsAlive = false;
                    }
                }
            }
        }

        internal float GetMouseArea()
        {
            return m_mouseArea;
        }

        internal void Update(float timeElapsedSeconds)
        {
            foreach (Ball ball in m_ballList)
            {
                if (ball.IsAlive)
                {
                    ball.CenterX += ball.SpeedX * timeElapsedSeconds;

                    if (ball.CenterX + (ball.Diamater / 2) > LEVEL_SIZE_X)
                    {
                        ball.SpeedX = ball.SpeedX * -1.0f;
                    }

                    if (ball.CenterX - (ball.Diamater / 2) < 0)
                    {
                        ball.SpeedX = ball.SpeedX * -1.0f;
                    }

                    ball.CenterY += ball.SpeedY * timeElapsedSeconds;

                    if (ball.CenterY + (ball.Diamater / 2) > LEVEL_SIZE_Y)
                    {
                        ball.SpeedY = ball.SpeedY * -1.0f;
                    }

                    if (ball.CenterY - (ball.Diamater / 2) < 0)
                    {
                        ball.SpeedY = ball.SpeedY * -1.0f;
                    }
                }
            }
        }
    }
}
