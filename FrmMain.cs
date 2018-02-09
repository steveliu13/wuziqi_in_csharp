using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 五子棋
{
    public partial class FrmMain : Form
    {
        Graphics graphic;
        //双方轮换,true是红，false是蓝
        static bool type;
        //是否开始
        static bool start;
        //用于计算棋盘的矩阵,1代表红,2代表蓝
        int[,] ChessBack = new int[20, 20];

        public FrmMain()
        {
            InitializeComponent();
            this.Width = MainSize.Wid;
            this.Height = MainSize.Hei;
            this.pictureBox1.Width = MainSize.CBWid;
            this.pictureBox1.Height = MainSize.CBHei;
        }

        private void InitializeThis()
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                    ChessBack[i, j] = 0;
            }
            start = false;
            label1.Text = "游戏尚未开始";
            ChessBoard.DrawCB(graphic, this.pictureBox1);
            type = true;
            btnStart.Enabled = true;
            btnReset.Enabled = false;
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeThis();            
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (start)
            {
                //在计算矩阵中的位置
                int bX = (int)((e.X + MainSize.CBGap / 2) / MainSize.CBGap);
                int bY = (int)((e.Y + MainSize.CBGap / 2) / MainSize.CBGap);
                //防止在同一个位置落子
                if (ChessBack[bX, bY] != 0)
                    return;
                Chess.DrawChess(type, pictureBox1, graphic, e);
                ChessBack[bX,bY] = type?1:2;
                //判断棋盘是否满了
                
                if (IsFull() && !Victory(bX,bY))
                {
                    if (MessageBox.Show("游戏结束，平局") == DialogResult.OK)
                        InitializeThis();
                    return;
                }
                //判断胜利
                if (Victory(bX,bY))
                {
                    string Vic = type ? "红" : "蓝";
                    if (MessageBox.Show(Vic + "方胜利!") == DialogResult.OK)
                        InitializeThis();
                    return;
                }
                 
                //换人
                type = !type;
                label1.Text = type ? "红方's trun!" : "蓝方's turn!";
            }
            else
                return;
        }

        private bool IsFull()
        {
            bool full = true;
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    if (ChessBack[i, j] == 0)
                        full = false;
                }
            }
            return full;
        }

        #region 判断胜利
        private bool Victory(int bx,int by)
        {
            if (HorVic(bx, by))
                return true;
            if (VerVic(bx, by))
                return true;
            if (Vic45(bx, by))
                return true;
            else
                return false;
        }

        private bool Vic45(int bx, int by)
        {
            
            int b1 = (bx - 4) > 0 ? bx - 4 : 0;
            int b2 = (by - 4) > 0 ? by - 4 : 0;
            //int buttom = b1 > b2 ? b2 : b1;
            int val = ChessBack[bx, by];
            for (int i = b1,j=b2; i < 16&&j<16; i++,j++)
            {
                if (ChessBack[i, j] == val && ChessBack[i + 1, j + 1] == val &&
                    ChessBack[i + 2, j + 2] == val && ChessBack[i + 3, j + 3] == val
                    && ChessBack[i + 4, j + 4] == val)
                    return true;
            }
            for (int i = b1, j = b2; i < 16 && j < 16; i++, j++)
            {
                if (ChessBack[i, j] == val && ChessBack[i + 1, j - 1] == val &&
                    ChessBack[i + 2, j - 2] == val && ChessBack[i + 3, j - 3] == val
                    && ChessBack[i - 4, j - 4] == val)
                    return true;
            }
            return false;
        }

        private bool VerVic(int bx, int by)
        {
            int buttom = (by - 4) > 0 ? by - 4 : 0;
            int val = ChessBack[bx, by];
            for (int i = buttom; i < 16; i++)
            {
                if (ChessBack[bx, i] == val && ChessBack[bx, i+1] == val &&
                    ChessBack[bx, i+2] == val && ChessBack[bx ,i+3] == val
                    && ChessBack[bx, i+4] == val)
                    return true;
            }
            return false;
        }

        private bool HorVic(int bx, int by)
        {
            int left = (bx-4)>0?bx-4:0;
            int val = ChessBack[bx,by];
            for (int i = left; i < 16; i++)
            {
                if (ChessBack[i, by] == val && ChessBack[i + 1, by] == val &&
                    ChessBack[i + 2, by] == val && ChessBack[i + 3, by] == val
                    && ChessBack[i + 4, by] == val)
                    return true;
            }
            return false;
        }
        #endregion


        private void btnStart_Click(object sender, EventArgs e)
        {
            start = true;
            label1.Text = "游戏开始！";
            btnStart.Enabled = false;
            btnReset.Enabled = true;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("确定要重新开始？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {                           
                InitializeThis();
            }
        }

      
    }
}
