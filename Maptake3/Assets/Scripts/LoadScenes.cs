using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start ()
    {
		    SceneManager.LoadScene("InterfaceScene", LoadSceneMode.Additive);
        SceneManager.LoadScene("PathingScene", LoadSceneMode.Additive);
        SceneManager.LoadScene("DropdownScene", LoadSceneMode.Additive);
	  }
}
