using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class Matrix
    {
        int[,] m_matrixp;

        public Matrix()
        {
            m_matrixp = new int[constants.playzonerow, constants.playzonecol];
        }

        public int[,] matrizPantalla
        {
            get
            {
                return m_matrixp;
            }
        }

        public int this[int y, int x]
        {
            get
            {
               
                    return m_matrixp[y, x];
            }
            set
            {
               
                    m_matrixp[y, x] = value;
                
            }
        }

        public void pintBrick(Brick p)        //vẽ ma trận
        {
            int width = p.crong;                // chiều rộng
            int height = p.ccao;                  //chiều cao
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (p[y, x] == 1 && p.posY + y >= 0)
                    {
                        m_matrixp[p.posY + y, p.posX + x] = p.color;
                    }
                }
            }
        }

        public bool movedown(Brick p)
        {
            bool may = true;
            int width = p.crong;
            int height = p.ccao;
            if (p.posY + p.ccao > constants.playzonerow|| checkcolision(p))
            {
                may = false;
            }
            return may;
        }

        public bool checkcolision(Brick p)
        {
            bool check = false;
            int width = p.crong;
            int height = p.ccao;
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (p[y, x] == 1 && p.posY + y >= 0)
                    {
                        if (m_matrixp[p.posY + y, p.posX + x] != 0)
                        {
                            check = true;
                        }
                    }
                }
            }
            return check;
        }

        public bool checkmove(Brick p)
        {
            bool may = true;
            int width = p.crong;
            int height = p.ccao;
            if (p.posX < 0 || p.posX + p.crong > constants.playzonecol || checkcolision(p))
            {
                may = false;
            }
            return may;
        }

        public void clearBrick(Brick p)    //xóa gạch
        {
            int width = p.crong;
            int height = p.ccao;
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (p[y, x] == 1 && p.posY + y >= 0)
                    {
                        m_matrixp[p.posY + y, p.posX + x] = 0;
                    }
                }
            }
        }

        public void clearscreen()    //làm tươi màn hình
        {
            m_matrixp = new int[constants.playzonerow, constants.playzonecol];
        }

        public int clearLineCompletas()     //loại bỏ hoàn toàn dòng
        {
            bool filaCompleta = true;           //hoàn thành đường
            int numFilasCompletas = 0;          //số dòng hoàn thành
            int x;
            for (int y = 0; y < constants.playzonerow; y++)
            {
                filaCompleta = true;
                x = 0;
                while (x < constants.playzonecol && filaCompleta)
                {
                    if (m_matrixp[y, x] == 0)
                    {
                        filaCompleta = false;
                    }
                    x++;
                }
                if (filaCompleta)
                {
                    clearrow(y);
                    numFilasCompletas++;
                }
            }
            return numFilasCompletas;
        }

        private void clearrow(int linea)        //xóa dòng
        {
            for (int y = linea; y > 0; y--)
            {
                for (int x = 0; x < constants.playzonecol; x++)
                {
                    m_matrixp[y, x] = m_matrixp[y - 1, x];
                }
            }
        }
    }
}
