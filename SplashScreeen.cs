using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreeen : MonoBehaviour {


    public string SceneToLoad;

    public int SecTillLoad;

	// Use this for initialization
	void Start () {
        Invoke("OpenNextScene",SecTillLoad);
	}
	

    void OpenNextScene()
    {
        SceneManager.LoadScene(SceneToLoad);
    }
	// Update is called once per frame
	void Update () {
		
	}
}
