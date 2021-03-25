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
        public Queue<int> ColaDeAlmacen = new Queue<int>();
        public Queue<int> ColaPintado = new Queue<int>();
        public Queue<int> ColaEmpaque = new Queue<int>();

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

        public int HoraInicioC1;
        public int HoraInicioC2;
        public int HoraInicioC3;
        public int HoraInicioC4;
        public int HoraInicioC5;

        public static int Dia = 0;
        public static int Hora = 0;
        public static int Minuto = 0;

        public static int InicioPintado = 0;
        public static int DuracionPintado = 0;
        public static int TerminarPintado = 0;

        public static int InicioEmpaque = 0;
        public static int DuracionEmpaque = 0;
        public static int TerminarEmpaque = 0;

        public static int InicioMantenimiento = 0;
        public static int DuracionMantenimiento = 0;
        public static int TerminarMantenimiento = 0;

        public static int MarcosProcesados = 0;

        public bool MarcoPintado = false;
        public bool MarcoEmpacado = false;

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
            LlegadaTimer.Interval = 15000;
        }

        public void Ensamblar()
        {
            ColaDeEnsamblaje.Enqueue(ColaDeLlegada.Dequeue());

            TiempoCarpintero1 = aleatorio.Next(2, 7);
            TiempoCarpintero2 = aleatorio.Next(2, 7);
            TiempoCarpintero3 = aleatorio.Next(2, 7);
            TiempoCarpintero4 = aleatorio.Next(2, 7);
            TiempoCarpintero5 = aleatorio.Next(2, 7);

            if(Carpintero1Timer.Enabled == false)
            {
                Carpintero1Timer.Enabled = true;
                Carpintero2Timer.Enabled = true;
                Carpintero3Timer.Enabled = true;
                Carpintero4Timer.Enabled = true;
                Carpintero5Timer.Enabled = true;
            }
        }

        public void SecarMarcosEnAlmacen()
        {
            if(Hora == 23 && Minuto == 58)
            {
                if (ColaDeAlmacen.Count != 0)
                {
                    foreach (var item in ColaDeAlmacen)
                    {
                        ColaPintado.Enqueue(ColaDeAlmacen.Dequeue());
                    }
                }
            }
        }

        public void PintarMarcos()
        {  
            if (ColaPintado.Count != 0)
            {
                int SuperarInspeccion = aleatorio.Next(1, 11);

                if (MarcoPintado == false)
                {
                    InicioPintado = Minuto;
                    DuracionPintado = aleatorio.Next(10, 21);
                    TerminarPintado = InicioPintado + DuracionPintado;

                    MarcoPintado = true;
                }

                if (SuperarInspeccion <= 9)
                {
                    if (TerminarPintado > 60)
                        TerminarPintado -= 60;

                    if (TerminarPintado == Minuto)//Si se termino de pintar
                    {
                        MarcoPintado = false;
                        ColaEmpaque.Enqueue(ColaPintado.Dequeue());
                        TerminarPintado = 0;
                        MarcosProcesados++;
                    }
                }
                else
                    ColaDeAlmacen.Enqueue(ColaPintado.Dequeue());

                if (MarcosProcesados == 20)
                {
                    PintarTimer.Enabled = false;
                    int aux = aleatorio.Next(1, 4);

                    if (aux == 1)
                    {
                        InicioMantenimiento = Minuto;
                        TerminarMantenimiento = InicioMantenimiento + 30;
                    }
                    else if (aux == 2)
                    {
                        InicioMantenimiento = Minuto;
                        TerminarMantenimiento = InicioMantenimiento + 45;
                    }
                    else if (aux == 3)
                    {
                        InicioMantenimiento = Minuto;
                        TerminarMantenimiento = InicioMantenimiento + 60;
                    }
                    MarcosProcesados = 0;
                }

                if (TerminarMantenimiento > 60)
                    TerminarMantenimiento -= 60;

                if (TerminarMantenimiento == Minuto)
                {
                    PintarTimer.Enabled = true;
                    TerminarMantenimiento = 0;
                }
            }
        }

        public void EmpacarMarcos()
        {
            if (ColaEmpaque.Count != 0)
            {
                if (MarcoEmpacado == false)
                {
                    InicioEmpaque = Minuto;
                    DuracionEmpaque = aleatorio.Next(10, 16);
                    TerminarEmpaque = InicioEmpaque + DuracionEmpaque;

                    MarcoEmpacado = true;
                }

                if (TerminarEmpaque > 60)
                    TerminarEmpaque -= 60;

                if (TerminarEmpaque == Minuto)//Si se termino de pintar
                {
                    MarcoEmpacado = false;
                    ColaEmpaque.Dequeue();
                    TerminarEmpaque = 0;
                }
            }
        }

        private void IniciarButton_Click(object sender, EventArgs e)
        {
            CronometroTimer.Enabled = !CronometroTimer.Enabled;
            LlegadaTimer.Enabled = !LlegadaTimer.Enabled;
            PintarTimer.Enabled = !PintarTimer.Enabled;
            ProcesosTimer.Enabled = !ProcesosTimer.Enabled;
            Carpintero1Timer.Enabled = !Carpintero1Timer.Enabled;
            Carpintero2Timer.Enabled = !Carpintero2Timer.Enabled;
            Carpintero3Timer.Enabled = !Carpintero3Timer.Enabled;
            Carpintero4Timer.Enabled = !Carpintero4Timer.Enabled;
            Carpintero5Timer.Enabled = !Carpintero5Timer.Enabled;
        }

        /*----------------------------------- TIMERS -----------------------------------*/
        private void CronometroTimer_Tick(object sender, EventArgs e)
        {
            Minuto++;

            if (Minuto == 60)
            {
                Hora++;
                Minuto = 0;
            }

            if (Hora == 24)
            {
                Dia++;
                Hora = 0;
            }

            if (Hora > 9 && Minuto > 9)
                TiempoLabel.Text = Hora + ":" + Minuto;

            if (Hora > 9 && Minuto < 9)
                TiempoLabel.Text = Hora + ":0" + Minuto;

            if (Minuto > 9 && (Hora >= 0 && Hora <= 9))
                TiempoLabel.Text = "0" + Hora + ":" + Minuto;

            if ((Minuto >= 0 && Minuto <= 9) && (Hora >= 0 && Hora <= 9))
                TiempoLabel.Text = "0" + Hora + ":" + "0" + Minuto;

            if (Dia == 417)//Termina el programa
            {
                CronometroTimer.Enabled = false;
                LlegadaTimer.Enabled = false;
                ProcesosTimer.Enabled = false;
                PintarTimer.Enabled = false;
                Carpintero1Timer.Enabled = false;
                Carpintero2Timer.Enabled = false;
                Carpintero3Timer.Enabled = false;
                Carpintero4Timer.Enabled = false;
                Carpintero5Timer.Enabled = false;
            }
        }

        private void LlegadaTimer_Tick(object sender, EventArgs e)
        {
            DeterminarCantidadMarcos();
        }

        private void PintarTimer_Tick(object sender, EventArgs e)
        {
            PintarMarcos();
        }

        private void ProcesosTimer_Tick(object sender, EventArgs e)
        {
            SecarMarcosEnAlmacen();
            EmpacarMarcos();
        }

        private void Carpintero1Timer_Tick(object sender, EventArgs e)
        {
            if(ColaDeEnsamblaje.Count != 0)
            {
                if (Carpintero1Disponible == true)
                {
                    HoraInicioC1 = Hora;
                    ColaDeAlmacen.Enqueue(ColaDeEnsamblaje.Dequeue());
                    Carpintero1Disponible = false;
                }

                if (TiempoCarpintero1 == 2)
                {
                    if ((HoraInicioC1 + 2) == Hora)
                        Carpintero1Disponible = true;
                }

                if (TiempoCarpintero1 == 3)
                {
                    if ((HoraInicioC1 + 3) == Hora)
                        Carpintero1Disponible = true;
                }

                if (TiempoCarpintero1 == 4)
                {
                    if ((HoraInicioC1 + 4) == Hora)
                        Carpintero1Disponible = true;
                }

                if (TiempoCarpintero1 == 5)
                {
                    if ((HoraInicioC1 + 5) == Hora)
                        Carpintero1Disponible = true;
                }

                if (TiempoCarpintero1 == 6)
                {
                    if ((HoraInicioC1 + 6) == Hora)
                        Carpintero1Disponible = true;
                }
            }
        }

        private void Carpintero2Timer_Tick(object sender, EventArgs e)
        {
            if(ColaDeEnsamblaje.Count != 0)
            {
                if (Carpintero2Disponible == true)
                {
                    HoraInicioC2 = Hora;
                    ColaDeAlmacen.Enqueue(ColaDeEnsamblaje.Dequeue());
                    Carpintero2Disponible = false;
                }

                if (TiempoCarpintero2 == 2)
                {
                    if ((HoraInicioC2 + 2) == Hora)
                        Carpintero1Disponible = true;
                }

                if (TiempoCarpintero2 == 3)
                {
                    if ((HoraInicioC2 + 3) == Hora)
                        Carpintero1Disponible = true;
                }

                if (TiempoCarpintero2 == 4)
                {
                    if ((HoraInicioC2 + 4) == Hora)
                        Carpintero1Disponible = true;
                }

                if (TiempoCarpintero2 == 5)
                {
                    if ((HoraInicioC2 + 5) == Hora)
                        Carpintero1Disponible = true;
                }

                if (TiempoCarpintero2 == 6)
                {
                    if ((HoraInicioC2 + 6) == Hora)
                        Carpintero1Disponible = true;
                }
            }
        }

        private void Carpintero3Timer_Tick(object sender, EventArgs e)
        {
            if (ColaDeEnsamblaje.Count != 0)
            {
                if (Carpintero3Disponible == true)
                {
                    HoraInicioC3 = Hora;
                    ColaDeAlmacen.Enqueue(ColaDeEnsamblaje.Dequeue());
                    Carpintero3Disponible = false;
                }

                if (TiempoCarpintero3 == 2)
                {
                    if ((HoraInicioC3 + 2) == Hora)
                        Carpintero1Disponible = true;
                }

                if (TiempoCarpintero3 == 3)
                {
                    if ((HoraInicioC3 + 3) == Hora)
                        Carpintero1Disponible = true;
                }

                if (TiempoCarpintero3 == 4)
                {
                    if ((HoraInicioC3 + 4) == Hora)
                        Carpintero1Disponible = true;
                }

                if (TiempoCarpintero3 == 5)
                {
                    if ((HoraInicioC3 + 5) == Hora)
                        Carpintero1Disponible = true;
                }

                if (TiempoCarpintero3 == 6)
                {
                    if ((HoraInicioC3 + 6) == Hora)
                        Carpintero1Disponible = true;
                }
            }
        }

        private void Carpintero4Timer_Tick(object sender, EventArgs e)
        {
            if (ColaDeEnsamblaje.Count != 0)
            {
                if (Carpintero4Disponible == true)
                {
                    HoraInicioC4 = Hora;
                    ColaDeAlmacen.Enqueue(ColaDeEnsamblaje.Dequeue());
                    Carpintero4Disponible = false;
                }

                if (TiempoCarpintero4 == 2)
                {
                    if ((HoraInicioC4 + 2) == Hora)
                        Carpintero1Disponible = true;
                }

                if (TiempoCarpintero4 == 3)
                {
                    if ((HoraInicioC4 + 3) == Hora)
                        Carpintero1Disponible = true;
                }

                if (TiempoCarpintero4 == 4)
                {
                    if ((HoraInicioC4 + 4) == Hora)
                        Carpintero1Disponible = true;
                }

                if (TiempoCarpintero4 == 5)
                {
                    if ((HoraInicioC4 + 5) == Hora)
                        Carpintero1Disponible = true;
                }

                if (TiempoCarpintero4 == 6)
                {
                    if ((HoraInicioC4 + 6) == Hora)
                        Carpintero1Disponible = true;
                }
            }
        }

        private void Carpintero5Timer_Tick(object sender, EventArgs e)
        {
            if (ColaDeEnsamblaje.Count != 0)
            {
                if (Carpintero5Disponible == true)
                {
                    HoraInicioC5 = Hora;
                    ColaDeAlmacen.Enqueue(ColaDeEnsamblaje.Dequeue());
                    Carpintero5Disponible = false;
                }

                if (TiempoCarpintero5 == 2)
                {
                    if ((HoraInicioC5 + 2) == Hora)
                        Carpintero1Disponible = true;
                }

                if (TiempoCarpintero5 == 3)
                {
                    if ((HoraInicioC5 + 3) == Hora)
                        Carpintero1Disponible = true;
                }

                if (TiempoCarpintero5 == 4)
                {
                    if ((HoraInicioC5 + 4) == Hora)
                        Carpintero1Disponible = true;
                }

                if (TiempoCarpintero5 == 5)
                {
                    if ((HoraInicioC5 + 5) == Hora)
                        Carpintero1Disponible = true;
                }

                if (TiempoCarpintero5 == 6)
                {
                    if ((HoraInicioC5 + 6) == Hora)
                        Carpintero1Disponible = true;
                }
            }
        }

    }
}
