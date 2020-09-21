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
    class Node
    {
        public int selected = 0;
        public int a = 0;
        public int x = 0;
        public int y = 0;
        public int num = 0;
        // public int color = 0;
        public List<Node> linkedN;
        public int fill = 0;

        public Node(int dx, int dy,int nomer)
        {
            fill = 0;
            linkedN = new List<Node>();
            x = dx;
            y = dy;
            a = 50;
            num = nomer;
           //this.color = 1;
            selected = 0;
        }

        public bool CheckSelect()
        {
            if (selected == 1)
                return true;
            else return false;
        }

        public bool mouseInShape(int dx, int dy)
        {
            return (((dx - x) * (dx - x) + (dy - y) * (dy - y)) <= ((a / 2) * (a / 2)));
        }

        public void draw(Graphics g)
        {
            Pen pen;
            Font f = new Font("Arial", 10); ;
            Brush b =new SolidBrush(Color.Black);
            if (selected == 0)
            {
                pen = new Pen(Brushes.Blue);
                pen.Width = 2;
            }
            else
            {
                pen = new Pen(Brushes.Red);
                pen.Width = 2;
            }
            if (fill == 0)
            {
                g.DrawEllipse(pen, x - a / 2, y - a / 2, a, a);
                Brush fill = Brushes.White;
                g.FillEllipse(fill, x - a / 2, y - a / 2, a, a);
            }
            else
            {
                g.DrawEllipse(pen, x - a / 2, y - a / 2, a, a);
                Brush fill = Brushes.Green;
                g.FillEllipse(fill, x - a / 2, y - a / 2, a, a);
            }
            g.DrawString(num.ToString(), f, b, x, y);
        }

        public void fillEllipse()
        {
            fill = 1;
        }

        public void nonfillEllipse(Graphics g)
        {
            fill = 0;
        }

        public void Select()
        {
            if (selected == 1)
            {
                selected = 0;
            }
            else
            {
                selected = 1;
            }
        }

    }
}
