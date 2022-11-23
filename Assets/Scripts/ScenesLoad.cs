using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesLoad : MonoBehaviour
{
    public void SceneLoad(int index)
    {
        SceneManager.LoadScene(index);
        Time.timeScale = 1;
    }
    
    public void SceneExit(GameObject ExitUI)
    {
        ExitUI.SetActive(true);
    }
    
    public void ExitYes()
    {
        Application.Quit();
    }
    
    public void ExitNo(GameObject ExitUI)
    {
        ExitUI.SetActive(false);
    }

    public void PauseGame(GameObject PauseUI)
    {
        PauseUI.SetActive(true);
        Time.timeScale = 0;
    }
    
    public void ContinueGame(GameObject PauseUI)
    {
        PauseUI.SetActive(false);
        Time.timeScale = 1;
    }
}
