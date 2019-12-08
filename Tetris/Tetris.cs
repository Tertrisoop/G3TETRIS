﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class Tetris
    {
        private Brick[] m_matrizBricks;             //ma trận
        private Matrix m_matrixP;    //màn hình ma trận
        private Brick m_BrickActual;                //phần hiện tại
        private Brick m_BrickSiguiente;             //Tiếp theo phòng
        private bool m_end;              //kết thúc game
        private int m_score;                   //deim
        private int m_lv;                        //cấp độ
        private int m_numline;                    //đếm dòng
        private Random r;

        #region vẽ và thiết lập xoay cho các khối gạch
        public Tetris()
        {
            m_matrixP = new Matrix();
            m_matrizBricks = new Brick[constants.numbrick];
            string formaBrick1 = "";
            string formaBrick2 = "";
            string formaBrick3 = "";
            string formaBrick4 = "";

            //          **
            //  Brick   **
            // hình vuông      
            formaBrick1 += "1100";
            formaBrick1 += "1100";
            formaBrick1 += "0000";
            formaBrick1 += "0000";

            m_matrizBricks[0] = new Brick(formaBrick1, formaBrick1, formaBrick1, formaBrick1, 7);

            //          
            //  Brick   ****
            // hình dài
            formaBrick1 = "";
            formaBrick1 += "1000";
            formaBrick1 += "1000";
            formaBrick1 += "1000";
            formaBrick1 += "1000";

            formaBrick2 = "";
            formaBrick2 += "0000";
            formaBrick2 += "1111";
            formaBrick2 += "0000";
            formaBrick2 += "0000";

            m_matrizBricks[1] = new Brick(formaBrick1, formaBrick2, formaBrick1, formaBrick2, 1);

            //          * 
            //  Brick   ***
            //hình L
            formaBrick1 = "";
            formaBrick1 += "1100";
            formaBrick1 += "1000";
            formaBrick1 += "1000";
            formaBrick1 += "0000";

            formaBrick2 = "";
            formaBrick2 += "1110";
            formaBrick2 += "0010";
            formaBrick2 += "0000";
            formaBrick2 += "0000";

            formaBrick3 = "";
            formaBrick3 += "0100";
            formaBrick3 += "0100";
            formaBrick3 += "1100";
            formaBrick3 += "0000";

            formaBrick4 = "";
            formaBrick4 += "1000";
            formaBrick4 += "1110";
            formaBrick4 += "0000";
            formaBrick4 += "0000";
            m_matrizBricks[2] = new Brick(formaBrick1, formaBrick2, formaBrick3, formaBrick4, 2);

            //           * 
            //  Brick   ***
            //hình T
            formaBrick1 = "";
            formaBrick1 += "1000";
            formaBrick1 += "1100";
            formaBrick1 += "1000";
            formaBrick1 += "0000";

            formaBrick2 = "";
            formaBrick2 += "1110";
            formaBrick2 += "0100";
            formaBrick2 += "0000";
            formaBrick2 += "0000";

            formaBrick3 = "";
            formaBrick3 += "0100";
            formaBrick3 += "1100";
            formaBrick3 += "0100";
            formaBrick3 += "0000";

            formaBrick4 = "";
            formaBrick4 += "0100";
            formaBrick4 += "1110";
            formaBrick4 += "0000";
            formaBrick4 += "0000";
            m_matrizBricks[3] = new Brick(formaBrick1, formaBrick2, formaBrick3, formaBrick4, 3);

            //           **
            //  Brick   **
            // hình Z ngược
            formaBrick1 = "";
            formaBrick1 += "0110";
            formaBrick1 += "1100";
            formaBrick1 += "0000";
            formaBrick1 += "0000";

            formaBrick2 = "";
            formaBrick2 += "1000";
            formaBrick2 += "1100";
            formaBrick2 += "0100";
            formaBrick2 += "0000";
            m_matrizBricks[4] = new Brick(formaBrick1, formaBrick2, formaBrick1, formaBrick2, 4);

            //         **  
            //  Brick   **
            // hình Z
            formaBrick1 = "";
            formaBrick1 += "1100";
            formaBrick1 += "0110";
            formaBrick1 += "0000";
            formaBrick1 += "0000";

            formaBrick2 = "";
            formaBrick2 += "0100";
            formaBrick2 += "1100";
            formaBrick2 += "1000";
            formaBrick2 += "0000";

            m_matrizBricks[5] = new Brick(formaBrick1, formaBrick2, formaBrick1, formaBrick2, 5);

            //            * 
            //  Brick   ***
            //hình L
            formaBrick1 = "";
            formaBrick1 += "1100";
            formaBrick1 += "0100";
            formaBrick1 += "0100";
            formaBrick1 += "0000";

            formaBrick2 = "";
            formaBrick2 += "1110";
            formaBrick2 += "1000";
            formaBrick2 += "0000";
            formaBrick2 += "0000";

            formaBrick3 = "";
            formaBrick3 += "1000";
            formaBrick3 += "1000";
            formaBrick3 += "1100";
            formaBrick3 += "0000";

            formaBrick4 = "";
            formaBrick4 += "0010";
            formaBrick4 += "1110";
            formaBrick4 += "0000";
            formaBrick4 += "0000";
            m_matrizBricks[6] = new Brick(formaBrick1, formaBrick2, formaBrick3, formaBrick4, 6);

            r = new Random(unchecked((int)DateTime.Now.Ticks));
            m_end = true;    //game over
        }
        #endregion


        public int[,] matrix
        {
            get
            {
                return m_matrixP.matrizPantalla;
            }
        }

        public bool end
        {
            get
            {
                return m_end;
            }
        }

        public Brick BrickSiguiente
        {
            get
            {
                return m_BrickSiguiente;
            }
        }

        public int score

        {
            get
            {
                return m_score;
            }
        }

        public int numLineas
        {
            get
            {
                return m_numline;
            }
        }

        public int level
        {
            get
            {
                return m_lv;
            }
        }

        private Brick newBrick()      //phần mới
        {
            int a = r.Next(0, constants.numbrick);
            Brick p = (Brick)((Brick)m_matrizBricks[a]).Clone();
            return p;
        }

        public void speed()       //tăng tốc
        {
            int numlinecomplete;
            Brick pTemp = (Brick)m_BrickActual.Clone();
            m_matrixP.clearBrick(m_BrickActual);
            pTemp.posY = pTemp.posY + 1;
            if (m_matrixP.movedown(pTemp))
            {
                m_BrickActual = pTemp;
            }
            else
            {
                m_matrixP.pintBrick(m_BrickActual);
                m_BrickActual = m_BrickSiguiente;
                if (!m_matrixP.movedown(m_BrickActual) && m_BrickActual.posY < 0)
                {
                    m_end = true;
                }
                m_BrickSiguiente = newBrick();
                numlinecomplete = LineComplete();
                if (numlinecomplete > 0)
                    m_score += calculatescore(numlinecomplete);
                m_numline += numlinecomplete;

            }
            if (!m_end)
                m_matrixP.pintBrick(m_BrickActual);
        }

        public void moveright()         //di chuyển qua phải
        {
            Brick pTemp = (Brick)m_BrickActual.Clone();
            m_matrixP.clearBrick(m_BrickActual);
            pTemp.posX = pTemp.posX + 1;
            if (m_matrixP.checkmove(pTemp))
            {
                m_BrickActual = pTemp;
            }
            m_matrixP.pintBrick(m_BrickActual);
        }

        public void moveleft()       //di chuyển qua trái
        {
            Brick pTemp = (Brick)m_BrickActual.Clone();
            m_matrixP.clearBrick(m_BrickActual);
            pTemp.posX = pTemp.posX - 1;
            if (m_matrixP.checkmove(pTemp))
            {
                m_BrickActual = pTemp;
            }
            m_matrixP.pintBrick(m_BrickActual);
        }

        public void rolateBrick()        //xoay khối gạch
        {
            Brick pTemp = (Brick)m_BrickActual.Clone();
            m_matrixP.clearBrick(m_BrickActual);
            pTemp.rolate();
            if (m_matrixP.checkmove(pTemp))
            {
                m_BrickActual = pTemp;
            }
            m_matrixP.pintBrick(m_BrickActual);
        }


        public void newgame()        //bắt đầu game mới
        {
            m_score = 0;
            m_numline = 0;
            m_lv = 0;
            constuct();
        }

        public void levelup()        //tăng cấp độ(độ khó)
        {
            if (m_lv < 9)
                m_lv++;
            m_numline = 0;
            constuct();
        }

        public void constuct()        //khởi tạo
        {
            m_matrixP.clearscreen();
            m_BrickActual = newBrick();
            m_BrickSiguiente = newBrick();
            m_matrixP.pintBrick(m_BrickActual);
            m_end = false;
        }

        private int LineComplete()      //kiểm tra dòng
        {
            return m_matrixP.clearLineCompletas();
        }

        private int calculatescore(int numlinecomplete)      //tính điểm khi ăn dòng
        {
            int score = 0;

            score += numlinecomplete * 50;

            return score;
        }
    }
}