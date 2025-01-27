using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survivor_of_the_Bulge
{
    class soldier
    {
        enum AnimState
        {
            walkingRight,
            walkingLeft,
            walkingFront,
            walkingBack,
            facingLeft,
            facingRight,
            facingBack,
            facingFront

        }

        //public GamePadState currPad, oldPad;
        private AnimState m_curState;
        private Texture2D m_walkingFrontSheet;
        private Texture2D m_walkingBackSheet;
        private Texture2D m_walkingLeftSheet;
        public Vector2 m_position;
        private Vector2 m_velocity;
        private float m_walkingSpeed;
        //private const int footmargin = 3;
        private Rectangle m_feetPos;
        private Rectangle m_walkingLeftCell, m_walkingFrontCell, m_walkingBackCell;
        private float m_frameTimer;
        private float m_fps;
        public bool playerMovingRight, playerMovingUp;

        public Rectangle collisionRect;

        public soldier(
            Texture2D walkingLeft, 
            Texture2D walkingFront, 
            Texture2D walkingBack, 
            int xpos, int ypos, 
            int fps)
        {
            
            m_walkingBackSheet = walkingBack;
            m_walkingFrontSheet = walkingFront;
            m_walkingLeftSheet = walkingLeft;
           
            //collision
            collisionRect = new Rectangle(xpos, ypos,
                walkingLeft.Width / 4, walkingLeft.Height);

            m_walkingSpeed = 1f;
            m_velocity = new Vector2(0, 0);
            m_position = new Vector2(800, 400);
            m_curState = AnimState.walkingLeft;
            m_walkingLeftCell = new Rectangle(0, 0, walkingLeft.Width / 4, walkingLeft.Height);
            m_walkingFrontCell = new Rectangle(0, 0, walkingFront.Width / 4, walkingFront.Height);
            m_walkingBackCell = new Rectangle(0, 0, walkingBack.Width / 4, walkingBack.Height);
            m_frameTimer = 1;
            m_fps = fps;
        }

        public void updateMe(GamePadState curPad, GamePadState oldPad)
        {
            
            curPad = GamePad.GetState(PlayerIndex.One);

            //handle player-controller movement
            m_curState = AnimState.walkingLeft;
            m_velocity.X = 0;
            m_velocity.Y = 0;
            if (curPad.DPad.Left == ButtonState.Pressed)
            {
                playerMovingRight = false;
                m_velocity.X = -m_walkingSpeed;
               
                if (m_velocity.X != 0)
                    m_curState = AnimState.walkingLeft;
                else
                    
                    m_curState = AnimState.walkingLeft;
            }
             if (curPad.DPad.Right == ButtonState.Pressed)
             {
                playerMovingRight = true;
                m_velocity.X = m_walkingSpeed;
                if (m_velocity.X != 0)
                    m_curState = AnimState.walkingRight;
                //else
                //    m_curState = AnimState.walkingRight;
             }
             if (curPad.DPad.Up == ButtonState.Pressed)
             {
                playerMovingUp = true;
                m_velocity.Y = -m_walkingSpeed;
                if (m_velocity.Y != 0)
                    m_curState = AnimState.walkingBack;
                else
                   m_curState = AnimState.walkingBack;
             }
             if (curPad.DPad.Down == ButtonState.Pressed)
             {
                playerMovingUp = false;
                m_velocity.Y = m_walkingSpeed;
                if (m_velocity.Y != 0)
                    m_curState = AnimState.walkingFront;
                else
                    m_curState = AnimState.walkingFront;
             }

            //else if ((m_curState == AnimState.walkingLeft) || (m_curState == AnimState.facingLeft))
            //    m_curState = AnimState.facingLeft;

            //else if ((m_curState == AnimState.walkingRight) || (m_curState == AnimState.facingRight))
            //    m_curState = AnimState.facingRight;

            //else if ((m_curState == AnimState.walkingBack) || (m_curState == AnimState.facingBack))
            //    m_curState = AnimState.facingBack;

            //else if ((m_curState == AnimState.walkingFront) || (m_curState == AnimState.facingFront))
            //    m_curState = AnimState.facingFront;


            //collision
            m_position += m_velocity;
            collisionRect.X = (int)m_position.X;
            collisionRect.Y = (int)m_position.Y;

            //// handle screen wrap
            //if (m_position.X + collisionRect.Width < 0)
            //    m_position.X = screenSize.Width - 1;
            //if (m_position.X > screenSize.Width)
            //    m_position.X = 1 - collisionRect.Width;
           
        }
        public void drawMe(SpriteBatch sb, GameTime gt)
        {
            if (m_frameTimer <= 0)
            {
               m_walkingLeftCell.X = (m_walkingLeftCell.X + m_walkingLeftCell.Width);
                if (m_walkingLeftCell.X >= m_walkingLeftSheet.Width)
                    m_walkingLeftCell.X = 0;

                m_walkingFrontCell.X = (m_walkingFrontCell.X + m_walkingFrontSheet.Width);
                if (m_walkingFrontCell.X >= m_walkingFrontSheet.Width)
                    m_walkingFrontCell.X = 0;

                m_walkingBackCell.X = (m_walkingBackCell.X + m_walkingBackSheet.Width);
                if (m_walkingBackCell.X >= m_walkingBackSheet.Width)
                    m_walkingBackCell.X = 0;

                m_frameTimer = 1;
            }
            else
            {
                m_frameTimer -= (float)gt.ElapsedGameTime.TotalSeconds * m_fps;
            }
            //sb.Draw(m_walkingFrontSheet, m_position, collisionRect, Color.White);
            //if for animation with dpad. 
            //only detect when player is moving
            // or 
            //case AnimState.facingLeft:
            //sb.Draw(m_walkingLeftSheet, m_position, [collision rec], Color.White);
            //break;

           // m_curState = AnimState.walkingLeft;
            switch (m_curState)
            {
                case AnimState.walkingLeft:
                    sb.Draw(m_walkingLeftSheet, m_position, m_walkingLeftCell , Color.White);
                    break;
                case AnimState.walkingRight:
                    sb.Draw(m_walkingLeftSheet, m_position, m_walkingLeftCell, Color.White,
                        0, Vector2.Zero, 1, SpriteEffects.FlipHorizontally, 0);
                    break;
                case AnimState.walkingFront:
                    sb.Draw(m_walkingFrontSheet, m_position, m_walkingFrontCell, Color.White);
                    break;
                case AnimState.walkingBack:
                    sb.Draw(m_walkingBackSheet, m_position, m_walkingBackCell, Color.White);
                    break;
               


            }
        }
    }





}
   

