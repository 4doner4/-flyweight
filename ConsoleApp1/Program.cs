using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ConsoleApp1.FigureFactory;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

    public class Figure
    {
        public string colors;
        public int height;
        public int width;
        public int x;
        public int y;


    }

    public class Circ : Figure
    {
        public Circ()
        {
            
            colors = "red";
            height = 100;
            width = 100;
            x = 0;
            y = 0;
        }

    }
    public class Rec : Figure
    {

        public Rec()
        {
            colors = "blue";
            height = 100;
            width = 100;
            x = 0;
            y = 100;
        }


    }

    class FigureFactory
    {
        Dictionary<string, Figure> Figures = new Dictionary<string, Figure>();
        public FigureFactory()
        {
            Figures.Add("Circle", new Circ());
            Figures.Add("Rectangle", new Rec());
        }

        public Figure GetFigure(string key)
        {

            if (Figures.ContainsKey(key))
                return Figures[key];
            else
                return null;

        }





    public class Form1 : Form
        {
            private System.ComponentModel.IContainer components = null;
       

            protected override void Dispose(bool disposing)
            {
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }

            private void Circle(object sender, System.Windows.Forms.PaintEventArgs e)
            {

                FigureFactory figureFactory = new FigureFactory();
                Figure circ = figureFactory.GetFigure("Circle");


                Graphics g = e.Graphics;
                SolidBrush color = new SolidBrush(Color.FromName(circ.colors));

                if (circ != null)
                {
                    g.FillEllipse(color, circ.x, circ.y, circ.width, circ.height);
                }
                else
                {
                    g.FillEllipse(color, 0, 0, 50, 50);
                }
              
            }


            private void Rectangle(object sender, System.Windows.Forms.PaintEventArgs e)
            {

                FigureFactory figureFactory = new FigureFactory();
                Figure rec = figureFactory.GetFigure("Rectangle");


                Graphics g = e.Graphics;
                SolidBrush color = new SolidBrush(Color.FromName(rec.colors));

                if (rec != null)
                {
                    g.FillRectangle(color, rec.x, rec.y, rec.width, rec.height);
                }
                else
                {
                    g.FillRectangle(color, 0, 0, 50, 50);
                }

            }


            private void InitializeComponent()
            {
                this.SuspendLayout();
                this.Paint += new System.Windows.Forms.PaintEventHandler(this.Circle);
                this.Paint += new System.Windows.Forms.PaintEventHandler(this.Rectangle);
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(284, 261);
                this.Name = "Form1";
                this.Text = "Привет мир!";
                this.ResumeLayout(false);
               


            }
            public Form1()
            {
                InitializeComponent();
            }

        
        }
    }
}
