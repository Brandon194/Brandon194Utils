using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public static SceneChanger instance;
    public float progress;
    AsyncOperation asyncOperation;

    public void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartAsyncLoad(int sceneNumber)
    {
        StartCoroutine(LoadAsyncScene(sceneNumber));
    }

    // Change Scene without Async
    public void LoadScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }

    // To Switch Async'd Scene
    public void SwitchAsyncScenes()
    {
        asyncOperation.allowSceneActivation = true;
    }

    // Threadable Load Scene
    private IEnumerator LoadAsyncScene(int sceneNumber)
    {
        yield return null;

        asyncOperation = SceneManager.LoadSceneAsync(1);
        asyncOperation.allowSceneActivation = false;

        while (!asyncOperation.isDone)
        {

            progress = asyncOperation.progress * 100;

            if (asyncOperation.progress >= 0.9f)
            {
            }

            yield return null;

        }
    }
}
