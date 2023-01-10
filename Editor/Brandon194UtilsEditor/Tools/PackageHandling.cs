using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;


namespace Brandon194.Editor
{
    public class PackageHandling
    {
        public static string GetGistURL(string id, string user = "Brandon194") => string.Format("https://gist.githubusercontent.com/{user}/{id}/raw", user, id);

        public static async Task<string> GetContents(string url)
        {
            using (var client = new System.Net.Http.HttpClient())
            {
                var response = await client.GetAsync(url);
                var content = await response.Content.ReadAsStringAsync();
                return content;
            }
        }

        public static void ReplacePackageFile(string contents)
        {
            var existing = Path.Combine(Application.dataPath, "../Packages/manifest.json");
            File.WriteAllText(existing, contents);
            UnityEditor.PackageManager.Client.Resolve();
        }

        public static void InstallPackage(string packageName) => UnityEditor.PackageManager.Client.Add(packageName);
        public static void RemovePackage(string packageName) => UnityEditor.PackageManager.Client.Remove(packageName);
    }
}
