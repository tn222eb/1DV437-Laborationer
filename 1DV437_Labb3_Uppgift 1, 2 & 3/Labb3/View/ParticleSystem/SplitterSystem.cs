﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Labb3.View.Particles;

namespace Labb3.View.ParticleSystem
{
    class SplitterSystem
    {
        private SplitterParticle[] m_particles;
        private int MAX_PARTICLES = 100;
        private float m_totalTime = 0;
        private float m_maxSpeed = 0.2f;
        private Vector2 m_position;

        public SplitterSystem(Vector2 position)
        {
            m_position = position;
            m_particles = new SplitterParticle[MAX_PARTICLES];

            RespawnSystem();
        }
        private void RespawnSystem()
        {
            Random rand = new Random();

            for (int i = 0; i < MAX_PARTICLES; i++)
            {
                Vector2 randomDirection = new Vector2(((float)rand.NextDouble() - 0.5f), ((float)rand.NextDouble() - 0.5f));
                randomDirection.Normalize();
                randomDirection = randomDirection * ((float)rand.NextDouble() * m_maxSpeed);

                m_particles[i] = new SplitterParticle(randomDirection, m_position);
            }
        }

        public void Update(float timeElapsed)
        {
            m_totalTime += timeElapsed;

            for (int i = 0; i < MAX_PARTICLES; i++)
            {
                m_particles[i].Update(timeElapsed);
            }
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D splitterTexture, Camera camera)
        {
            for (int i = 0; i < MAX_PARTICLES; i++)
            {
                m_particles[i].Draw(spriteBatch, camera, splitterTexture);
            }
        }
    }
}