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
    class Rebro
    {
        public Node node1;
        public Node node2;
      
        public Rebro(Node n1,Node n2)
        {
            node1 = n1;
            node2 = n2;
        }

        public void draw(Graphics g)
        {
            Pen pen;
            pen = new Pen(Brushes.Black);
                pen.Width = 2;
                g.DrawLine(pen, node1.x, node1.y, node2.x, node2.y);   
        }

    }
}
