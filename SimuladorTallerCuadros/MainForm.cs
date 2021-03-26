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
        public Queue<int> HoraAlmacen = new Queue<int>();
        public Queue<int> MinutoAlmacen = new Queue<int>();

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
        public static int HoraLlegada = 0;

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

        public static int GruposMarcos = 0;
        public static int MarcosEnsamblados = 0;
        public static int MarcosEnAlmacen = 0;
        public static int MarcosSecados = 0;
        public static int MarcosPintados = 0;
        public static int MarcosRetrabajados = 0;
        public static int MarcosEmpacados = 0;
        public static int Duracion = 0;

        public bool MarcoPintado = false;
        public bool MarcoEmpacado = false;
        public int SuperarInspeccion = 0;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        public void DeterminarCantidadMarcos()
        {
            if (HoraLlegada == Hora)
            {
                int probabilidad = aleatorio.Next(1, 11);
                GruposMarcos = 0;
                if (probabilidad <= 6)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        Marcos++;
                        GruposMarcos++;
                        ColaDeLlegada.Enqueue(Marcos);
                    }
                }
                else
                {
                    for (int i = 0; i < 6; i++)
                    {
                        Marcos++;
                        GruposMarcos++;
                        ColaDeLlegada.Enqueue(Marcos);
                    }
                }
                HoraLlegada += 5;

                if (HoraLlegada >= 24)
                    HoraLlegada -= 24;

                CantidadMarcosEnsamblarTextBox.Text = "Grupo de " + GruposMarcos + " marcos";
                Ensamblar();            
            }
        }

        public void Ensamblar()
        { 
            if (ColaDeLlegada.Count == 4)
            {
                TiempoCarpintero2 = aleatorio.Next(2, 7);
                TiempoCarpintero3 = aleatorio.Next(2, 7);
                TiempoCarpintero4 = aleatorio.Next(2, 7);
                TiempoCarpintero5 = aleatorio.Next(2, 7);

                for (int i = 0; i < 4; i++)
                {
                    ColaDeEnsamblaje.Enqueue(ColaDeLlegada.Dequeue());
                }
            }
            else if (ColaDeLlegada.Count == 6)
            {
                TiempoCarpintero1 = aleatorio.Next(2, 7);
                TiempoCarpintero2 = aleatorio.Next(2, 7);
                TiempoCarpintero3 = aleatorio.Next(2, 7);
                TiempoCarpintero4 = aleatorio.Next(2, 7);
                TiempoCarpintero5 = aleatorio.Next(2, 7);

                for (int i = 0; i < 6; i++)
                {
                    ColaDeEnsamblaje.Enqueue(ColaDeLlegada.Dequeue());
                }
            }

            HorasC1Label.Text = TiempoCarpintero1.ToString();
            HorasC2Label.Text = TiempoCarpintero2.ToString();
            HorasC3Label.Text = TiempoCarpintero3.ToString();
            HorasC4Label.Text = TiempoCarpintero4.ToString();
            HorasC5Label.Text = TiempoCarpintero5.ToString();

            if (ColaDeEnsamblaje.Count == 4 || ColaDeEnsamblaje.Count == 6)
            {
                Carpintero5Timer.Enabled = true;
                Carpintero4Timer.Enabled = true;
                Carpintero3Timer.Enabled = true;
                Carpintero2Timer.Enabled = true;
                Carpintero1Timer.Enabled = true;
            }
        }

        private void Carpintero1Timer_Tick(object sender, EventArgs e)
        {
            if (ColaDeEnsamblaje.Count != 0)
            {
                if (Carpintero1Disponible == true)
                {
                    HoraInicioC1 = Hora;
                    HorasC1Label.Text = "0";
                    ColaDeAlmacen.Enqueue(ColaDeEnsamblaje.Dequeue());
                    Carpintero1Disponible = false;
                    C1NoDisponiblePictureBox.Visible = true;
                    Carpintero1PictureBox.Enabled = true;
                }

                if (TiempoCarpintero1 == 2)
                {
                    HorasC1Label.Text = "2";
                    if ((HoraInicioC1 + 2) == Hora)
                    {
                        C1NoDisponiblePictureBox.Visible = false;
                        Carpintero1PictureBox.Enabled = false;
                        Carpintero1Disponible = true;
                        MarcosEnsamblados++;
                        MarcosEnAlmacen++;
                        LlevarAlmacenPictureBox.Enabled = true;
                    }
                }

                if (TiempoCarpintero1 == 3)
                {
                    HorasC1Label.Text = "3";
                    if ((HoraInicioC1 + 3) == Hora)
                    {
                        C1NoDisponiblePictureBox.Visible = false;
                        Carpintero1PictureBox.Enabled = false;
                        Carpintero1Disponible = true;
                        MarcosEnsamblados++;
                        MarcosEnAlmacen++;
                        LlevarAlmacenPictureBox.Enabled = true;
                    }
                }

                if (TiempoCarpintero1 == 4)
                {
                    HorasC1Label.Text = "4";
                    if ((HoraInicioC1 + 4) == Hora)
                    {
                        C1NoDisponiblePictureBox.Visible = false;
                        Carpintero1PictureBox.Enabled = false;
                        Carpintero1Disponible = true;
                        MarcosEnsamblados++;
                        MarcosEnAlmacen++;
                        LlevarAlmacenPictureBox.Enabled = true;
                    }
                }

                if (TiempoCarpintero1 == 5)
                {
                    HorasC1Label.Text = "5";
                    if ((HoraInicioC1 + 5) == Hora)
                    {
                        C1NoDisponiblePictureBox.Visible = false;
                        Carpintero1PictureBox.Enabled = false;
                        Carpintero1Disponible = true;
                        MarcosEnsamblados++;
                        MarcosEnAlmacen++;
                        LlevarAlmacenPictureBox.Enabled = true;
                    }
                }

                if (TiempoCarpintero1 == 6)
                {
                    HorasC1Label.Text = "6";
                    if ((HoraInicioC1 + 5) == Hora)
                    {
                        C1NoDisponiblePictureBox.Visible = false;
                        Carpintero1PictureBox.Enabled = false;
                        Carpintero1Disponible = true;
                        MarcosEnsamblados++;
                        MarcosEnAlmacen++;
                        LlevarAlmacenPictureBox.Enabled = true;
                    }
                }

                CantidadMarcosEnsambladosTextBox.Text = MarcosEnsamblados.ToString();
                CantidadMarcosAlmacenTextBox.Text = MarcosEnsamblados.ToString();
            }
        }

        public void DeterminarTiempoSecado()
        {
            if (ColaDeAlmacen.Count != 0)
            {
                LlevarAlmacenPictureBox.Enabled = true;
                if(HoraAlmacen.Count != 0)
                {
                    if (HoraAlmacen.Peek() == Hora && MinutoAlmacen.Peek() == Minuto)
                    {
                        HoraAlmacen.Dequeue();
                        MinutoAlmacen.Dequeue();
                        ColaPintado.Enqueue(ColaDeAlmacen.Dequeue());
                        MarcosSecados++;
                    }
                }
                
                HoraAlmacen.Enqueue(Hora);
                MinutoAlmacen.Enqueue(Minuto);

                CantidadMarcosAlmacenTextBox.Text = MarcosEnAlmacen.ToString();
                CantidadMarcosSecadosTextBox.Text = MarcosSecados.ToString();
            }
        }

        public void PintarMarcos()
        {  
            if (ColaPintado.Count != 0)
            {
                MaquinaPinturaPictureBox.Enabled = true;
                SuperarInspeccion = aleatorio.Next(1, 11);

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
                        MarcosEnAlmacen--;
                        MarcoPintado = false;
                        MaquinaPinturaPictureBox.Enabled = false;
                        ColaEmpaque.Enqueue(ColaPintado.Dequeue());
                        TerminarPintado = 0;
                        MarcosProcesados++;
                        MarcosPintados++;
                    }
                }
                else
                {
                    ColaDeAlmacen.Enqueue(ColaPintado.Dequeue());
                    MarcosRetrabajados++;
                }

                if (MarcosProcesados == 20)
                {
                    PintarTimer.Enabled = false;
                    MantenimientoPictureBox.Visible = true;
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
                    MantenimientoPictureBox.Visible = false;
                    TerminarMantenimiento = 0;
                }

                CantidadMarcosAlmacenTextBox.Text = MarcosEnsamblados.ToString();
                CantidadMarcosPintadosTextBox.Text = MarcosPintados.ToString();
                CantidadMarcosRetrabajadosTextBox.Text = MarcosRetrabajados.ToString();
            }
        }

        public void EmpacarMarcos()
        {
            if (ColaEmpaque.Count != 0)
            {
                if (MarcoEmpacado == false)
                {
                    MaquinaEmpaquePictureBox.Enabled = true;
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
                    MaquinaEmpaquePictureBox.Enabled = false;
                    ColaEmpaque.Dequeue();
                    TerminarEmpaque = 0;
                    MarcosEmpacados++;
                }

                DuracionEmpaqueTextBox.Text = DuracionEmpaque.ToString();
                CantidadMarcosEmpacadosTextBox.Text = MarcosEmpacados.ToString();
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

            Carpintero1PictureBox.Enabled = false;
            Carpintero2PictureBox.Enabled = false;
            Carpintero3PictureBox.Enabled = false;
            Carpintero4PictureBox.Enabled = false;
            Carpintero5PictureBox.Enabled = false;

            MaquinaPinturaPictureBox.Enabled = false;
            MaquinaEmpaquePictureBox.Enabled = false;
            LlevarAlmacenPictureBox.Enabled = false;
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
                DiaLabel.Text = Dia.ToString();
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
            MaquinaPinturaPictureBox.Enabled = false;
        }

        private void ProcesosTimer_Tick(object sender, EventArgs e)
        {
            DeterminarTiempoSecado();
            EmpacarMarcos();
        }

        private void Carpintero2Timer_Tick(object sender, EventArgs e)
        {
            if(ColaDeEnsamblaje.Count != 0)
            {
                if (Carpintero2Disponible == true)
                {
                    HoraInicioC2 = Hora;
                    HorasC2Label.Text = "0";
                    ColaDeAlmacen.Enqueue(ColaDeEnsamblaje.Dequeue());
                    Carpintero2Disponible = false;
                    C2NoDisponiblePictureBox.Visible = true;
                    Carpintero2PictureBox.Enabled = true;
                    LlevarAlmacenPictureBox.Enabled = true;
                }

                if (TiempoCarpintero2 == 2)
                {
                    HorasC2Label.Text = "2";
                    if ((HoraInicioC2 + 2) == Hora)
                    {
                        C2NoDisponiblePictureBox.Visible = false;
                        Carpintero2PictureBox.Enabled = false;
                        Carpintero2Disponible = true;
                        MarcosEnsamblados++;
                        MarcosEnAlmacen++;
                        LlevarAlmacenPictureBox.Enabled = true;
                    }
                }

                if (TiempoCarpintero2 == 3)
                {
                    HorasC2Label.Text = "3";
                    if ((HoraInicioC2 + 3) == Hora)
                    {
                        C2NoDisponiblePictureBox.Visible = false;
                        Carpintero2PictureBox.Enabled = false;
                        Carpintero2Disponible = true;
                        MarcosEnsamblados++;
                        MarcosEnAlmacen++;
                        LlevarAlmacenPictureBox.Enabled = true;
                    }
                }

                if (TiempoCarpintero2 == 4)
                {
                    HorasC2Label.Text = "4";
                    if ((HoraInicioC2 + 4) == Hora)
                    {
                        C2NoDisponiblePictureBox.Visible = false;
                        Carpintero2PictureBox.Enabled = false;
                        Carpintero2Disponible = true;
                        MarcosEnsamblados++;
                        MarcosEnAlmacen++;
                        LlevarAlmacenPictureBox.Enabled = true;
                    }
                }

                if (TiempoCarpintero2 == 5)
                {
                    HorasC2Label.Text = "5";
                    if ((HoraInicioC2 + 5) == Hora)
                    {
                        C2NoDisponiblePictureBox.Visible = false;
                        Carpintero2PictureBox.Enabled = false;
                        Carpintero2Disponible = true;
                        MarcosEnsamblados++;
                        MarcosEnAlmacen++;
                        LlevarAlmacenPictureBox.Enabled = true;
                    }
                }

                if (TiempoCarpintero2 == 6)
                {
                    HorasC2Label.Text = "6";
                    if ((HoraInicioC2 + 6) == Hora)
                    {
                        C2NoDisponiblePictureBox.Visible = false;
                        Carpintero2PictureBox.Enabled = false;
                        Carpintero2Disponible = true;
                        MarcosEnsamblados++;
                        MarcosEnAlmacen++;
                        LlevarAlmacenPictureBox.Enabled = true;
                    }
                }

                CantidadMarcosEnsambladosTextBox.Text = MarcosEnsamblados.ToString();
                CantidadMarcosAlmacenTextBox.Text = MarcosEnsamblados.ToString();
            }
        }

        private void Carpintero3Timer_Tick(object sender, EventArgs e)
        {
            if (ColaDeEnsamblaje.Count != 0)
            {
                if (Carpintero3Disponible == true)
                {
                    HoraInicioC3 = Hora;
                    HorasC3Label.Text = "0";
                    ColaDeAlmacen.Enqueue(ColaDeEnsamblaje.Dequeue());
                    Carpintero3Disponible = false;
                    C3NoDisponiblePictureBox.Visible = true;
                    Carpintero3PictureBox.Enabled = true;
                }

                if (TiempoCarpintero3 == 2)
                {
                    HorasC3Label.Text = "2";
                    if ((HoraInicioC3 + 2) == Hora)
                    {
                        C3NoDisponiblePictureBox.Visible = false;
                        Carpintero3PictureBox.Enabled = false;
                        Carpintero3Disponible = true;
                        MarcosEnsamblados++;
                        MarcosEnAlmacen++;
                        LlevarAlmacenPictureBox.Enabled = true;
                    }
                }

                if (TiempoCarpintero3 == 3)
                {
                    HorasC3Label.Text = "3";
                    if ((HoraInicioC3 + 3) == Hora)
                    {
                        C3NoDisponiblePictureBox.Visible = false;
                        Carpintero3PictureBox.Enabled = false;
                        Carpintero3Disponible = true;
                        MarcosEnsamblados++;
                        MarcosEnAlmacen++;
                        LlevarAlmacenPictureBox.Enabled = true;
                    }
                }

                if (TiempoCarpintero3 == 4)
                {
                    HorasC3Label.Text = "4";
                    if ((HoraInicioC3 + 4) == Hora)
                    {
                        C3NoDisponiblePictureBox.Visible = false;
                        Carpintero3PictureBox.Enabled = false;
                        Carpintero3Disponible = true;
                        MarcosEnsamblados++;
                        MarcosEnAlmacen++;
                        LlevarAlmacenPictureBox.Enabled = true;
                    }
                }

                if (TiempoCarpintero3 == 5)
                {
                    HorasC3Label.Text = "5";
                    if ((HoraInicioC3 + 5) == Hora)
                    {
                        C3NoDisponiblePictureBox.Visible = false;
                        Carpintero3PictureBox.Enabled = false;
                        Carpintero3Disponible = true;
                        MarcosEnsamblados++;
                        MarcosEnAlmacen++;
                        LlevarAlmacenPictureBox.Enabled = true;
                    }
                }

                if (TiempoCarpintero3 == 6)
                {
                    HorasC3Label.Text = "6";
                    if ((HoraInicioC3 + 6) == Hora)
                    {
                        C3NoDisponiblePictureBox.Visible = false;
                        Carpintero3PictureBox.Enabled = false;
                        Carpintero3Disponible = true;
                        MarcosEnsamblados++;
                        MarcosEnAlmacen++;
                        LlevarAlmacenPictureBox.Enabled = true;
                    }
                }

                CantidadMarcosEnsambladosTextBox.Text = MarcosEnsamblados.ToString();
                CantidadMarcosAlmacenTextBox.Text = MarcosEnsamblados.ToString();
            }
        }

        private void Carpintero4Timer_Tick(object sender, EventArgs e)
        {
            if (ColaDeEnsamblaje.Count != 0)
            {
                if (Carpintero4Disponible == true)
                {
                    HoraInicioC4 = Hora;
                    HorasC4Label.Text = "0";
                    ColaDeAlmacen.Enqueue(ColaDeEnsamblaje.Dequeue());
                    Carpintero4Disponible = false;
                    C4NoDisponiblePictureBox.Visible = true;
                    Carpintero4PictureBox.Enabled = true;
                    LlevarAlmacenPictureBox.Enabled = true;
                }

                if (TiempoCarpintero4 == 2)
                {
                    HorasC4Label.Text = "2";
                    if ((HoraInicioC4 + 2) == Hora)
                    {
                        C4NoDisponiblePictureBox.Visible = false;
                        Carpintero4PictureBox.Enabled = false;
                        Carpintero4Disponible = true;
                        MarcosEnsamblados++;
                        MarcosEnAlmacen++;
                        LlevarAlmacenPictureBox.Enabled = true;
                    }
                }

                if (TiempoCarpintero4 == 3)
                {
                    HorasC4Label.Text = "3";
                    if ((HoraInicioC4 + 3) == Hora)
                    {
                        C4NoDisponiblePictureBox.Visible = false;
                        Carpintero4PictureBox.Enabled = false;
                        Carpintero4Disponible = true;
                        MarcosEnsamblados++;
                        MarcosEnAlmacen++;
                        LlevarAlmacenPictureBox.Enabled = true;
                    }
                }

                if (TiempoCarpintero4 == 4)
                {
                    HorasC4Label.Text = "4";
                    if ((HoraInicioC4 + 4) == Hora)
                    {
                        C4NoDisponiblePictureBox.Visible = false;
                        Carpintero4PictureBox.Enabled = false;
                        Carpintero4Disponible = true;
                        MarcosEnsamblados++;
                        MarcosEnAlmacen++;
                        LlevarAlmacenPictureBox.Enabled = true;
                    }
                }

                if (TiempoCarpintero4 == 5)
                {
                    HorasC4Label.Text = "5";
                    if ((HoraInicioC4 + 5) == Hora)
                    {
                        C4NoDisponiblePictureBox.Visible = false;
                        Carpintero4PictureBox.Enabled = false;
                        Carpintero4Disponible = true;
                        MarcosEnsamblados++;
                        MarcosEnAlmacen++;
                        LlevarAlmacenPictureBox.Enabled = true;
                    }
                }

                if (TiempoCarpintero4 == 6)
                {
                    HorasC4Label.Text = "6";
                    if ((HoraInicioC4 + 6) == Hora)
                    {
                        C4NoDisponiblePictureBox.Visible = false;
                        Carpintero4PictureBox.Enabled = false;
                        Carpintero4Disponible = true;
                        MarcosEnsamblados++;
                        MarcosEnAlmacen++;
                        LlevarAlmacenPictureBox.Enabled = true;
                    }
                }

                CantidadMarcosEnsambladosTextBox.Text = MarcosEnsamblados.ToString();
                CantidadMarcosAlmacenTextBox.Text = MarcosEnsamblados.ToString();
            }
        }

        private void Carpintero5Timer_Tick(object sender, EventArgs e)
        {
            if (ColaDeEnsamblaje.Count != 0)
            {
                if (Carpintero5Disponible == true)
                {
                    HoraInicioC5 = Hora;
                    HorasC5Label.Text = "0";
                    ColaDeAlmacen.Enqueue(ColaDeEnsamblaje.Dequeue());
                    Carpintero5Disponible = false;
                    C5NoDisponiblePictureBox.Visible = true;
                    Carpintero5PictureBox.Enabled = true;
                }

                if (TiempoCarpintero5 == 2)
                {
                    HorasC5Label.Text = "2";
                    if ((HoraInicioC5 + 2) == Hora)
                    {
                        C5NoDisponiblePictureBox.Visible = false;
                        Carpintero5PictureBox.Enabled = false;
                        Carpintero5Disponible = true;
                        MarcosEnsamblados++;
                        MarcosEnAlmacen++;
                        LlevarAlmacenPictureBox.Enabled = true;
                    }
                }

                if (TiempoCarpintero5 == 3)
                {
                    HorasC5Label.Text = "3";
                    if ((HoraInicioC5 + 3) == Hora)
                    {
                        C5NoDisponiblePictureBox.Visible = false;
                        Carpintero5PictureBox.Enabled = false;
                        Carpintero5Disponible = true;
                        MarcosEnsamblados++;
                        MarcosEnAlmacen++;
                        LlevarAlmacenPictureBox.Enabled = true;
                    }
                }

                if (TiempoCarpintero5 == 4)
                {
                    HorasC5Label.Text = "4";
                    if ((HoraInicioC5 + 4) == Hora)
                    {
                        C5NoDisponiblePictureBox.Visible = false;
                        Carpintero5PictureBox.Enabled = false;
                        Carpintero5Disponible = true;
                        MarcosEnsamblados++;
                        MarcosEnAlmacen++;
                        LlevarAlmacenPictureBox.Enabled = true;
                    }
                }

                if (TiempoCarpintero5 == 5)
                {
                    HorasC5Label.Text = "5";
                    if ((HoraInicioC5 + 5) == Hora)
                    {
                        C5NoDisponiblePictureBox.Visible = false;
                        Carpintero5PictureBox.Enabled = false;
                        Carpintero5Disponible = true;
                        MarcosEnsamblados++;
                        MarcosEnAlmacen++;
                        LlevarAlmacenPictureBox.Enabled = true;
                    }
                }

                if (TiempoCarpintero5 == 6)
                {
                    HorasC5Label.Text = "6";
                    if ((HoraInicioC5 + 6) == Hora)
                    {
                        C5NoDisponiblePictureBox.Visible = false;
                        Carpintero5PictureBox.Enabled = false;
                        Carpintero5Disponible = true;
                        MarcosEnsamblados++;
                        MarcosEnAlmacen++;
                        LlevarAlmacenPictureBox.Enabled = true;
                    }
                }

                CantidadMarcosEnsambladosTextBox.Text = MarcosEnsamblados.ToString();
                CantidadMarcosAlmacenTextBox.Text = MarcosEnsamblados.ToString();
            }
        }

    }
}
