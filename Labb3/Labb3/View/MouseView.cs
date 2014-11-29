using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Labb3.View
{
    class MouseView
    {
        private MouseState currentMouseState, previousMouseState;
        private Camera camera;

        public MouseView(Camera camera) {
            this.camera = camera;
        }

        public void DrawMouseAimCircle(SpriteBatch spriteBatch, Texture2D aimCircleTexture, float mouseDiameter) {
            int mouseArea = (int)(mouseDiameter * camera.GetScale());
            Rectangle destinationRectangle = new Rectangle(currentMouseState.X - mouseArea / 2, currentMouseState.Y - mouseArea / 2, mouseArea, mouseArea);
            
            spriteBatch.Begin();
            spriteBatch.Draw(aimCircleTexture, destinationRectangle, Color.White);
            spriteBatch.End();
        }

        public bool DidUserPressButton() {
            bool buttonPressed = false;

            previousMouseState = currentMouseState;
            currentMouseState = Mouse.GetState();

            if (previousMouseState.LeftButton == ButtonState.Pressed && currentMouseState.LeftButton == ButtonState.Released)
            {
                buttonPressed = true;
            }

            return buttonPressed;
        }

        public Vector2 GetMousePosition() {
            currentMouseState = Mouse.GetState();

            float modelX = camera.ToModelX(currentMouseState.X);
            float modelY = camera.ToModelY(currentMouseState.Y);

            Vector2 mouseModelPosition = new Vector2(modelX, modelY);
            return mouseModelPosition;
        }
    }
}
