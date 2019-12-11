using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace Tetris
{
    public partial class Form2 : Form
    {
        List<int> listScore = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        string FileScore;
        public Form2()
        {
            InitializeComponent();
            FileScore = (Assembly.GetEntryAssembly().Location + "");
            FileScore = FileScore.Replace("Tetris.exe", "score.json");
            if (System.IO.File.Exists(FileScore))
            {
                string sJson;
                sJson = System.IO.File.ReadAllText(FileScore);
                if (sJson != "")
                {
                    JavaScriptSerializer serial = new JavaScriptSerializer();
                    listScore = serial.Deserialize<List<int>>(sJson);
                    
                }
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
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
            System.IO.File.WriteAllText(FileScore, sJson);
        }

        
    }
}
