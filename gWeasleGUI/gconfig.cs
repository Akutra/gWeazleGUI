using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace gWeasleGUI.Config
{
    public class Gconfig
    {
        public string GwToolsPath { get; set; }
        public string gwport { get; set; }
        //public string LogFile { get; set; }
        public bool Time { get; set; } = true;
        public string LastFormatType { get; set; } = string.Empty;
        public string LastFileExt { get; set; } = string.Empty;
        public bool RawFormat { get; set; } = false;
        public string LastDiskDefsCfgFile { get; set; } = string.Empty;
        public bool LastUseDiskDefsCfgFile { get; set; } = true;

        public ProfileDictionary<string, string> profiles = new ProfileDictionary<string, string>();

        public Gconfig()
        {
            // TODO Log file output of accumulated activity
            // default log file
            //this.LogFile = "gwlog.txt";
        }
    }

    public class ConfigLoader
    {
        public static string Version { get; set; } = "0.9";
        public static string VersionDetails { get; set; } = "beta 3";
        public static string AppName { get; set; } = "gWeazleGUI";

        public readonly int ERROR_BAD_ARGUMENTS = 0xA0;

        public Gconfig ConfigData { get; set; }

        private string _configfile = "";

        private ILogger logger;

        private Action ActionComplete, ActionStart;

        public ConfigLoader(ILogger logger, Action WorkStart, Action WorkComplete, string configPath = "gconfig.xml")
        {
            this._configfile = configPath;
            this.ActionStart = WorkStart;
            this.ActionComplete = WorkComplete;

            if (logger is null)
            {
                //this.ScreenPrinter = new DisplayManager();
            }
            else
            {
                this.logger = logger;
            }

            this.ReLoad();
        }

        public void ReLoad()
        {
            // Initialize to empty
            this.ActionStart();
            this.ConfigData = new Gconfig();
            FileStream fs = null;

            if (File.Exists(this._configfile))
            {
                try // don't crash loading config file
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Gconfig));
                    fs = new FileStream(this._configfile, FileMode.Open);

                    Gconfig _gconfig = (Gconfig)serializer.Deserialize(fs);
                    this.ConfigData = _gconfig;
                }
                catch (Exception ex)
                {
                    // for now simply don't read config on error
                    this.logger.Error($"Unable to load the config file.", ex);
                }
                fs?.Close();
            }
            this.ActionComplete();
        }

        public bool WriteConfig()
        {
            this.ActionStart();
            bool success = true;
            TextWriter writer = null;

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Gconfig));
                writer = new StreamWriter(this._configfile);

                serializer.Serialize(writer, this.ConfigData);
                writer.Close();
            }
            catch (Exception ex)
            {
                // for now simply don't read config on error
                this.logger.Error($"Write config file failed", ex);
                System.Environment.Exit(ERROR_BAD_ARGUMENTS);
                success = false;
            }
            writer?.Close();

            this.ActionComplete();
            return success;
        }
    }
}

