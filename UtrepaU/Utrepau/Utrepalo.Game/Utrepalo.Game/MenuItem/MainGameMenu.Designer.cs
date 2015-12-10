namespace Utrepalo.Game.MenuItem
{
    using System.ComponentModel;
    using System.Windows.Forms;

    public partial class MainGameMenu
    {
        private Button singlePlayerButton;
        //private Label gameName;
        //private Button instructions;
        //private Button about;
        private Button exitButton;
        //private Button easyLevelButton;
        //private Button mediumLevelButton;
        //private Button hardLevelButton;
        //private Button backButton;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.singlePlayerButton = new System.Windows.Forms.Button();
            //this.gameName = new System.Windows.Forms.Label();
            //this.instructions = new System.Windows.Forms.Button();
            //this.about = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            //this.easyLevelButton = new System.Windows.Forms.Button();
            //this.mediumLevelButton = new System.Windows.Forms.Button();
            //this.hardLevelButton = new System.Windows.Forms.Button();
            //this.backButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // singlePlayerButton
            // 
            this.singlePlayerButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.singlePlayerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.singlePlayerButton.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.singlePlayerButton.ForeColor = System.Drawing.Color.LightGray;
            this.singlePlayerButton.Location = new System.Drawing.Point(265, 131);
            this.singlePlayerButton.Name = "singlePlayerButton";
            this.singlePlayerButton.Size = new System.Drawing.Size(107, 32);
            this.singlePlayerButton.TabIndex = 1;
            this.singlePlayerButton.Text = "Load game";

            this.singlePlayerButton.UseVisualStyleBackColor = false;
            this.singlePlayerButton.Click += new System.EventHandler(this.SinglePlayerButton_Click);
            // 
            // gameName
            // 
            //this.gameName.AutoSize = true;
            //this.gameName.BackColor = System.Drawing.Color.Transparent;
            //this.gameName.Font = new System.Drawing.Font("Impact", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //this.gameName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(28)))), ((int)(((byte)(11)))));
            //this.gameName.Location = new System.Drawing.Point(40, 9);
            //this.gameName.Name = "gameName";
            //this.gameName.Size = new System.Drawing.Size(550, 80);
            //this.gameName.TabIndex = 0;
            //this.gameName.Text = "Ultimate Tank Clash";
            //this.gameName.Click += new System.EventHandler(this.GameName_Click);
            //// 
            // instructions
            // 
            //this.instructions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            //this.instructions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            //this.instructions.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //this.instructions.ForeColor = System.Drawing.Color.LightGray;
            //this.instructions.Location = new System.Drawing.Point(265, 169);
            //this.instructions.Name = "instructions";
            //this.instructions.Size = new System.Drawing.Size(107, 30);
            //this.instructions.TabIndex = 4;
            //this.instructions.Text = "Instructions";
            //this.instructions.UseVisualStyleBackColor = false;
            //this.instructions.Click += new System.EventHandler(this.Instructions_Click);
            // 
            // about
            // 
            //this.about.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            //this.about.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            //this.about.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //this.about.ForeColor = System.Drawing.Color.LightGray;
            //this.about.Location = new System.Drawing.Point(265, 207);
            //this.about.Name = "about";
            //this.about.Size = new System.Drawing.Size(107, 30);
            //this.about.TabIndex = 5;
            //this.about.Text = "About";
            //this.about.UseVisualStyleBackColor = false;
            //this.about.Click += new System.EventHandler(this.About_Click);
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.ForeColor = System.Drawing.Color.LightGray;
            this.exitButton.Location = new System.Drawing.Point(265, 243);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(107, 30);
            this.exitButton.TabIndex = 6;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // easyLevelButton
            // 
            //this.easyLevelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            //this.easyLevelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            //this.easyLevelButton.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //this.easyLevelButton.ForeColor = System.Drawing.Color.LightGray;
            //this.easyLevelButton.Location = new System.Drawing.Point(119, 181);
            //this.easyLevelButton.Name = "easyLevelButton";
            //this.easyLevelButton.Size = new System.Drawing.Size(107, 33);
            //this.easyLevelButton.TabIndex = 7;
            //this.easyLevelButton.Text = "Easy";
            //this.easyLevelButton.UseVisualStyleBackColor = false;
            //this.easyLevelButton.Visible = false;
            //this.easyLevelButton.Click += new System.EventHandler(this.EasyLevelButton_Click);
            // 
            // mediumLevelButton
            // 
            //this.mediumLevelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            //this.mediumLevelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            //this.mediumLevelButton.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //this.mediumLevelButton.ForeColor = System.Drawing.Color.LightGray;
            //this.mediumLevelButton.Location = new System.Drawing.Point(265, 181);
            //this.mediumLevelButton.Name = "mediumLevelButton";
            //this.mediumLevelButton.Size = new System.Drawing.Size(107, 33);
            //this.mediumLevelButton.TabIndex = 8;
            //this.mediumLevelButton.Text = "Medium";
            //this.mediumLevelButton.UseVisualStyleBackColor = false;
            //this.mediumLevelButton.Visible = false;
            //this.mediumLevelButton.Click += new System.EventHandler(this.MediumLevelButton_Click);
            // 
            // hardLevelButton
            // 
            //this.hardLevelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            //this.hardLevelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            //this.hardLevelButton.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //this.hardLevelButton.ForeColor = System.Drawing.Color.LightGray;
            //this.hardLevelButton.Location = new System.Drawing.Point(407, 181);
            //this.hardLevelButton.Name = "hardLevelButton";
            //this.hardLevelButton.Size = new System.Drawing.Size(107, 33);
            //this.hardLevelButton.TabIndex = 9;
            //this.hardLevelButton.Text = "Hard";
            //this.hardLevelButton.UseVisualStyleBackColor = false;
            //this.hardLevelButton.Visible = false;
            //this.hardLevelButton.Click += new System.EventHandler(this.HardLevelButton_Click);
            // 
            // backButton
            // 
            //this.backButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            //this.backButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            //this.backButton.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //this.backButton.ForeColor = System.Drawing.Color.LightGray;
            //this.backButton.Location = new System.Drawing.Point(12, 400);
            //this.backButton.Name = "backButton";
            //this.backButton.Size = new System.Drawing.Size(107, 30);
            //this.backButton.TabIndex = 10;
            //this.backButton.Text = "Back";
            //this.backButton.UseVisualStyleBackColor = false;
            //this.backButton.Visible = false;
            //this.backButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 442);
            //this.Controls.Add(this.backButton);
            //this.Controls.Add(this.hardLevelButton);
            //this.Controls.Add(this.mediumLevelButton);
            //this.Controls.Add(this.easyLevelButton);
            this.Controls.Add(this.exitButton);
            //this.Controls.Add(this.about);
            //this.Controls.Add(this.instructions);
            //this.Controls.Add(this.gameName);
            this.Controls.Add(this.singlePlayerButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Main Menu";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}