using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimuladorTallerCuadros
{
    public partial class MainForm : Form
    {
        public static int Marcos { get; set; } = 0;
        public static Random aleatorio = new Random();

        public Queue<int> ColaDeLlegada = new Queue<int>();
        public Queue<int> ColaDeEnsamblaje = new Queue<int>();

        public bool Carpintero1Disponible = true;
        public bool Carpintero2Disponible = true;
        public bool Carpintero3Disponible = true;
        public bool Carpintero4Disponible = true;
        public bool Carpintero5Disponible = true;

        public int TiempoCarpintero1;
        public int TiempoCarpintero2;
        public int TiempoCarpintero3;
        public int TiempoCarpintero4;
        public int TiempoCarpintero5;

        public static int hora = 0;
        public static int minuto = 0;
        public static int segundo = 0;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        public void DeterminarCantidadMarcos()
        {
            int probabilidad = aleatorio.Next(1, 11);
            
            if(probabilidad <= 6)
            {
                for (int i = 0; i < 4; i++)
                {
                    Marcos++;
                    ColaDeLlegada.Enqueue(Marcos);
                }
            }
            else
            {
                for (int i = 0; i < 6; i++)
                {
                    Marcos++;
                    ColaDeLlegada.Enqueue(Marcos);
                }
            }

            Ensamblar();
        }

        public void Ensamblar()
        {
            ColaDeEnsamblaje.Enqueue(ColaDeLlegada.Dequeue());

            TiempoCarpintero1 = aleatorio.Next(2, 7);
            TiempoCarpintero2 = aleatorio.Next(2, 7);
            TiempoCarpintero3 = aleatorio.Next(2, 7);
            TiempoCarpintero4 = aleatorio.Next(2, 7);
            TiempoCarpintero5 = aleatorio.Next(2, 7);


        }

        private void CronometroTimer_Tick(object sender, EventArgs e)
        {
            minuto++;

            if (minuto == 60)
            {
                hora++;
                minuto = 0;
            }

            if (hora == 24)
            {
                hora = 0;
            }

            if (hora > 9 && minuto > 9)
                TiempoLabel.Text = hora + ":" + minuto;

            if (hora > 9 && minuto < 9)
                TiempoLabel.Text = hora + ":0" + minuto;

            if (minuto > 9 && (hora >= 0 && hora <= 9))
                TiempoLabel.Text = "0" + hora + ":" + minuto;

            if ((minuto >= 0 && minuto <= 9) && (hora >= 0 && hora <= 9))
                TiempoLabel.Text = "0" + hora + ":" + "0" + minuto;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CronometroTimer.Enabled = !CronometroTimer.Enabled;
            LlegadaTimer.Enabled = !LlegadaTimer.Enabled;
        }

        private void Carpintero1Timer_Tick(object sender, EventArgs e)
        {
            if(Carpintero1Disponible == true)
            {
                ColaDeEnsamblaje.Dequeue();
            }

            if (TiempoCarpintero1 == 2)
            {

            }
        }

        private void LlegadaTimer_Tick(object sender, EventArgs e)
        {
            DeterminarCantidadMarcos();
        }

        private void Carpintero2Timer_Tick(object sender, EventArgs e)
        {

        }

        private void Carpintero3Timer_Tick(object sender, EventArgs e)
        {

        }

        private void Carpintero4Timer_Tick(object sender, EventArgs e)
        {

        }

        private void Carpintero5Timer_Tick(object sender, EventArgs e)
        {

        }

    }
}
