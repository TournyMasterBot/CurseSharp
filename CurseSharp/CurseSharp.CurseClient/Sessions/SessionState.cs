using CurseSharp.CurseClient.Models;
using CurseSharp.CurseClient.Models.BotModels;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;

namespace CurseSharp.CurseClient.Sessions
{
    public static class SessionState
    {
        private static BotConnectionStatus connectionStatus { get; set; }
        private static BotStatisticsModel botStats { get; set; }

        public static BotStatisticsModel BotStats
        {
            get
            {
                return botStats;
            }
            set
            {
                botStats = value;
            }
        }

        public static void SaveBotStats()
        {
            var savePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\CurseSharp\Save\BotStats.ini";
            var saveDirectory = Path.GetDirectoryName(savePath);

            try
            {
                if(!Directory.Exists(saveDirectory))
                {
                    Directory.CreateDirectory(saveDirectory);
                }
                File.WriteAllText(savePath, JsonConvert.SerializeObject(botStats), Encoding.UTF8);
            }
            catch(Exception ex)
            {
                Logging.Log.Error(ex.ToString());
            }
        }

        public static BotConnectionStatus ConnectionStatus
        {
            get
            {
                return connectionStatus;
            }
            set
            {
                if(connectionStatus != value)
                {
                    connectionStatus = value;
                }
            }
        }

        static SessionState()
        {
            ConnectionStatus = BotConnectionStatus.Disconnected;
        }
    }
}
