using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace СИАКОД_4_0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<Node> nodes = new List<Node>();
        List<Rebro> rebra = new List<Rebro>();
        

        
        private void pBox_Paint(object sender, PaintEventArgs e)
        {
           foreach(Node n in nodes)
            {
               n.draw(e.Graphics);
            }
            foreach (Rebro r in rebra)
            {
                r.draw(e.Graphics);
            }
           

            pBox.Select();
        }

        void link(Node n1,Node n2)
        {
            Rebro r = new Rebro(n1, n2);
            rebra.Add(r);
            n1.linkedN.Add(n2);
            n2.linkedN.Add(n1);
            foreach (Node no in nodes)
             {
                if (no.CheckSelect())
                { 
                    no.Select();
                }
             }
        }

        int next = 0;
        Node n1;
        Node n2;
        int count = 0;
        private void pBox_MouseClick(object sender, MouseEventArgs e)
        {
            int flag = 0;

            if (next == 0)
            {
                foreach (Node n in nodes)
                {
                    if (n.mouseInShape(e.X, e.Y) == true)
                    {
                        next++;
                        flag = 1;
                        n.Select();
                        n1 = n;
                        this.Refresh();
                        pBox.Select();
                        return;
                    }
                }
            }

            if (next == 1)
            {
                foreach (Node n in nodes)
                {
                    if (n.mouseInShape(e.X, e.Y) == true)
                    {
                        flag = 1;
                        if (n.CheckSelect() != true)
                        {
                            next = 0;
                            n.Select();
                            n2 = n;
                            //Это в связывание
                            link(n1, n2);
                            this.Refresh();
                            pBox.Select();
                            return;
                           
                        }
                    }
                }
            }

            if (flag == 0)
            {
                Node n = new Node(e.X, e.Y, count);
                nodes.Add(n);
                count++;
            }
            this.Refresh();
            pBox.Select();
        }

        public void Wait(double seconds)
        {
            int ticks = System.Environment.TickCount + (int)Math.Round(seconds * 1000.0);
            while (System.Environment.TickCount < ticks)
            {
                Application.DoEvents();
            }
        }



       
        List<Node> stack ;
        int c = 0;
        void BFS(Node n, Graphics g)
        {

            n.fill = 1;
            label1.Text += n.num + ">>";
            n.draw(g);
            Wait(1);
            foreach (Node node in n.linkedN)
            {
                if (!stack.Contains(node))
                {
                    stack.Add(node);
                    Pen pen;
                    pen = new Pen(Brushes.Blue);
                    pen.Width = 4;
                    g.DrawLine(pen, n.x, n.y, node.x, node.y);
                }
            }
            if (c < stack.Count)
            BFS(stack[c++],g);
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = pBox.CreateGraphics(); ;
        
            stack = new List<Node>();
            int i = Convert.ToInt32(textBox1.Text);
            Node node = nodes[i];
           
            stack.Add(node);
            BFS(node,g);
           // this.Refresh();
            pBox.Select();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            count = 0;
            c = 0;
            rebra.Clear();
            nodes.Clear();
            this.Refresh();
            pBox.Select();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Graphics g = pBox.CreateGraphics(); ;
            c = 0;
            foreach (Node n in nodes)
                n.nonfillEllipse(g);
            this.Refresh();
            pBox.Select();
        }
    }
}
