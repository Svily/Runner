using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBarsController : MonoBehaviour {


    /// <summary>
    /// 破坏此障碍物
    /// </summary>
    void Hit()
    {

        //添加刚体组件
        if (this.transform.GetComponent<Rigidbody>() == null)
        {
            this.transform.gameObject.AddComponent<Rigidbody>();
        }

        //this.transform.GetComponent<BoxCollider>().enabled = false;

        //添加力，模拟撞飞效果
        this.transform.GetComponent<Rigidbody>().AddForce(Random.Range(-4f,4f), Random.Range(3f, 5f), Random.Range(180f, 280f));

        //破坏障碍物，加分
        GameObject.Find("GameUI").transform.SendMessage("AddDestroyScore");

        //销毁此障碍物
        Invoke("Destroy", 1.5f);

    }

    void Destroy()
    {

        Destroy(this.gameObject);

    }
}
