using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameDatabase1
{
    public static class Game
    {
        public static string gameTitle { get; set; }
        public static string gameDeveloper { get; set; }
        public static string gamePublisher { get; set; }
        public static string platformName { get; set; }
        public static string releaseYear { get; set; }
    }
}
