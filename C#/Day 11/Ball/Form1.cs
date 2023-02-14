using Timer = System.Windows.Forms.Timer;

namespace Ball
{
    public partial class Form1 : Form
    {
        Graphics g;
        Timer Timer1= new Timer();
        int posX = 0;
        int dx = 50;
        public Form1()
        {
            InitializeComponent();
            g = CreateGraphics();
            Timer1.Interval = 100;
            Timer1.Enabled = true;
            Timer1.Tick += Timer1_Tick;

            
        }


        private void Timer1_Tick(object? sender, EventArgs e)
        {
            posX += dx;

            if (posX + 200 >= 650)
            {
                posX = 650 - 200;
                dx = -dx;
            } else if (posX < 60)
            {
                posX = 60;
                dx = -dx;
            }
            
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);


            e.Graphics.DrawEllipse(Pens.Black, new(10, 0, 100, 100));
            e.Graphics.DrawLine(Pens.Black, new(60, 100), new(60, 350));
            e.Graphics.DrawLine(Pens.Black, new(60, 150), new(30, 180));
            e.Graphics.DrawLine(Pens.Black, new(60, 150), new(90, 180));
            e.Graphics.DrawLine(Pens.Black, new(60, 350), new(30, 380));
            e.Graphics.DrawLine(Pens.Black, new(60, 350), new(90, 380));

            e.Graphics.DrawEllipse(Pens.Black, new(600, 0, 100, 100));
            e.Graphics.DrawLine(Pens.Black, new(650, 100), new(650, 350));
            e.Graphics.DrawLine(Pens.Black, new(650, 150), new(620, 180));
            e.Graphics.DrawLine(Pens.Black, new(650, 150), new(680, 180));
            e.Graphics.DrawLine(Pens.Black, new(650, 350), new(620, 380));
            e.Graphics.DrawLine(Pens.Black, new(650, 350), new(680, 380));

            g.DrawEllipse(new Pen(Color.Black), posX, 100, 200, 200);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}