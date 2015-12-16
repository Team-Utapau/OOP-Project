namespace Utrepalo.Game.MenuItem
{
    using System.ComponentModel;
    using System.Windows.Forms;

    public partial class MainGameMenu
    {
        private Button singlePlayerButton;
        private Button exitButton;
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
          
            this.exitButton = new System.Windows.Forms.Button();

            this.SuspendLayout();
            // 
            // singlePlayerButton
            // 
            this.singlePlayerButton.BackColor = System.Drawing.Color.Gray;
            this.singlePlayerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.singlePlayerButton.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.singlePlayerButton.ForeColor = System.Drawing.Color.Black;
            this.singlePlayerButton.Location = new System.Drawing.Point(300, 200);
            this.singlePlayerButton.Name = "singlePlayerButton";
            this.singlePlayerButton.Size = new System.Drawing.Size(127, 50);
            this.singlePlayerButton.TabIndex = 1;
            this.singlePlayerButton.Text = "Load game";

            this.singlePlayerButton.UseVisualStyleBackColor = false;
            this.singlePlayerButton.Click += new System.EventHandler(this.SinglePlayerButton_Click);
           
            this.exitButton.BackColor = System.Drawing.Color.Gray;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.ForeColor = System.Drawing.Color.Black;
            this.exitButton.Location = new System.Drawing.Point(300, 300);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(127, 50);
            this.exitButton.TabIndex = 6;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.ExitButton_Click);
           
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 582);
            this.Controls.Add(this.exitButton);
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