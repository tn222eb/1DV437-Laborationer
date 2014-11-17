using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using _1DV437_Labb1_Uppgift4.Model;
using Microsoft.Xna.Framework;

namespace _1DV437_Labb1_Uppgift4.View
{
    class BallView
    {
        private Camera m_camera;
        private BallSimulation m_ballSimulation;
        private SpriteBatch m_spriteBatch;
        private Texture2D m_backgroundTexture;
        private int m_screenHeight;
        private int m_screenWidth;
        private Texture2D m_ballTexture;
        private Texture2D m_border;

        public BallView(BallSimulation ballSimulation, SpriteBatch spriteBatch, Texture2D backgroundTexture, Texture2D ballTexture, Texture2D border, int screenHeight, int screenWidth) {
            this.m_ballSimulation = ballSimulation;
            this.m_spriteBatch = spriteBatch;
            this.m_backgroundTexture = backgroundTexture;
            this.m_screenHeight = screenHeight;
            this.m_screenWidth = screenWidth;
            this.m_ballTexture = ballTexture;
            this.m_border = border; 

            this.m_camera = new Camera((int)Model.BallSimulation.LEVEL_SIZE_X, (int)Model.BallSimulation.LEVEL_SIZE_Y);
            this.m_camera.SetDimension(screenHeight, screenWidth);
        }

        internal void DrawBall() {
            int visualX = (int)m_camera.ToVisualX(m_ballSimulation.GetBallXPosition());
            int visualY = (int)m_camera.ToVisualY(m_ballSimulation.GetBallYPosition());
            int vBallSize = (int)(m_ballSimulation.GetBallDiamater() * m_camera.GetScale());

            Rectangle destinationRectangle = new Rectangle(visualX - (vBallSize / 2), visualY - (vBallSize / 2), vBallSize, vBallSize);

            m_spriteBatch.Begin();
            m_spriteBatch.Draw(m_ballTexture, destinationRectangle, Color.White);
            m_spriteBatch.End();
        }

        // http://stackoverflow.com/questions/2795741/displaying-rectangles-in-game-window-with-xna
        internal void DrawLevel() {
            int visualX = (int)m_camera.ToVisualX(BallSimulation.LEVEL_SIZE_X);
            int visualY = (int)m_camera.ToVisualY(BallSimulation.LEVEL_SIZE_Y);

            m_spriteBatch.Begin();

            Rectangle destinationRectangle = new Rectangle(0, 0, visualX, visualY);
            m_spriteBatch.Draw(m_backgroundTexture, destinationRectangle, Color.Black);

            int borderWidth = m_camera.GetBorderWidth();

            // Ritar ut vänster sidan av ram
            m_spriteBatch.Draw(m_border, new Rectangle(destinationRectangle.Left, destinationRectangle.Top, borderWidth, destinationRectangle.Height), Color.White);
            // Ritar ut höger av ram                               
            m_spriteBatch.Draw(m_border, new Rectangle(destinationRectangle.Right, destinationRectangle.Top, borderWidth, destinationRectangle.Height), Color.White);
            // Ritar ut yttersta av ram
            m_spriteBatch.Draw(m_border, new Rectangle(destinationRectangle.Left, destinationRectangle.Top, destinationRectangle.Width, borderWidth), Color.White);
            // Ritar ut nedersta av ram                      
            m_spriteBatch.Draw(m_border, new Rectangle(destinationRectangle.Left, destinationRectangle.Bottom - borderWidth, destinationRectangle.Width, borderWidth), Color.White); 
            
            m_spriteBatch.End();
        }
    }
}
