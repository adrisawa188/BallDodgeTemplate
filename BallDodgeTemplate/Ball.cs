using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BallDodgeTemplate
{
    internal class Ball
    {
        //colour rectangle
        public int size = 10;
        public int xSpeed, ySpeed ;
        public int x, y;

        public Ball(int _x, int _y, int _xSpeed, int _ySpeed)
        {
            x= _x;
            y= _y;
            xSpeed= _xSpeed;
            ySpeed= _ySpeed;
        }

        public void Move(Size ss)
        {
            x += xSpeed;
            y += ySpeed;

            //chech if ball has reached right or left edge 
            if (x > ss.Width - size || x < 0)
            {
                xSpeed *= -1; ;
            }

            //chech if ball has reached top or bottom edge 
            if (y > ss.Height - size || y < 0)
            {
                ySpeed *= -1; ;
            }
        }   
        public bool Collision(Player p)
        {
            //chaseball collion with player
            Rectangle ballRec = new Rectangle(x, y, size, size);
            Rectangle playerRec = new Rectangle(p.x, p.y, p.width, p.height);

            if (ballRec.IntersectsWith(playerRec))
            {
                if (ySpeed > 0)
                {
                    y = p.y - p.height;
                }
                else
                {
                    y = p.y + p.height;
                }
                ySpeed *= -1;
                return true;
            }
            return false;
        }
    }
}
