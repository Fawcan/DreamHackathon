using UnityEngine;
using System.Collections;

public class DontDestroyOnLoad : MonoBehaviour {
    static DontDestroyOnLoad manager = null;
	// Use this for initialization
	void Awake ()
    {
        DontDestroyOnLoad(this.gameObject);
        if(manager == null)
        {
            manager = this;
        }
        else if(manager != null && manager != this)
        {
            Destroy(gameObject);
        }
	}

}
