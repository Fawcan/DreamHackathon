using UnityEngine;
using System.Collections;

public class ColorManager : MonoBehaviour
{
    public enum Colors
    {
        RED,
        BLUE,
        YELLOW,
        ORANGE,
        PURPLE,
        GREEN,
        WHITE
    }

    [SerializeField] private Colors currentColor;
    [SerializeField] private Colors newColor;
    [SerializeField] private string currentTag;

    private Color color;

    public Colors NewColor
    {
        set { newColor = value; }
    }

    public Colors CurrentColor
    {
        get { return currentColor; }
    }


    void Start()
    {
        newColor = currentColor;
        color = ConvertColor(currentColor);
        gameObject.GetComponent<Renderer>().material.color = color;
    }


    void Update()
    {
        if (currentColor != newColor)
        {
            color = ConvertColor(newColor);
            gameObject.GetComponent<Renderer>().material.color = color;
            currentColor = newColor;

        }
        
        if(currentTag != this.gameObject.tag)
        {
            this.gameObject.tag = currentTag;
        }   
    }

    Color ConvertColor(Colors colors)
    {
        Color tempColor = Color.black;

        switch(colors)
        {
            case Colors.RED:
                tempColor = Color.red;
                currentTag = "red";
                break;
            case Colors.BLUE:
                tempColor = Color.blue;
                currentTag = "blue";
                break;
            case Colors.YELLOW:
                tempColor = Color.yellow;
                currentTag = "yellow";
                break;
            case Colors.ORANGE:
                tempColor = new Color(1, 0.65f, 0);
                currentTag = "orange";
                break;
            case Colors.PURPLE:
                tempColor = new Color(0.63f, 0.12f, 0.94f);
                currentTag = "purple";
                break;
            case Colors.GREEN:
                currentTag = "green";
                tempColor = Color.green;
                break;
            case Colors.WHITE:
                tempColor = Color.white;
                currentTag = "white";
                break;
            default:
                break;

        }

        return tempColor;
    }

}
