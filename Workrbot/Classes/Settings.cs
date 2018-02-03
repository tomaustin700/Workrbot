using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security;
using System.Web;
using System.Xml.Serialization;

namespace Workrbot.Classes
{
    public class SettingsConstants
    {
        public const string PasswordEmptyString = "fdgkdng834nkldfgn8iekjdfh";
    }

    [Serializable]
    public class Settings
    {
        public string Username { get; set; }
        public byte[] Cipher { get; set; }
        public byte[] Entropy { get; set; }
        [XmlIgnore]
        public string Password { get; set; }
        public string Domain { get; set; }

        [XmlIgnore]
        public string TFSUrl
        {
            get
            {
                return CollectionUri?.Value.ToString();
            }
            set
            {
                if (value != null)
                    CollectionUri = new XmlUri(new Uri(value));
            }
        }
        public XmlUri CollectionUri { get; set; }

        public Settings()
        {
            Username = "Workrbot";
        }
    }
}