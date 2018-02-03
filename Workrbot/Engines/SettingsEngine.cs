using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.Serialization;
using Workrbot.Classes;

namespace Workrbot.Engines
{
    public static class SettingsEngine
    {
        public static void CheckSettingsExist()
        {
            if (!DoSettingsExist())
            {
                //Create folder then create settings, events and graph data
                StartupEngine.Init();
            }
        }

        public static Settings GetSettings()
        {
            var settings = Serialisation.DeSerializeObject<Settings>(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Workrbot", "Settings.xml"));

            if (settings.Entropy != null && settings.Entropy.Any())
                settings.Password = SettingsConstants.PasswordEmptyString;

            return settings;
        }

        public static void SaveSettings(Settings settings)
        {
            Serialisation.SerializeObject(EncryptPassword(settings), Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Workrbot", "Settings.xml"));
        }

        private static bool DoSettingsExist()
        {
            return Directory.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Workrbot"));
        }

      

        private static Settings EncryptPassword(Settings settings)
        {
            // Data to protect. Convert a string to a byte[] using Encoding.UTF8.GetBytes().
            if (settings.Password != SettingsConstants.PasswordEmptyString)
            {
                byte[] plaintext = Encoding.UTF8.GetBytes(settings.Password);

                // Generate additional entropy (will be used as the Initialization vector)
                settings.Entropy = new byte[20];
                using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
                {
                    rng.GetBytes(settings.Entropy);
                }

                settings.Cipher = ProtectedData.Protect(plaintext, settings.Entropy,
                    DataProtectionScope.CurrentUser);
            }
            else
            {
                var savedSettings = GetSettings();
                settings.Entropy = savedSettings.Entropy;
                settings.Cipher = savedSettings.Cipher;
            }

            return settings;
        }


        public static string GetPassword(Settings settings)
        {
            var array = ProtectedData.Unprotect(settings.Cipher, settings.Entropy, DataProtectionScope.CurrentUser);

            var secure = new SecureString();
            foreach (char c in array)
            {
                secure.AppendChar(c);
            }

            return SecureStringToString(secure);
        }

        private static string SecureStringToString(SecureString value)
        {
            IntPtr valuePtr = IntPtr.Zero;
            try
            {
                valuePtr = Marshal.SecureStringToGlobalAllocUnicode(value);
                return Marshal.PtrToStringUni(valuePtr);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(valuePtr);
            }
        }

       
    }
}