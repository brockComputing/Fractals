using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fractals_Chapter8
{
    public partial class Lsystems : Form
    {

        class Rule
        {
            public char A { get; set; }
            public string B { get; set; }

            public Rule(char a, string b)
            {
                A = a;
                B = b;
            }
        }

        class Turtle
        {
            public string ToDo { get; set; }
            public float Len { get; set; }
            public float Theata { get; set; }

            public Turtle(string toDo, float len, float theata)
            {
                ToDo = toDo;
                Len = len;
                Theata = theata;
                
            }

            public void Render(PaintEventArgs e, GraphicsState gs)
            {
              
                for (int i = 0; i < ToDo.Length; i++)
                {
                    char c = ToDo[i];
                    if (c == 'F' || c == 'G')
                    {
                        e.Graphics.DrawLine(Pens.BlueViolet, 0, 0, Len, 0);
                        e.Graphics.TranslateTransform(Len, 0);
                    }
                    else if (c == '+')
                    {
                        e.Graphics.RotateTransform(Theata);
                    }
                    else if (c == '-')
                    {
                        e.Graphics.RotateTransform(-Theata);
                    }
                    else if (c == '[')
                    {

                        gs = e.Graphics.Save();
                    }
                    else if (c == ']')
                    {
                        e.Graphics.Restore(gs);
                    }
                }
            }
           

            public void ChangeLen(float percent)
            {
                Len *= percent;
            }

        }
        class LSystem
        {
            public string Sentence { get; set; }
            public List<Rule> RuleSet { get; set; }
            public int Generation { get; set; }

            public LSystem(string axiom, List<Rule> ruleSet)
            {
                Sentence = axiom;
                RuleSet = ruleSet;
                Generation = 0;
            }

            public void generate()
            {
                StringBuilder nextGen = new StringBuilder();
                for (int i = 0; i < Sentence.Length; i++)
                {
                    char curr = Sentence[i];
                    string replace = "" + curr;
                    for (int j = 0; j < RuleSet.Count; j++)
                    {
                        char a = RuleSet[j].A;
                        if (a == curr)
                        {
                            replace = RuleSet[j].B;
                            break;
                        }
                    }
                    nextGen.Append(replace);
                }
                Sentence = nextGen.ToString();
                Generation++;
            }
        }

        public Lsystems()
        {
            InitializeComponent();
        }
        String sentence;
        List<Rule> ruleSet = new List<Rule>();
        int generation;
        LSystem lsys;
        Turtle turtle;
        private void OnPaint(object sender, PaintEventArgs e)
        {
            GraphicsState graphicsState = e.Graphics.Save();
            e.Graphics.TranslateTransform(this.Width / 2, this.Height);
            e.Graphics.RotateTransform(-90);
            //e.Graphics.DrawLine(Pens.Red , 0, 0, 180, 0);
            turtle.Render(e, graphicsState);
        }

        private void Lsystems_Load(object sender, EventArgs e)
        {
            List<Rule> ruleSet = new List<Rule>();

            //// Fill with two rules (These are rules for the Sierpinksi Gasket Triangle)
            //ruleSet.Add(new Rule('F', "F--F--F--G"));
            //ruleSet.Add(new Rule('G', "GG"));
            //lsys = new LSystem("F--F--F", ruleSet);
            //turtle = new Turtle(lsys.Sentence, this.Width * 2, 120);

            //// some rubbish squares 
            //ruleSet.Add(new Rule('F',"FF+[+F-F-F]-[-F+F+F]"));            
            //lsys = new LSystem("F", ruleSet);
            //turtle = new Turtle(lsys.Sentence, this.Width - 1, 90);

            // a rubbish bush
            //ruleSet.Add(new Rule('F', "FF+[+F-F-F]-[-F+F+F]"));
            //lsys = new LSystem("F", ruleSet);
            //turtle = new Turtle(lsys.Sentence, Height / 3, 25);

            ruleSet.Add(new Rule('F', "F[F]-F+F[--F]+F-F"));
            lsys = new LSystem("F-F-F-F", ruleSet);
            turtle = new Turtle(lsys.Sentence, this.Width - 1, 90);
        }

        private void OnClick(object sender, MouseEventArgs e)
        {
            lsys.generate();
            turtle.ToDo = lsys.Sentence;
            turtle.ChangeLen(0.5F);
            Invalidate();
        }
    }
}
