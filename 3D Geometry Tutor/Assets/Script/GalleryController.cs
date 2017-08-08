using HoloToolkit.Unity.InputModule;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GalleryController : MonoBehaviour, ISpeechHandler, IInputClickHandler
{
    [SerializeField]
    private GameObject gallery;
    [SerializeField]
    private GameObject help;


    void Start()
    {
        SceneManager.sceneUnloaded += SceneManager_sceneUnloaded;
    }

    private void SceneManager_sceneUnloaded(Scene sceneArg)
    {
        if (sceneArg.name=="ShapeExplorer")
        {
            gallery.SetActive(true);
        }
    }

    public void OnSpeechKeywordRecognized(SpeechKeywordRecognizedEventData eventData)
    {
        if (eventData.RecognizedText == "Rotate")
        {
            StartRotate();
        }
        else if (eventData.RecognizedText == "Stop Gallery")
        {
            StopRotate();
        }
        else if (eventData.RecognizedText == "Tutor Help")
        {
            help.SetActive(true);
        }
        else if (eventData.RecognizedText == "Dismiss Help")
        {
            help.SetActive(false);
        }
        else
        {
            gallery.SetActive(false);
            GlobalKeys.SpokenCommand = eventData.RecognizedText;
            SceneLoader.Instance.LoadScene("ShapeExplorer");
        }
    }

    public void StartRotate()
    {
        StopCoroutine("RotateShape");
        StartCoroutine("RotateShape", transform);
    }

    public void StopRotate()
    {
        StopCoroutine("RotateShape");
    }

    IEnumerator RotateShape(Transform shapeTransform)
    {
        for (;;)
        {
            shapeTransform.Rotate(new Vector3(0, 1, 0));
            yield return null;
        }
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        StartRotate();
    }
}
