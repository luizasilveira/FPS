using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    void Awake()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void OnPlay () {
		    SceneManager.LoadScene ("Game");
    }

    public void Instruct(){
      SceneManager.LoadScene ("Instruct");
    }


}
