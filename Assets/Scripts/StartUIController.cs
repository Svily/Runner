using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class StartUIController : MonoBehaviour {

    private bool flag = false;

    private void Start()
    {
        Tweener tweener = GameObject.Find("Tips").transform.DOLocalMove(Vector3.zero, 1f);
        tweener.SetAutoKill(false);
        tweener.Pause();

    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ShowDetailUI() {

        if (!flag)
        {
            GameObject.Find("Tips").transform.DOPlayForward();
            flag = true;
        }
        else {
            GameObject.Find("Tips").transform.DOPlayBackwards();
            flag = false;
        }

    }
}
