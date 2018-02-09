using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace 五子棋
{
    class ChessBoard
    {
        
        static readonly Color color = Color.Black;
        static readonly float penWid = 1.0f;
        static readonly Pen pen = new Pen(color, penWid);        

        public static void DrawCB(Graphics gra,PictureBox pic)
        {
            //每排数量
            int horC = MainSize.CBWid / MainSize.CBGap;
            //间隔
            int gap = MainSize.CBGap;
            Image img = new Bitmap(MainSize.CBWid, MainSize.CBHei);
            gra = Graphics.FromImage(img);
            gra.Clear(Color.White);
            gra.DrawRectangle(pen, 0, 0, MainSize.CBWid, MainSize.CBHei);
            //画棋盘
            for (int i = 0; i < horC; i++)
            {
                gra.DrawLine(pen, 0, i * gap, MainSize.CBWid, i * gap);
                gra.DrawLine(pen, i * gap, 0, i * gap, MainSize.CBHei);
            }
            gra.DrawLine(pen, 0, horC * gap, MainSize.CBWid, horC * gap - 1);
            gra.DrawLine(pen, horC * gap - 1, 0, horC * gap, MainSize.CBHei);
            pic.Image = img;
        }
      
    }
}
