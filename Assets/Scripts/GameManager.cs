using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    //距离
    public Text DistanceText;

    private int Distance;

    //分数
    private Text ScoreText;

    private int Score;

    private int AddScore = 0;

    private int MoveSpeed;

    //冲刺
    private Text EndureText;

    private float EndureTime = 0f;
        

	void Start ()
	{

	    DistanceText = GameObject.Find("Distance").transform.GetComponent<Text>();

	    ScoreText = GameObject.Find("Score").transform.GetComponent<Text>();

	    EndureText = GameObject.Find("Endure").transform.GetComponent<Text>();

	}
	
	
	void Update ()
	{

	    
        ShowUI();


    }

    void ShowUI()
    {

        MoveSpeed = (int)GameObject.Find("Player").GetComponent<PlayerController>().MoveSpeed;

        Distance = (int)GameObject.Find("Player").transform.position.z;

        DistanceText.text = "距离:" + Distance + "米";

        Score = (int)(Distance * 80 + AddScore);

        ScoreText.text = "得分:" + Score + "分";

        EndureTime = GameObject.Find("Player").transform.GetComponent<PlayerController>().EndureTime;

        if (EndureTime >= 0)
        {
            EndureText.text = "剩余时间:" + EndureTime.ToString("F1") + "S";
        }
        else
        {
            EndureText.text = null;
        }
    }

    void AddScoreNum()
    {
        this.AddScore += 100 * MoveSpeed;
    }

    void AddDestroyScore()
    {
        this.AddScore += 180 * MoveSpeed;
    }
}
