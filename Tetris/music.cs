using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class music
    {
        public music()
        {

        }
        public void bgsound()
        {
            string path_sound = (Assembly.GetEntryAssembly().Location + "");
            path_sound = path_sound.Replace("Tetris.exe", "BlueSapphire.wav");

            SoundPlayer player1 = new SoundPlayer(path_sound);
            player1.PlayLooping();
        }

        //public  void PlayMusic()
        //{
        //    SoundPlayer sound = new SoundPlayer();
        //    sound.SoundLocation = @"D:\STD\CS OOP\G3TETRIS\Tetris\NewFolder1\nevada.wav";
        //    sound.LoadAsync();
        //    sound.PlayLooping();
        //   // sound.Play();
        //}
        public void winner()
        {
            string path_sound = (Assembly.GetEntryAssembly().Location + "");
            path_sound = path_sound.Replace("Tetris.exe", "S104.wav");
            SoundPlayer sound = new SoundPlayer(path_sound);
            
            sound.Play();
        }

    }
}
