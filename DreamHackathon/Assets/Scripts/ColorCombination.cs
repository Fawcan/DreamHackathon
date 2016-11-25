using UnityEngine;
using System.Collections;

public class ColorCombination : MonoBehaviour
{
    [SerializeField] private ColorManager.Colors firstColor;
    [SerializeField] private ColorManager.Colors secondColor;
    [SerializeField] private ColorManager.Colors newColor;
    [SerializeField] private bool testCombine = false;

    [SerializeField] GameObject[] objectsToCombine;

    public void Combine(GameObject objOne, GameObject objTwo)
    {
        if (objOne.GetComponent<ColorManager>() != null &&
            objTwo.GetComponent<ColorManager>() != null)
        {
            
            firstColor = objOne.GetComponent<ColorManager>().CurrentColor;
            secondColor = objTwo.GetComponent<ColorManager>().CurrentColor;

            newColor = ColorCombine(firstColor, secondColor);

            objOne.GetComponent<ColorManager>().NewColor = newColor;

            Destroy(objTwo);

        }
    }


    ColorManager.Colors ColorCombine(ColorManager.Colors firstColor, ColorManager.Colors secondColor)
    {
        if (this.firstColor == secondColor)
        {
            return firstColor;
        }

        else if(firstColor == ColorManager.Colors.ORANGE || secondColor == ColorManager.Colors.ORANGE)
        {
            newColor = ColorManager.Colors.ORANGE;
        }

        else if(firstColor == ColorManager.Colors.PURPLE || secondColor == ColorManager.Colors.PURPLE)
        {
            newColor = ColorManager.Colors.PURPLE;
        }

        else if(firstColor == ColorManager.Colors.GREEN || secondColor == ColorManager.Colors.GREEN)
        {
            newColor = ColorManager.Colors.GREEN;
        }

        //If colors are red and yellow make the new color orange
        else if (firstColor == ColorManager.Colors.RED && secondColor == ColorManager.Colors.YELLOW
            || firstColor == ColorManager.Colors.YELLOW && secondColor == ColorManager.Colors.RED)
        {
            newColor = ColorManager.Colors.ORANGE;
        }

        //If colors are blue and yellow make the new color green
        else if (firstColor == ColorManager.Colors.YELLOW && secondColor == ColorManager.Colors.BLUE
            || firstColor == ColorManager.Colors.BLUE && secondColor == ColorManager.Colors.YELLOW)
        {
            newColor = ColorManager.Colors.GREEN;
        }
        //If colors are red and blue make the new color purple
        else if (firstColor == ColorManager.Colors.RED && secondColor == ColorManager.Colors.BLUE 
            || firstColor == ColorManager.Colors.BLUE && secondColor == ColorManager.Colors.RED)
        {
            newColor = ColorManager.Colors.PURPLE;
        }



            return newColor;
    }

    void Update()
    {
        if(testCombine)
        {
            Combine(objectsToCombine[0], objectsToCombine[1]);
            testCombine = false;
        }
    }
}
