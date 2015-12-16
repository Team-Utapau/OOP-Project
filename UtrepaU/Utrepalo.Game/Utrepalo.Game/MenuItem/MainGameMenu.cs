using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Xna.Framework.Media;
using Utrepalo.Game.KeyboardHandler;

namespace Utrepalo.Game.MenuItem
{
    public partial class MainGameMenu : BackgroundForm
    {

        public MainGameMenu()
        {
            this.InitializeComponent();
        }

        public void StartGame()
        {
            KeyboardController keyboardController = new KeyboardController();
            GameEngine game = new GameEngine(keyboardController);
            game.Run();
        }


        private void SinglePlayerButton_Click(object sender, EventArgs e)
        {
            this.singlePlayerButton.Visible = false;

            this.exitButton.Visible = false;

            Thread theThread = new Thread(this.StartGame);
            this.Close();
            theThread.Start();
        }

 

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
        }
    }
}
