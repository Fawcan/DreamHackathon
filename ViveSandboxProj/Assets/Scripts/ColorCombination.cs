using UnityEngine;
using System.Collections;

public class ColorCombination : MonoBehaviour
{
    [Tooltip("Do not change the values in these except for testing")]
    [SerializeField] private ColorManager.Colors firstColor;
    [Tooltip("Do not change the values in these except for testing")]
    [SerializeField] private ColorManager.Colors secondColor;
    [Tooltip("Do not change the values in these except for testing")]
    [SerializeField] private ColorManager.Colors newColor;
    [SerializeField] private bool testCombine = false;
    [SerializeField] private bool alreadyDead = false;

    [SerializeField] GameObject[] objectsToCombine;

    [SerializeField] private string[] tags;
    

    private void StartCombine(GameObject thisObj, GameObject otherObj)
    {
        Debug.Log("Starting to combine objects");
    
        if (thisObj.GetComponent<ColorManager>() != null &&
            otherObj.GetComponent<ColorManager>() != null)
        {
            
            firstColor = thisObj.GetComponent<ColorManager>().CurrentColor;
            secondColor = otherObj.GetComponent<ColorManager>().CurrentColor;

            newColor = ColorCombine(firstColor, secondColor);

            thisObj.GetComponent<ColorManager>().NewColor = newColor;

            if(!alreadyDead)
            {
                ColorCombination other = otherObj.GetComponent<ColorCombination>();
                if(other != null)
                {
                    other.alreadyDead = true;
                    Destroy(otherObj);
                }
            }


        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("colliding");
        if(System.Array.IndexOf(tags, collision.gameObject.tag) != -1)
        {
            Debug.Log("checking tags");
            StartCombine(this.gameObject, collision.gameObject);
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
}
