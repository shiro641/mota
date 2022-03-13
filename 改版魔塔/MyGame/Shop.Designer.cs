namespace MyGame
{
    partial class Shop
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
            this.adddefend1 = new MyGame.Adddefend();
            this.addattack1 = new MyGame.Addattack();
            this.shopview1 = new MyGame.Shopview();
            this.SuspendLayout();
            // 
            // adddefend1
            // 
            this.adddefend1.BackColor = System.Drawing.Color.Gray;
            this.adddefend1.Location = new System.Drawing.Point(75, 272);
            this.adddefend1.Name = "adddefend1";
            this.adddefend1.Size = new System.Drawing.Size(358, 60);
            this.adddefend1.TabIndex = 2;
            this.adddefend1.Text = "adddefend1";
            // 
            // addattack1
            // 
            this.addattack1.BackColor = System.Drawing.Color.Gray;
            this.addattack1.Location = new System.Drawing.Point(75, 155);
            this.addattack1.Name = "addattack1";
            this.addattack1.Size = new System.Drawing.Size(358, 61);
            this.addattack1.TabIndex = 1;
            this.addattack1.Text = "addattack1";
            // 
            // shopview1
            // 
            this.shopview1.BackColor = System.Drawing.Color.Black;
            this.shopview1.Location = new System.Drawing.Point(75, 58);
            this.shopview1.Name = "shopview1";
            this.shopview1.Size = new System.Drawing.Size(397, 68);
            this.shopview1.TabIndex = 0;
            this.shopview1.Text = "shopview1";
            // 
            // Shop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(521, 450);
            this.Controls.Add(this.adddefend1);
            this.Controls.Add(this.addattack1);
            this.Controls.Add(this.shopview1);
            this.MaximizeBox = false;
            this.Name = "Shop";
            this.Text = "Shop";
            this.ResumeLayout(false);

        }

        #endregion

        private Shopview shopview1;
        public Addattack addattack1;
        public Adddefend adddefend1;
    }
}