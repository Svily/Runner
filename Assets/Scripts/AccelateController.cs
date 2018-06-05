using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class AccelateController : MonoBehaviour {

    /// <summary>
    /// 加速或减速
    /// </summary>
    /// <param name="collider"></param>
    void OnTriggerEnter(Collider collider)
    {
        if (collider.name == "Player")
        {

            if (this.gameObject.tag == "Accelate")
            {
                collider.transform.SendMessage("AccelateSpeed");
            }
            else
            {
                collider.transform.SendMessage("DecelateSpeed");
            }
            

            Destroy(this.transform.parent.gameObject);

        }

    }


}
