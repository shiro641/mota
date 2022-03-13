namespace MyGame
{
    partial class Battle4form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
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
            this.battleview1 = new MyGame.Battleview();
            this.SuspendLayout();
            // 
            // battleview1
            // 
            this.battleview1.Location = new System.Drawing.Point(-2, -1);
            this.battleview1.Name = "battleview1";
            this.battleview1.Size = new System.Drawing.Size(365, 706);
            this.battleview1.TabIndex = 0;
            this.battleview1.Text = "battleview1";
            // 
            // Battle4form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 703);
            this.Controls.Add(this.battleview1);
            this.MaximizeBox = false;
            this.Name = "Battle4form";
            this.Text = "battle";
            this.ResumeLayout(false);

        }

        #endregion

        public Battleview battleview1;
    }
}