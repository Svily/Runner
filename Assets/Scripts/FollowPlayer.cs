using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public Transform PlayerTransform;

    //摄像机水平距离
    public float distanceH;

    //摄像机垂直距离
    public float distanceV;

    //摄像机旋转速度
    public float smoothSpeed;


    void Start ()
	{

	   InitCamera();

	}
	
	
	void LateUpdate ()
	{

	    CameraFollow();


	}

    void InitCamera()
    {
        //初始化参数
        distanceH = 6f;
        distanceV = 3f;
        smoothSpeed = 2.5f;

        //获取player transform组件
        PlayerTransform = GameObject.Find("Player").transform;
    }

    void CameraFollow()
    {
        //设置速度与人物相同
        if (GameObject.Find("Player").GetComponent<PlayerController>().MoveSpeed >= 15f )
        {
            distanceH = 0f;
        }

        if (GameObject.Find("Player").GetComponent<PlayerController>().MoveSpeed >= 25f)
        {
            smoothSpeed = 2.5f;

            if (GameObject.Find("Player").GetComponent<PlayerController>().MoveSpeed > 40f)
            {
                smoothSpeed = 3f;
            }
        }

        //设置摄像机位置
        Vector3 nextPostion = PlayerTransform.forward * -1 * distanceH + PlayerTransform.up * distanceV + PlayerTransform.position;

        //移动摄像机
        this.transform.position = Vector3.Lerp(this.transform.position, nextPostion, smoothSpeed * Time.deltaTime);

        //摄像机朝向人物
        this.transform.LookAt(PlayerTransform);
    }
}
