using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
<<<<<<< HEAD
=======
using System.Web.Script.Serialization;
>>>>>>> 743c32fdd5c448400a4abbcdad711daf89af8795
using System.Windows.Forms;

namespace Tetris
{
    public partial class Form2 : Form
    {
<<<<<<< HEAD
        public Form2()
        {
            InitializeComponent();
=======
        List<int> listScore = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        string sFileScore = @"D:\STD\CS OOP\clonegit\G3TETRIS\score.json";
        public Form2()
        {
            InitializeComponent();
            
            if (System.IO.File.Exists(sFileScore))
            {
                string sJson;
                sJson = System.IO.File.ReadAllText(sFileScore);
                if (sJson != null)
                {
                    JavaScriptSerializer serial = new JavaScriptSerializer();
                    listScore = serial.Deserialize<List<int>>(sJson);
                    
                }
            }
>>>>>>> 743c32fdd5c448400a4abbcdad711daf89af8795
        }

        private void Form2_Load(object sender, EventArgs e)
        {
<<<<<<< HEAD

        }
=======
            GFG gg = new GFG();
            listScore.Sort(gg);
            listScore.Reverse();
            lbhp1.Text = listScore[0].ToString();
            lbhp2.Text = listScore[1].ToString();
            lbhp3.Text = listScore[2].ToString();
            lbhp4.Text = listScore[3].ToString();
            lbhp5.Text = listScore[4].ToString();
            lbhp6.Text = listScore[5].ToString();
            lbhp7.Text = listScore[6].ToString();
            lbhp8.Text = listScore[7].ToString();
            lbhp9.Text = listScore[8].ToString();
            lbhp10.Text = listScore[9].ToString();

        }
        public void addscore(int hs)
        {
            GFG gg = new GFG();
            listScore.Sort(gg);
            if (listScore.Count > 10)
            {
                if (hs > listScore[0])
                {
                    listScore.RemoveAt(0);
                    listScore.Add(hs);
                }
            }
            else
            {
                listScore.Add(hs);
            }

            JavaScriptSerializer serial = new JavaScriptSerializer();
            string sJson = serial.Serialize(listScore);
            System.IO.File.WriteAllText(sFileScore, sJson);
        }

        
>>>>>>> 743c32fdd5c448400a4abbcdad711daf89af8795
    }
}
