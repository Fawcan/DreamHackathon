using UnityEngine;
using System.Collections;

public class ColorCombination : MonoBehaviour
{
    [SerializeField] private Color firstColor;
    [SerializeField] private Color secondColor;
    [SerializeField] private Color newColor;



    public void Combine(GameObject objOne, GameObject objTwo)
    {
        if (objOne.GetComponent<ColorManager>() != null &&
            objTwo.GetComponent<ColorManager>() != null)
        {
            firstColor = objOne.GetComponent<ColorManager>().Color;
            secondColor = objTwo.GetComponent<ColorManager>().Color;

            newColor = ColorCombine(firstColor, secondColor);

            objOne.GetComponent<ColorManager>().NewColor = newColor;

            Destroy(objTwo);

        }
    }


    Color ColorCombine(Color firstColor, Color secondColor)
    {
        if (this.firstColor == secondColor)
        {
            return firstColor;
        }

        else if (firstColor == Color.red && secondColor == Color.yellow
            || firstColor == Color.yellow && secondColor == Color.red)
        {
            newColor = new Color(255, 165, 0);
        }

        else if (firstColor == Color.yellow && secondColor == Color.blue
            || firstColor == Color.blue && secondColor == Color.yellow)
        {
            newColor = Color.green;
        }

        else if (firstColor == Color.red && secondColor == Color.blue 
            || firstColor == Color.blue && secondColor == Color.red)
        {
            newColor = new Color(128, 0, 128);
        }



            return newColor;
    }
}
