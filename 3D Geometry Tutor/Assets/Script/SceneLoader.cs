using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public static SceneLoader Instance;
    void Awake()
    {
        if (Instance != null)
        {
            DestroyImmediate(Instance.gameObject);
        }
        Instance = this;
    }

    public void LoadScene(string sceneName)
    {
        if (SceneManager.GetActiveScene().name == sceneName)
        {
            StartCoroutine("Unload", sceneName);
        }

        StartCoroutine("Load", sceneName);
    }

    public void UnloadScene(string sceneName)
    {
        StartCoroutine("Unload", sceneName);
    }

    IEnumerator Load(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        yield return null;
    }
    IEnumerator Unload(string sceneName)
    {
        SceneManager.UnloadSceneAsync(sceneName);
        yield return null;
    }
}
