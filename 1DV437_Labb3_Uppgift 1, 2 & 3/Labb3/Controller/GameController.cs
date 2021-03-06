﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Audio;
using Labb3.View;
using Labb3.View.ParticleSystem;
using Labb3.Model;


namespace Labb3.Controller
{
    class GameController
    {
        private MouseView m_mouseView;
        private Camera m_camera;
        private ContentManager m_content;
        private SoundEffect m_fireSoundEffect;
        private List<ParticleSystem> m_particles;
        private Texture2D m_aimCircleTexture;
        private  BallSimulation m_ballSimulation;

        public GameController(Camera camera, ContentManager content, BallSimulation ballSimulation)
        {
            this.m_camera = camera;
            this.m_mouseView = new MouseView(camera);
            this.m_content = content;

            this.m_fireSoundEffect = m_content.Load<SoundEffect>("fire");
            this.m_aimCircleTexture = m_content.Load<Texture2D>("aimCircle");
            this.m_ballSimulation = ballSimulation;
            this.m_particles = new List<ParticleSystem>();
        }

        public void Update(float elapsedTime)
        {
            if (m_mouseView.DidUserPressButton())
            {
                Vector2 mouseModelPosition = m_mouseView.GetMousePosition();

                m_particles.Add(new ParticleSystem(m_content, m_camera, mouseModelPosition));
                m_fireSoundEffect.Play();
                m_ballSimulation.BallInsideMouseArea(mouseModelPosition);
            }

            foreach (ParticleSystem particle in m_particles) {
                particle.Update(elapsedTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            m_mouseView.DrawMouseAimCircle(spriteBatch, m_aimCircleTexture, m_ballSimulation.GetMouseArea());

            foreach (ParticleSystem particle in m_particles)
            {
                particle.Draw(spriteBatch);
            }
        }

    }
}
