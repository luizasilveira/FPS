using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseUI;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetKeyDown(KeyCode.Escape)){
        if(GameIsPaused){
          Resume();
        }else{
          Pause();
        }
      }
    }

    public void Resume(){
      pauseUI.SetActive(false);
      Time.timeScale = 1;
      GameIsPaused = false;

    }

    void Pause(){
      pauseUI.SetActive(true);
      Time.timeScale = 0;
      GameIsPaused = true;

    }

    public void Menu(){
      SceneManager.LoadScene ("Menu");

    }



}
