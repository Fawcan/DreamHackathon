using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    [SerializeField] private string[] levels; //Write Down Maps in the Editor
    [SerializeField] private int levelIndex; //Index for the levels-array, set in the Editor.
    [SerializeField] private bool levelLoaded = false;
    public bool LevelLoad
    {
        set { levelLoaded = value; }
    }

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Change to a collision instead of button-press
        if (levelLoaded)
        {
            levelLoaded = false;
            LoadNextLevel();
        }
    }

    public void LoadNextLevel()
    {
        Debug.Log("yay next level");
        try {
            SceneManager.LoadScene(levels[levelIndex]);
            levelIndex++;            
        }
        catch(System.IndexOutOfRangeException)
        {
            Debug.LogWarning("Level index " + levelIndex + " doesn't exist.");
        }
    }
}
