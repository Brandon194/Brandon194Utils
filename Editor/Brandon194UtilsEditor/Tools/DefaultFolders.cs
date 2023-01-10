using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


namespace Brandon194.Editor
{
    public static class DefaultFolders
    {
        public static void CreateDirectory(string root, params string[] dir)
        {
            string fullpath = Path.Combine(Application.dataPath, root);
            foreach (string newDir in dir)
            {
                Directory.CreateDirectory(Path.Combine(fullpath, newDir));
            }
        }
    }
}
