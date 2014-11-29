using System;
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


namespace Labb3.Controller
{
    class GameController
    {
        private MouseView m_mouseView;
        private Camera m_camera;
        private ContentManager m_content;
        private SoundEffect m_fire;
        private List<ParticleSystem> m_particles;

        public GameController(Camera camera, ContentManager content)
        {
            this.m_camera = camera;
            this.m_mouseView = new MouseView(camera);
            this.m_content = content;

            // m_fire = m_content.Load<SoundEffect>("fire");
            m_particles = new List<ParticleSystem>();
        }

        public void Update(float elapsedTime)
        {
            if (m_mouseView.DidUserPressButton())
            {
                Vector2 mouseModelPosition = m_mouseView.GetMousePosition();

                m_particles.Add(new ParticleSystem(m_content, m_camera, mouseModelPosition));
                // m_fire.Play();
            }

            foreach (ParticleSystem particle in m_particles) {
                particle.Update(elapsedTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (ParticleSystem particle in m_particles)
            {
                particle.Draw(spriteBatch);
            }
        }

    }
}
