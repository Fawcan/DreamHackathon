using UnityEngine;
using System.Collections;

public class ColorManager : MonoBehaviour
{
    [SerializeField] private Color currentColor;
    [SerializeField] private Color newColor;

    public Color NewColor
    {
        set { newColor = value; }
    }

    public Color Color
    {
        get { return currentColor; }
    }


    void Start()
    {
        gameObject.GetComponent<Renderer>().material.color = currentColor;
    }


    void Update()
    {
        if (currentColor != newColor)
        {
            gameObject.GetComponent<Renderer>().material.color = newColor;
            currentColor = newColor;
        }   
    }

}
