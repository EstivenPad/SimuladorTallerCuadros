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
            this.Carpintero1Timer = new System.Windows.Forms.Timer(this.components);
            this.Carpintero2Timer = new System.Windows.Forms.Timer(this.components);
            this.Carpintero3Timer = new System.Windows.Forms.Timer(this.components);
            this.Carpintero4Timer = new System.Windows.Forms.Timer(this.components);
            this.Carpintero5Timer = new System.Windows.Forms.Timer(this.components);
            this.TiempoLabel = new System.Windows.Forms.Label();
            this.LlegadaTimer = new System.Windows.Forms.Timer(this.components);
            this.ProcesosTimer = new System.Windows.Forms.Timer(this.components);
            this.IniciarButton = new System.Windows.Forms.Button();
            this.PintarTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // CantidadMarcosTextBox
            // 
            this.CantidadMarcosTextBox.Location = new System.Drawing.Point(616, 192);
            this.CantidadMarcosTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.CantidadMarcosTextBox.Name = "CantidadMarcosTextBox";
            this.CantidadMarcosTextBox.Size = new System.Drawing.Size(265, 22);
            this.CantidadMarcosTextBox.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(612, 134);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Cantidad de Marcos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(113, 134);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tiempo";
            // 
            // TiempoTextBox
            // 
            this.TiempoTextBox.Location = new System.Drawing.Point(117, 192);
            this.TiempoTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.TiempoTextBox.Name = "TiempoTextBox";
            this.TiempoTextBox.Size = new System.Drawing.Size(265, 22);
            this.TiempoTextBox.TabIndex = 1;
            // 
            // CronometroTimer
            // 
            this.CronometroTimer.Interval = 50;
            this.CronometroTimer.Tick += new System.EventHandler(this.CronometroTimer_Tick);
            // 
            // Carpintero1Timer
            // 
            this.Carpintero1Timer.Interval = 50;
            this.Carpintero1Timer.Tick += new System.EventHandler(this.Carpintero1Timer_Tick);
            // 
            // Carpintero2Timer
            // 
            this.Carpintero2Timer.Interval = 50;
            this.Carpintero2Timer.Tick += new System.EventHandler(this.Carpintero2Timer_Tick);
            // 
            // Carpintero3Timer
            // 
            this.Carpintero3Timer.Interval = 50;
            this.Carpintero3Timer.Tick += new System.EventHandler(this.Carpintero3Timer_Tick);
            // 
            // Carpintero4Timer
            // 
            this.Carpintero4Timer.Interval = 50;
            this.Carpintero4Timer.Tick += new System.EventHandler(this.Carpintero4Timer_Tick);
            // 
            // Carpintero5Timer
            // 
            this.Carpintero5Timer.Interval = 50;
            this.Carpintero5Timer.Tick += new System.EventHandler(this.Carpintero5Timer_Tick);
            // 
            // TiempoLabel
            // 
            this.TiempoLabel.AutoSize = true;
            this.TiempoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TiempoLabel.Location = new System.Drawing.Point(448, 192);
            this.TiempoLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TiempoLabel.Name = "TiempoLabel";
            this.TiempoLabel.Size = new System.Drawing.Size(67, 25);
            this.TiempoLabel.TabIndex = 5;
            this.TiempoLabel.Text = "00:00";
            // 
            // LlegadaTimer
            // 
            this.LlegadaTimer.Interval = 50;
            this.LlegadaTimer.Tick += new System.EventHandler(this.LlegadaTimer_Tick);
            // 
            // ProcesosTimer
            // 
            this.ProcesosTimer.Interval = 50;
            this.ProcesosTimer.Tick += new System.EventHandler(this.ProcesosTimer_Tick);
            // 
            // IniciarButton
            // 
            this.IniciarButton.Location = new System.Drawing.Point(494, 319);
            this.IniciarButton.Name = "IniciarButton";
            this.IniciarButton.Size = new System.Drawing.Size(75, 35);
            this.IniciarButton.TabIndex = 6;
            this.IniciarButton.Text = "button1";
            this.IniciarButton.UseVisualStyleBackColor = true;
            this.IniciarButton.Click += new System.EventHandler(this.IniciarButton_Click);
            // 
            // PintarTimer
            // 
            this.PintarTimer.Interval = 50;
            this.PintarTimer.Tick += new System.EventHandler(this.PintarTimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.IniciarButton);
            this.Controls.Add(this.TiempoLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TiempoTextBox);
            this.Controls.Add(this.CantidadMarcosTextBox);
            this.Margin = new System.Windows.Forms.Padding(4);
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
        private System.Windows.Forms.Timer Carpintero1Timer;
        private System.Windows.Forms.Timer Carpintero2Timer;
        private System.Windows.Forms.Timer Carpintero3Timer;
        private System.Windows.Forms.Timer Carpintero4Timer;
        private System.Windows.Forms.Timer Carpintero5Timer;
        private System.Windows.Forms.Label TiempoLabel;
        private System.Windows.Forms.Timer LlegadaTimer;
        private System.Windows.Forms.Timer ProcesosTimer;
        private System.Windows.Forms.Button IniciarButton;
        private System.Windows.Forms.Timer PintarTimer;
    }
}

