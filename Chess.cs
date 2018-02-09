using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace 五子棋
{
    class Chess
    {
        public static void DrawChess(bool type,PictureBox pic,Graphics graphic,MouseEventArgs e)
        {
            graphic = pic.CreateGraphics();
            Pen pen1 = new Pen(Color.Red, 1);
            Brush bru1 = new SolidBrush(Color.Red);
            Pen pen2 = new Pen(Color.Blue, 1);
            Brush bru2 = new SolidBrush(Color.Blue);
            int newX = (int)((e.X + MainSize.CBGap / 2) / MainSize.CBGap) * MainSize.CBGap - MainSize.ChessRadious / 2;
            int newY = (int)((e.Y + MainSize.CBGap / 2) / MainSize.CBGap) * MainSize.CBGap - MainSize.ChessRadious / 2;
            if (type)
            {
                graphic.DrawEllipse(pen1, newX, newY, MainSize.ChessRadious, MainSize.ChessRadious);
                graphic.FillEllipse(bru1, newX, newY, MainSize.ChessRadious, MainSize.ChessRadious);
            }
            if (!type)
            {
                graphic.DrawEllipse(pen2, newX, newY, MainSize.ChessRadious, MainSize.ChessRadious);
                graphic.FillEllipse(bru2, newX, newY, MainSize.ChessRadious, MainSize.ChessRadious);
            }
            graphic.Dispose();
        }
         
    }
}
