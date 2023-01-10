using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;

namespace Brandon194
{
    public class Save
    {
        string savePath;

        public Save(string fileName)
        {
            this.savePath = Application.persistentDataPath + "/" + fileName;
            CheckDirectory(this.savePath);
        }

        public void SaveFile(SaveObject s)
        {
            SaveObject save = s;

            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(savePath, FileMode.OpenOrCreate);
            bf.Serialize(stream, save);
            stream.Close();
        }

        public static void CheckDirectory(string path)
        {
            string[] folderPaths = path.Split('/');
            string newfolderPath = "";

            for (int i = 0; i < folderPaths.Length - 1; i++)
            {
                newfolderPath += folderPaths[i] + "/";
            }

            if (!Directory.Exists(newfolderPath))
            {
                Directory.CreateDirectory(newfolderPath);
            }
        }

        public SaveObject LoadFile()
        {
            SaveObject save = new SaveObject();

            if (File.Exists(savePath))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream stream = new FileStream(savePath, FileMode.Open);
                save = (SaveObject)bf.Deserialize(stream);
                stream.Close();

                return save;
            }

            Debug.LogWarning("No save found: " + savePath);
            return null;

        }



        public void SaveJson(SaveObject save)
        {
            string json = JsonUtility.ToJson(save);

            json = FormatJSON(json);

            File.WriteAllText(savePath, json);
        }
        public SaveObject LoadJson()
        {
            if (File.Exists(savePath))
            {
                string json = File.ReadAllText(savePath);
                json = UnformatJSON(json);

                SaveObject save = JsonUtility.FromJson<SaveObject>(json);
                return save;
            }
            else
            {
                Debug.Log("No Save Found");
                return null;
            }
        }

        public string LoadJsonAsString()
        {
            if (File.Exists(savePath))
            {
                string json = File.ReadAllText(savePath);
                return UnformatJSON(json);
            }
            else
            {
                Debug.Log("No Save Found");
                return "";
            }
        }
        public static string LoadJSONFile(string path)
        {
            if (File.Exists(path))
            {
                StreamReader reader = new StreamReader(path);
                string readFile = reader.ReadToEnd();

                reader.Close();

                return readFile;
            }

            return null;
        }

        public T LoadJsonFromString<T>(string jsonIn) where T : SaveObject
        {
            string json = UnformatJSON(jsonIn);
            Debug.Log(json);
            return (T)(JsonUtility.FromJson<SaveObject>(json));
        }


        public void SaveTextFile(SaveObject save)
        {
            StreamWriter writer = new StreamWriter(savePath);
            writer.Write(save.ToString());
            writer.Close();
        }
        public string LoadTextFile()
        {
            StreamReader reader = new StreamReader(savePath);
            return reader.ReadToEnd();
            reader.Close();
        }



        public string GetSavePath()
        {
            return savePath;
        }


        //For JSON formatting

        static string InsertTabs(string toSplit)
        {
            string[] array = toSplit.Split(new string[] { "\n" }, System.StringSplitOptions.None);
            toSplit = "";

            int openSquiggle = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Contains("}"))
                {
                    openSquiggle--;
                }

                string tabs = "";
                for (int j = 0; j < openSquiggle; j++)
                {
                    tabs += "\t";
                }

                toSplit = toSplit + tabs + array[i] + "\n";

                if (array[i].Contains("{"))
                {
                    openSquiggle++;
                }
            }

            return toSplit;
        }

        public static string FormatJSON(string json)
        {
            json = json.Replace(",", ",\n");
            json = json.Replace("}", "\n}\n");
            json = json.Replace("{", "\n{\n");
            json = json.Replace("[", "[\n");
            json = InsertTabs(json);

            return json;
        }
        public static string UnformatJSON(string json)
        {
            json = json.Replace("\t", "");
            json = json.Replace(" ", "");
            json = json.Replace("\n", "");

            return json;
        }

        public static void QuickSaveFile(string fileName, SaveObject saveFile)
        {
            Save save = new Save(fileName);
            save.SaveFile(saveFile);
        }

        public static T QuickLoadFile<T>(string fileName) where T : SaveObject
        {
            Save save = new Save(fileName);
            return (T)save.LoadFile();
        }
        public static SaveObject QuickLoadFile(string fileName)
        {
            Save save = new Save(fileName);
            return save.LoadFile();
        }

        [System.Serializable]
        public class SaveObject
        {

        }
    }
}
