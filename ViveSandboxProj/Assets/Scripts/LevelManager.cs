using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    [SerializeField] private string[] levels; //Write Down Maps in the Editor
    [SerializeField] private int levelIndex; //Index for the levels-array, set in the Editor.
    [SerializeField] private bool levelLoaded = false;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Change to a collision instead of button-press
        if (!levelLoaded)
        {
            levelLoaded = true;
            LoadNextLevel();
        }
    }

    public void LoadNextLevel()
    {
        levelIndex++;
        Debug.Log("yay next level");
        SceneManager.LoadScene(levels[levelIndex]);
    }
}
