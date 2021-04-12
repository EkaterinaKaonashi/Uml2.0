using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using Uml2._0.Arrows;
using Uml2.Arrows;


namespace Uml2.Arrows
{
    public partial class Form1 : Form
    {
        Bitmap _mainBitmap;
        Bitmap _tmpBitmap;
        Graphics _graphics;
        bool isClicked = false;
        Point start;
        Point cur;
        static Pen pen = new Pen(Color.Black, 3);
        static Pen pen1 = new Pen(Color.Red, 3); // почему тут нужен статик, без него не передается 

        string action = "";

        AssociationArrow associationArrow;
        InheritanceArrow inheritanceArrow;
        AddictionArrow addictionArrow;
        RealizationArrow realizationArrow;
        AggregationArrow aggregationArrow;


        public Form1()
        {
            InitializeComponent();
        }


        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isClicked)
            {

                cur = new Point(e.X, e.Y);

                _tmpBitmap = (Bitmap)_mainBitmap.Clone();
                _graphics = Graphics.FromImage(_tmpBitmap);



                //_graphics.DrawLine(pen, start, cur);
                //pen1.DashStyle = DashStyle.Dash;
                switch (action)
                {
                    case "inheritanceArrow":
                        inheritanceArrow.Draw(cur, start, isClicked, _graphics, pen);
                        break;
                    case "associationArrow":
                        associationArrow.Draw(cur, start, isClicked, _graphics, pen);
                        break;
                    case "addictionArrow":
                        addictionArrow.Draw(cur, start, isClicked, _graphics, pen);
                        break;
                    case "aggregationArrow":
                        aggregationArrow.Draw(cur, start, isClicked, _graphics, pen);
                        break;
                    default:
                        break;
                }
                //Ag.Draw(cur, start, isClicked, _graphics, pen);
               
                
                
                
                pictureBox1.Image = _tmpBitmap;

            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isClicked = false;
            _mainBitmap = _tmpBitmap;

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            isClicked = true;
            start = new Point(e.X, e.Y);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _mainBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            _graphics = Graphics.FromImage(_mainBitmap);
            pictureBox1.Image = _mainBitmap;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void InheritanceArrow_Click(object sender, EventArgs e)
        {
            inheritanceArrow = new InheritanceArrow();
            

            action = "inheritanceArrow";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            associationArrow = new AssociationArrow();
            action = "associationArrow";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            addictionArrow = new AddictionArrow();
            action = "addictionArrow";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RealizationArrow realizationArrow = new RealizationArrow();
            action = "realizationArrow";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            aggregationArrow = new AggregationArrow();
            action = "aggregationArrow";
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            pen.Width = trackBar1.Value;
        }

        private void colorLineButton_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            pen.Color = colorDialog1.Color;
        }
    }
}
