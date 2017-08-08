using System;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using System.IO;

public class ShapeController : MonoBehaviour
{
    private string currentShape;
    private GameObject Shape;
    private GameObject ShapeParent;
    private Text Title;
    private ShapeData[] shapeData;
    void Awake()
    {
        shapeData = JsonConvert.DeserializeObject<ShapeData[]>(File.ReadAllText(Application.streamingAssetsPath + "\\data.json"));
        ShapeParent = GameObject.FindGameObjectWithTag("ParentShape") as GameObject;
    }

    // Use this for initialization
    private void Start()
    {
        ShapeParent.transform.position = new Vector3(0, 0, Camera.main.transform.position.z + 6);
        currentShape = GlobalKeys.SpokenCommand.Split(' ')[1];
        for (int i = 0; i < shapeData.Length; i++)
        {
            if (string.Equals(shapeData[i].name, currentShape))
            {
                Title = GameObject.FindGameObjectWithTag("Data").GetComponent<Text>();

                if (Title != null)
                {
                    Title.text = currentShape + ": " + shapeData[i].description;
                }
            }
        }
        PrimitiveType shape = (PrimitiveType)Enum.Parse(typeof(PrimitiveType), currentShape);
        Shape = GameObject.CreatePrimitive(shape);
        Shape.name = "Child";
        Shape.transform.parent = ShapeParent.transform;
        Shape.transform.position = ShapeParent.transform.position;

    }
}
