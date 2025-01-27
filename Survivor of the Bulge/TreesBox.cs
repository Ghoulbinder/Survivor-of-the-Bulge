using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survivor_of_the_Bulge
{
    class TreesBox: StaticGraphic
    {
        public Rectangle Surface;

        public TreesBox(Texture2D txr, int xpos, int ypos) :
            base(txr, xpos, ypos)
        {
           Surface = new Rectangle(xpos, ypos, txr.Width, txr.Height);
      
        }


    }
}
