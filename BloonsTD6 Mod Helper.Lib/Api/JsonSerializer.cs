using Newtonsoft.Json;
using System;
using System.IO;
using UnityEngine;

namespace BloonsTD6_Mod_Helper.Api
{
    public class JsonSerializer
    {
        public string SerializeJson<T>(T objectToSerialize, bool shouldIndent = false)
        {
            Formatting formatting = (shouldIndent) ? Formatting.Indented : Formatting.None;
            string json = JsonConvert.SerializeObject(objectToSerialize, formatting);
            return json;
        }

        /// <summary>
        /// Create an instance of a class from file
        /// </summary>
        /// <typeparam name="T">The type to load</typeparam>
        /// <param name="filePath">Location of the file</param>
        public T LoadFromFile<T>(string filePath) where T : class
        {
            if (!IsPathValid(filePath))
                return null;

            string json = File.ReadAllText(filePath);
            if (String.IsNullOrEmpty(json))
                return null;

            return JsonConvert.DeserializeObject<T>(json);
        }

        private bool IsPathValid(string filePath)
        {
            Guard.ThrowIfStringIsNull(filePath, "Can't load file, path is null");
            return File.Exists(filePath);
        }


        /// <summary>
        /// Save an instance of a class to file
        /// </summary>
        /// <typeparam name="T">Type of class to save</typeparam>
        /// <param name="jsonObject">Object to save. Must be of Type T</param>
        /// <param name="savePath">Location to save file to</param>
        /// <param name="overwriteExisting">Overwrite the file if it already exists</param>
        public void SaveToFile<T>(T jsonObject, string savePath, bool shouldIndent = false, bool overwriteExisting = true) where T : class
        {
            Guard.ThrowIfStringIsNull(savePath, "Can't save file, save path is null");
            CreateDirIfNotFound(savePath);

            bool keepOriginal = !overwriteExisting;
            StreamWriter serialize = new StreamWriter(savePath, keepOriginal);

            string json = SerializeJson(jsonObject, shouldIndent);
            serialize.Write(json);
            serialize.Close();
        }

        private void CreateDirIfNotFound(string dir)
        {
            FileInfo f = new FileInfo(dir);
            Directory.CreateDirectory(f.Directory.FullName);
        }
    }
}
