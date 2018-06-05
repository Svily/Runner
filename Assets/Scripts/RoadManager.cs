using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{


    public GameObject RoadTemplate;

    public Vector3 RodePostion;

    /// <summary>
    /// 生成道路
    /// </summary>
    /// <param name="collider"></param>
    void OnTriggerEnter(Collider collider)
    {
        if (collider.name == "Player")
        {

            RodePostion = this.transform.position;

            int i = 1;

            //随机生成道路模板
            switch (i)
            {
                case 1:
                    RoadTemplate = Resources.Load("RoadTemplates" + i) as GameObject;
                    break;
            }


            Instantiate(RoadTemplate, RodePostion + new Vector3(0, 0, 34.9f), Quaternion.identity);

            //销毁
            Invoke("Destory",15f);
        }
    }

    void Destory()
    {
        GameObject.Destroy(this.gameObject);
    }
}
