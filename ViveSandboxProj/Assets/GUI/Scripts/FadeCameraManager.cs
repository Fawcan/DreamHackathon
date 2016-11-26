using UnityEngine;
using System.Collections;

public class FadeCameraManager : MonoBehaviour
{
    public Texture2D fadeOutTexture;
    [SerializeField] private float fadeSpeed = 0.8f;
    [SerializeField] private int drawDepth = -1000;
    [SerializeField] private float alpha = 1.0f;
    [SerializeField] private int fadeDirection = -1;

    public bool loadingLevel;
    [SerializeField]
    public LevelManager levelManager;



    ////void Start()
    ////{
    ////    DontDestroyOnLoad(gameObject);
    ////}


    public void OnGUI()
    {
        alpha += fadeDirection * fadeSpeed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);

        if(fadeDirection == 1 && Mathf.Approximately(alpha,1) && !loadingLevel)
        {
            loadingLevel = true;
            levelManager.LoadNextLevel();
        }

    }

    public float BeginFade(int direction)
    {
        fadeDirection = direction;
        return (fadeSpeed);
    }

    public void OnLevelWasLoaded()
    {
        BeginFade(-1);
        loadingLevel = false;

    }

    





}
