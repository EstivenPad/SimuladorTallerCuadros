namespace SimuladorTallerCuadros
{
    partial class MainForm
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
            this.CantidadMarcosTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TiempoTextBox = new System.Windows.Forms.TextBox();
            this.CronometroTimer = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.Carpintero1Timer = new System.Windows.Forms.Timer(this.components);
            this.Carpintero2Timer = new System.Windows.Forms.Timer(this.components);
            this.Carpintero3Timer = new System.Windows.Forms.Timer(this.components);
            this.Carpintero4Timer = new System.Windows.Forms.Timer(this.components);
            this.Carpintero5Timer = new System.Windows.Forms.Timer(this.components);
            this.TiempoLabel = new System.Windows.Forms.Label();
            this.LlegadaTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // CantidadMarcosTextBox
            // 
            this.CantidadMarcosTextBox.Location = new System.Drawing.Point(462, 156);
            this.CantidadMarcosTextBox.Name = "CantidadMarcosTextBox";
            this.CantidadMarcosTextBox.Size = new System.Drawing.Size(200, 20);
            this.CantidadMarcosTextBox.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(459, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Cantidad de Marcos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(85, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tiempo";
            // 
            // TiempoTextBox
            // 
            this.TiempoTextBox.Location = new System.Drawing.Point(88, 156);
            this.TiempoTextBox.Name = "TiempoTextBox";
            this.TiempoTextBox.Size = new System.Drawing.Size(200, 20);
            this.TiempoTextBox.TabIndex = 1;
            // 
            // CronometroTimer
            // 
            this.CronometroTimer.Interval = 500;
            this.CronometroTimer.Tick += new System.EventHandler(this.CronometroTimer_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(287, 233);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(160, 72);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Carpintero1Timer
            // 
            this.Carpintero1Timer.Tick += new System.EventHandler(this.Carpintero1Timer_Tick);
            // 
            // Carpintero2Timer
            // 
            this.Carpintero2Timer.Tick += new System.EventHandler(this.Carpintero2Timer_Tick);
            // 
            // Carpintero3Timer
            // 
            this.Carpintero3Timer.Tick += new System.EventHandler(this.Carpintero3Timer_Tick);
            // 
            // Carpintero4Timer
            // 
            this.Carpintero4Timer.Tick += new System.EventHandler(this.Carpintero4Timer_Tick);
            // 
            // Carpintero5Timer
            // 
            this.Carpintero5Timer.Tick += new System.EventHandler(this.Carpintero5Timer_Tick);
            // 
            // TiempoLabel
            // 
            this.TiempoLabel.AutoSize = true;
            this.TiempoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TiempoLabel.Location = new System.Drawing.Point(336, 156);
            this.TiempoLabel.Name = "TiempoLabel";
            this.TiempoLabel.Size = new System.Drawing.Size(54, 20);
            this.TiempoLabel.TabIndex = 5;
            this.TiempoLabel.Text = "00:00";
            // 
            // LlegadaTimer
            // 
            this.LlegadaTimer.Interval = 500;
            this.LlegadaTimer.Tick += new System.EventHandler(this.LlegadaTimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TiempoLabel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TiempoTextBox);
            this.Controls.Add(this.CantidadMarcosTextBox);
            this.Name = "MainForm";
            this.Text = "Simulador";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox CantidadMarcosTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TiempoTextBox;
        private System.Windows.Forms.Timer CronometroTimer;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer Carpintero1Timer;
        private System.Windows.Forms.Timer Carpintero2Timer;
        private System.Windows.Forms.Timer Carpintero3Timer;
        private System.Windows.Forms.Timer Carpintero4Timer;
        private System.Windows.Forms.Timer Carpintero5Timer;
        private System.Windows.Forms.Label TiempoLabel;
        private System.Windows.Forms.Timer LlegadaTimer;
    }
}

