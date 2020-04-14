namespace Memory
{
    partial class GameTimerForm
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
            this.components = new System.ComponentModel.Container();
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            this.gameTimerLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // GameTimer
            // 
            this.GameTimer.Interval = 1000;
            this.GameTimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // gameTimerLabel
            // 
            this.gameTimerLabel.AutoSize = true;
            this.gameTimerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 55F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameTimerLabel.ForeColor = System.Drawing.Color.Red;
            this.gameTimerLabel.Location = new System.Drawing.Point(50, 61);
            this.gameTimerLabel.Name = "gameTimerLabel";
            this.gameTimerLabel.Size = new System.Drawing.Size(96, 104);
            this.gameTimerLabel.TabIndex = 0;
            this.gameTimerLabel.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(-5, -5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(225, 48);
            this.label2.TabIndex = 2;
            this.label2.Text = "Your Time:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // GameTimerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Pink;
            this.ClientSize = new System.Drawing.Size(253, 198);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gameTimerLabel);
            this.Location = new System.Drawing.Point(850, 100);
            this.Name = "GameTimerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Timer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Label gameTimerLabel;
        public System.Windows.Forms.Timer GameTimer;
        public System.Windows.Forms.Label label2;
    }
}