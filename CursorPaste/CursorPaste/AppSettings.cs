using System;
using System.IO;
using Newtonsoft.Json;

namespace CursorPaste
{
    public class AppSettings
    {
        [JsonProperty("SendOnEnter")]
        public bool SendOnEnter { get; set; } = false; // Default value

        public static AppSettings Load()
        {
            string filePath = GetSettingsFilePath();
            if (File.Exists(filePath))
            {
                try
                {
                    string json = File.ReadAllText(filePath);
                    return JsonConvert.DeserializeObject<AppSettings>(json) ?? new AppSettings();
                }
                catch (Exception ex)
                {
                    // Log the error or show a message, then return default settings
                    System.Diagnostics.Debug.WriteLine($"Error loading settings: {ex.Message}");
                    return new AppSettings();
                }
            }
            return new AppSettings();
        }

        public void Save()
        {
            string filePath = GetSettingsFilePath();
            try
            {
                string json = JsonConvert.SerializeObject(this, Formatting.Indented);
                File.WriteAllText(filePath, json);
            }
            catch (Exception ex)
            {
                // Log the error or show a message
                System.Diagnostics.Debug.WriteLine($"Error saving settings: {ex.Message}");
            }
        }

        private static string GetSettingsFilePath()
        {
            // Use Application.LocalUserAppDataPath for a robust, user-specific path
            // Example: C:\Users\<UserName>\AppData\Local\CursorPaste\CursorPaste\1.0.0.0\settings.json
            string appDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CursorPaste");
            Directory.CreateDirectory(appDataPath); // Ensure the directory exists
            return Path.Combine(appDataPath, "settings.json");
        }
    }
} 