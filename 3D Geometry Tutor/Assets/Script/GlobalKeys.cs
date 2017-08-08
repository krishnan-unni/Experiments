using HoloToolkit.Unity;
using UnityEngine;

public class GlobalKeys : MonoBehaviour
{
    private static GlobalKeys Instance;
    public static string SpokenCommand;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            DestroyImmediate(this);
        }
    }

    // Use this for initialization
    void Start()
    {
        SpokenCommand = string.Empty;
    }

}
