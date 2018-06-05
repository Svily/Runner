using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class RandomEvents : MonoBehaviour
{


    public GameObject Tools = null;

    public GameObject CanDestroyBars = null;

	void Start ()
	{

	    

        //随机触发地面陷阱事件
        if (Random.Range(0,100) >= 99)
	    {
	        RandomBar();
        }

        int Flag = Random.Range(0, 180);
        //随机触发障碍物和道具的生成
        if (Flag >= 175)
        {
            
            RandomCanDestroyBars();

        }
        else if (Flag >= 171)
        {
            if (Random.Range(0,101) >= 70)
            {
                RandomTools();
            } 
        }

    }

    /// <summary>
    /// 生成地面陷阱事件
    /// </summary>
    void RandomBar()
    {
        switch (Random.Range(0, 4))
        {
            case 1:
                UpHighBar();
                break;
            case 2:
                UpLowBar();
                break;
            case 3:
                DownBar();
                break;

        }
    }

    /// <summary>
    /// 生成可破坏障碍物
    /// </summary>
    void RandomCanDestroyBars()
    {

        int Flag = Random.Range(0, 3);

        switch (Flag)
        {
            case 1:
                CanDestroyBars = Resources.Load("Railings") as GameObject;
                break;
            case 2:
                CanDestroyBars = Resources.Load("Tree") as GameObject;
                break;
        }
        //生成
        Instantiate(CanDestroyBars, this.transform.position + new Vector3(0, 5.45f, 0), Quaternion.identity,
            this.transform);
    }

    //高度升起地面
    void UpHighBar()
    {
        this.transform.DOMoveY(3.52f, 2f);

        //有几率生成道具
        if (Random.Range(0,100) >= 80)
        {


            //随机产生道具
            switch (Random.Range(0, 6)) {

                case 1:
                    Tools = Resources.Load("Decelate") as GameObject;
                    break;
                case 2:
                    Tools = Resources.Load("Accelate") as GameObject;
                    break;
                case 3:
                    Tools = Resources.Load("Diamond") as GameObject;
                    break;
                case 4:
                    Tools = Resources.Load("Boom") as GameObject;
                    break;
                default:
                    Tools = null;
                    break;
            }

            
            Instantiate(Tools, this.transform.position, Quaternion.identity, this.transform);
        }
    }

    //升起随机高度地面
    void UpLowBar()
    {
        this.transform.DOMoveY(Random.Range(-2.5f,2.5f), 2f);
        
    }

    //地面坍陷
    void DownBar()
    {
        GameObject go = this.transform.gameObject.transform.parent.gameObject;
        go.AddComponent<Rigidbody>();
    }

    //销毁
    void Destroy()
    {
        Destroy(this.gameObject);
    }

    //生成随机道具
    void RandomTools()
    {
        int Flag = Random.Range(0, 101);

        if (Flag >= 60)
        {
            Tools = Resources.Load("Accelate") as GameObject;
            
        }

        else if(Flag >=30)
        {
            Tools = Resources.Load("Decelate") as GameObject;
        }

        else if(Flag >=10)
        {
            Tools = Resources.Load("Diamond") as GameObject;
        }
        else
        {
            Tools = Resources.Load("Boom") as GameObject;
        }

        Instantiate(Tools, this.transform.position + new Vector3(0, Random.Range(0,101)>=80?8.45f:5.45f, 0), Quaternion.identity, this.transform);
    }
}
