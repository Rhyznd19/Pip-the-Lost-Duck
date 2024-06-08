using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

public class UICanvas : MonoBehaviour
{
   
    public GameObject UIPause;
    public static  bool isGamePaused;
    // Start is called before the first frame update
    void Start()
    {
        if (UIPause == null)
        {
            UIPause = GameObject.Find("UIPause");
        }

        AudioManager.ContinueAudio();
    }



    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            if (isGamePaused)
            {
                ContinueGame();
            }
            else
            {
                PauseGame();

            }
        }
    }

    public  void PauseGame()
    {
        UIPause.SetActive(true);
        isGamePaused = true;
        Time.timeScale = 0f;
        AudioManager.PauseAudio();

    }

    public  void ContinueGame()
    {
        UIPause.SetActive(false);
        isGamePaused = false;
        Time.timeScale = 1;
        AudioManager.ContinueAudio();
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
