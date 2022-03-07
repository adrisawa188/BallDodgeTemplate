using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallDodgeTemplate
{
    public partial class GameScreen : UserControl
    {
        Ball chaseBall;
        Player hero;

        List<Ball> dodgeBalls = new List<Ball>(); 

        Random randGen = new Random();
        public static int gsWidth = 600;
        public static int gsHeight = 600;

        bool upArrowDown = false;
        bool downArrowDown = false;
        bool rightArrowDown = false;
        bool leftArrowDown = false;

        public GameScreen()
            
        {
            InitializeComponent();
            InitializeGame();
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            chaseBall.Move();
            foreach (Ball b in dodgeBalls)
            {
                b.Move();
            }

            if (leftArrowDown == true)
            {
                
            }

            Refresh();
        }

        public void InitializeGame()
        {
            int x = randGen.Next(40, gsWidth - 40);
            int y = randGen.Next(40, gsHeight - 40);

            chaseBall = new Ball(x, y, 8, 8);

            x = randGen.Next(40, gsWidth - 40);
            y = randGen.Next(40, gsHeight - 40);
            hero = new Player(x, y);

            for (int i = 0; i < 3; i++)
            {
               x = randGen.Next(40, gsWidth - 40);
               y = randGen.Next(40, gsHeight - 40);

                Ball b = new Ball(x, y, 8, 8);
                dodgeBalls.Add(b);  
            }
        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //switch 
                //case Keys.Left:
                
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillEllipse(Brushes.Green, chaseBall.x, chaseBall.y, chaseBall.size, chaseBall.size);

            foreach (Ball b in dodgeBalls)
            {
                e.Graphics.FillEllipse(Brushes.Red, b.x, b.y, b.size, b.size);
            }

            e.Graphics.FillRectangle(Brushes.DodgerBlue, hero.x, hero.y, hero.width, hero.height);  
        }
    }
}
