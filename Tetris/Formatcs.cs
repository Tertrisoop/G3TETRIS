using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class Formatcs
    {
        public int crong { get; set; }
        public int ccao { get; set; }
        private int[,] m_matixbrick = new int[constants.xbrick, constants.ybrick];

        public Formatcs(string formaPieza)
        {
            
                int unit = 0;
                crong = 0;
                ccao = 0;
                for (int y = 0; y < constants.xbrick; y++)
                {
                    for (int x = 0; x < constants.ybrick; x++)
                    {
                        unit = System.Int32.Parse(formaPieza.Substring((4 * y) + x, 1));
                        if (unit == 1)
                        {
                            if (ccao < y + 1)
                                ccao = y + 1;
                            if (crong < x + 1)
                                crong = x + 1;
                        }
                        
                        m_matixbrick[y, x] = unit;
                    }
                }
            
        }

        //thiết lập mảng không vượt quá số dòng cột quy định
        public int this[int y, int x]
        {
            get
            {
                    return m_matixbrick[y, x];
            }
            set
            {
                    m_matixbrick[y, x] = value;
            }
        }

       
    }
}
