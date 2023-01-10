using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace Brandon194
{
    [System.Serializable]
    public class TextureHandler
    {
        //    public Sprite sprite { get; protected set; }
        //    public Texture texture { get; protected set; }
        //    public bool ready { get; protected set; }
        //    public bool inUse { get; protected set; }

        //    public bool continuous = false;
        //    [SerializeField] List<FetchedSprite> fetchedSprites = new List<FetchedSprite>();
        //    [SerializeField] List<string> urls = new List<string>();

        //    public TextureHandler() { ready = false; inUse = false; }

        //    public IEnumerator ContinuousFetchSprite()
        //    {
        //        while (true)
        //        {
        //            if (urls.Count > 0)
        //            {
        //                UnityWebRequest www = UnityWebRequestTexture.GetTexture(urls[0]);
        //                yield return www.SendWebRequest();

        //                if (www.result != UnityWebRequest.Result.Success)
        //                {
        //                    Debug.LogError(urls[0] + "\n" + www.error);
        //                    urls.RemoveAt(0);
        //                }
        //                else
        //                {
        //                    texture = ((DownloadHandlerTexture)www.downloadHandler).texture;
        //                    fetchedSprites.Add(new FetchedSprite(urls[0], texture));
        //                    urls.RemoveAt(0);
        //                }

        //                if (urls.Count == 0) Brandon194.Statics.Delegates.textureHandlerFinished();
        //            }

        //            yield return new WaitForSeconds(1f);
        //        }
        //    }

        //    public IEnumerator FetchSprite(string url)
        //    {
        //        if (CheckForSprite(url))
        //        {
        //            yield return new WaitForSeconds(.01f);
        //            sprite = GetSprite(url);

        //        } else if (inUse == false)
        //        {
        //            inUse = true;
        //            UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        //            yield return www.SendWebRequest();

        //            if (www.result != UnityWebRequest.Result.Success)
        //            {
        //                Debug.LogError(url + "\n" + www.error);
        //            }
        //            else
        //            {
        //                texture = ((DownloadHandlerTexture)www.downloadHandler).texture;
        //                Rect rect = new Rect(0f, 0f, texture.width, texture.height);
        //                Vector2 pivot = Vector2.zero; //new Vector2(texture.width / 2, texture.height / 2);
        //                sprite = Sprite.Create((Texture2D)texture, rect, pivot, 100f);
        //                inUse = false;
        //                ready = true;
        //                fetchedSprites.Add(new FetchedSprite(url, texture));
        //                Debug.Log("Sprite Fetched");
        //            }
        //        }
        //    }

        //    public IEnumerator SetSprite(SpriteRenderer spriteRenderer, string url)
        //    {
        //        if (inUse) yield return new WaitForSeconds(0.01f);

        //        inUse = true;
        //        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        //        yield return www.SendWebRequest();

        //        if (www.result != UnityWebRequest.Result.Success)
        //        {
        //            Debug.LogError(url + "\n" + www.error);
        //        }
        //        else
        //        {
        //            texture = ((DownloadHandlerTexture)www.downloadHandler).texture;
        //            Rect rect = new Rect(0f, 0f, texture.width, texture.height);
        //            Vector2 pivot = Vector2.zero; //new Vector2(texture.width / 2, texture.height / 2);
        //            sprite = Sprite.Create((Texture2D)texture, rect, pivot, 100f);
        //            ready = true;
        //            spriteRenderer.sprite = sprite;
        //            fetchedSprites.Add(new FetchedSprite(url, texture));
        //        }
        //    }
        //    public IEnumerator SetSprite(UnityEngine.UI.Image image, string url)
        //    {
        //        if (inUse) yield return new WaitForSeconds(0.001f);

        //        inUse = true;
        //        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        //        yield return www.SendWebRequest();

        //        if (www.result != UnityWebRequest.Result.Success)
        //        {
        //            Debug.LogError(url + "\n" + www.error);
        //        }
        //        else
        //        {
        //            texture = ((DownloadHandlerTexture)www.downloadHandler).texture;
        //            Rect rect = new Rect(0f, 0f, texture.width, texture.height);
        //            Vector2 pivot = Vector2.zero; //new Vector2(texture.width / 2, texture.height / 2);
        //            sprite = Sprite.Create((Texture2D)texture, rect, pivot, 100f);
        //            ready = true;
        //            image.sprite = sprite;
        //            fetchedSprites.Add(new FetchedSprite(url, texture));
        //        }
        //    }

        //    public Sprite CreateSprite(Texture2D _texture)
        //    {
        //        Rect rect = new Rect(0f, 0f, texture.width, texture.height);
        //        Vector2 pivot = new Vector2(texture.width / 2, texture.height / 2);
        //        return Sprite.Create((Texture2D)texture, rect, pivot);

        //    }
        //    public bool CheckForSprite(string _url)
        //    {
        //        foreach(FetchedSprite sprite in fetchedSprites)
        //        {
        //            if (sprite.url == _url)
        //            {
        //                return true;
        //            }
        //        }

        //        return false;
        //    }
        //    public Sprite GetSprite(string _url)
        //    {
        //        foreach (FetchedSprite sprite in fetchedSprites)
        //        {
        //            if (sprite.url == _url)
        //            {
        //                return Sprite.Create(sprite.texture, new Rect(0f, 0f, sprite.texture.width, sprite.texture.height), Vector2.zero);
        //            }
        //        }

        //        return null;
        //    }

        //    public void AddUrl(string url)
        //    {
        //        if (!urls.Contains(url))
        //        {
        //            foreach(FetchedSprite sprite in fetchedSprites)
        //            {
        //                if (sprite.url == url) return;
        //            }
        //        }

        //            urls.Add(url);
        //    }
        //    public void AddUrl(string[] newUrls){
        //        foreach(string url in newUrls)
        //        {
        //            urls.Add(url);
        //        }
        //    }

        //    public void SaveFetched(string url)
        //    {
        //        SaveFetchedSprites sfs = new SaveFetchedSprites();
        //        sfs.fetchedSprites = fetchedSprites.ToArray();
        //        Save.QuickSaveFile(url, sfs);
        //    }
        //    public void LoadFetched(string url)
        //    {
        //        SaveFetchedSprites sfs = Save.QuickLoadFile<SaveFetchedSprites>(url);

        //        if (sfs == null) return;

        //        foreach(FetchedSprite fetched in sfs.fetchedSprites)
        //        {
        //            fetchedSprites.Add(fetched);
        //        }
        //    }
        //}

        //[System.Serializable]
        //public class FetchedSprite
        //{
        //    public string url;
        //    public Texture2D texture;

        //    public FetchedSprite(string _url, Texture _texture)
        //    {
        //        url = _url;
        //        texture = (Texture2D)_texture;
        //    }
        //}

        //[System.Serializable]
        //public class SaveFetchedSprites : Save.SaveObject
        //{
        //    public FetchedSprite[] fetchedSprites;
        //}

        [SerializeField] List<TextureURL> _textureURLs = new List<TextureURL>();
        [SerializeField] TextureURLSave textureURLSave = new TextureURLSave();

        public async Task<TextureURL> GetTexture(string name, string url)
        {
            TextureURL newURL = Contains(url);

            if (newURL == null)
            {
                newURL = new TextureURL(name,url);
                _textureURLs.Add(newURL);

                UnityWebRequest request = UnityWebRequestTexture.GetTexture(newURL.url);

                while (request.isDone == false)
                {
                    await Task.Delay(300);
                }

                BemLogger.Log("Texture Handler", Color.cyan, "Request has finished");
                newURL.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
            }

            return newURL;
        }

        public async Task<Sprite> GetSprite(string name, string url)
        {
            TextureURL texture = await GetTexture(name, url);
            return texture.Sprite;
        }

        void OnDestroy()
        {
            textureURLSave.textures = _textureURLs.ToArray();
            Save.QuickSaveFile("Testures.bem", textureURLSave);
        }

        TextureURL Contains(string url)
        {
            foreach(TextureURL t in _textureURLs)
            {
                if (t.url == url) return t;
                if (t.name == url) return t;
            }

            return null;
        }

        [System.Serializable]
        public class TextureURL
        {
            [field:SerializeField] public string name { get; private set; }
            [field:SerializeField] public string url { get; private set; }


            Texture2D _texture;
            public Texture2D texture 
            {
                get
                {
                    return _texture;
                }
                set
                {
                    if (_texture == null) _texture = value;
                }
            }

            Sprite _sprite;
            public Sprite Sprite
            {
                get
                {
                    if (_sprite == null)
                    {
                        Rect rect = new Rect(0f, 0f, texture.width, texture.height);
                        Vector2 pivot = new Vector2(texture.width * .5f, texture.height * .5f);
                        _sprite = Sprite.Create(texture, rect, pivot);
                    }

                    return _sprite;
                }
            }


            public TextureURL(string name, string url)
            {
                this.name = name;
                this.url = url;
            }
        }

        public class TextureURLSave : Save.SaveObject
        {
            public TextureURL[] textures;
        }

    }
}
