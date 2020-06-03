using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GameDatabase1
{
    class Game
    {
        private string gameTitle;
        private string gameDeveloper;
        private string gamePublisher;
        private string platformName;
        private int releaseYear;

        public Game()
        {

        }

        ~Game()
        {

        }

        public string GameTitle
        {
            get
            {
                return gameTitle;
            }

            set
            {
                this.gameTitle = value;
            }
        }

        public string GameDeveloper
        {
            get
            {
                return gameDeveloper;
            }

            set
            {
                this.gameDeveloper = value;
            }
        }

        public string GamePublisher
        {
            get
            {
                return gamePublisher;
            }

            set
            {
                this.gamePublisher = value;
            }
        }

        public string PlatformName
        {
            get
            {
                return platformName;
            }

            set
            {
                this.platformName = value;
            }
        }

        public int ReleaseYear
        {
            get
            {
                return releaseYear;
            }

            set
            {
                this.releaseYear = value;
            }
        }

    }
}
