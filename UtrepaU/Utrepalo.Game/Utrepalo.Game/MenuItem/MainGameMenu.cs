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
        //private SoundPlayer simpleSound;

        public MainGameMenu()
        {
            //this.InitializeMenuBackgroundMusic();
            this.InitializeComponent();
        }

        public void StartGame()
        {
            //this.simpleSound.Stop();
            KeyboardController keyboardController = new KeyboardController();
            GameEngine game = new GameEngine(keyboardController);
            game.Run();
        }

        //private void InitializeMenuBackgroundMusic()
        //{
        //    this.simpleSound = new SoundPlayer(MenuBackgroundMusic.Volatile_Reaction);
        //    MediaPlayer.Volume = 1f;
        //    this.simpleSound.Play();
        //}

        private void SinglePlayerButton_Click(object sender, EventArgs e)
        {
            this.singlePlayerButton.Visible = false;

            this.exitButton.Visible = false;

            Thread theThread = new Thread(this.StartGame);
            this.Close();
            theThread.Start();
            //GameEngine.Level = GameLevel.Easy;
        }

        //private void Instructions_Click(object sender, EventArgs e)
        //{
        //    this.Hide();
        //    InstructionsForm instrForm = new InstructionsForm();
        //    instrForm.ShowDialog();
        //}

        //private void About_Click(object sender, EventArgs e)
        //{
        //    this.Hide();
        //    AboutForm aboutForm = new AboutForm();
        //    aboutForm.ShowDialog();
        //}

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        //private void EasyLevelButton_Click(object sender, EventArgs e)
        //{
        //    Thread theThread = new Thread(this.StartGame);
        //    this.Close();
        //    theThread.Start();
        //    GameEngine.Level = GameLevel.Easy;
        //}

        //private void MediumLevelButton_Click(object sender, EventArgs e)
        //{
        //    Thread theThread = new Thread(this.StartGame);
        //    this.Close();
        //    theThread.Start();
        //    GameEngine.Level = GameLevel.Medium;
        //}

        //private void HardLevelButton_Click(object sender, EventArgs e)
        //{
        //    Thread theThread = new Thread(this.StartGame);
        //    this.Close();
        //    theThread.Start();
        //    GameEngine.Level = GameLevel.Hard;
        //}

        //private void BackButton_Click(object sender, EventArgs e)
        //{
        //    this.singlePlayerButton.Visible = true;
        //    this.instructions.Visible = true;
        //    this.about.Visible = true;
        //    this.exitButton.Visible = true;

        //    this.easyLevelButton.Visible = false;
        //    this.mediumLevelButton.Visible = false;
        //    this.hardLevelButton.Visible = false;
        //    this.backButton.Visible = false;
        //}

        //private void GameName_Click(object sender, EventArgs e)
        //{
        //}

        private void MainMenu_Load(object sender, EventArgs e)
        {
        }
    }
}
