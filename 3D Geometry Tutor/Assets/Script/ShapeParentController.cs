using System.Collections;
using UnityEngine;

public class ShapeParentController : MonoBehaviour
{
    Transform[] childTransforms;
    Transform childTransform;
    public void GoBack()
    {
        SceneLoader.Instance.UnloadScene("ShapeExplorer");
    }

    public void StartRotate()
    {
        childTransforms = gameObject.GetComponentsInChildren<Transform>();
        foreach (var child in childTransforms)
        {
            if (child.gameObject.name == "Child")
            {
                childTransform = child;
            }
        }
        if (childTransform != null)
        {
            StopCoroutine("RotateShape");
            StartCoroutine("RotateShape", childTransform);
        }

    }

    public void StopRotate()
    {
        StopCoroutine("RotateShape");
    }

    IEnumerator RotateShape(Transform shapeTransform)
    {
        for (;;)
        {
            shapeTransform.Rotate(1, 1, 1);
            yield return null;
        }
    }
}
