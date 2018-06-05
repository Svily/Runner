using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    private Transform PauseUI;

    private bool flag = true;

    void Start()
    {


        PauseUI = GameObject.Find("PauseUI").transform;
       

    }

    public void ContinueGame()
    {

       
        if (!flag)
        {
            PauseUI.GetComponent<Canvas>().enabled = false;
            Time.timeScale = 1;
            flag = true;
        }


        


    }



    public void RestarGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    }


    public void PauseGame()
    {

        if (flag)
        {
            PauseUI.GetComponent<Canvas>().enabled = true;
            Time.timeScale = 0;
            flag = false;
        }
        else
        {
            
            PauseUI.GetComponent<Canvas>().enabled = false;
            Time.timeScale = 1;
            flag = true;
        }

   
        
 
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
