using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondController : MonoBehaviour {

    void OnTriggerEnter(Collider collider)
    {

        if (collider.name == "Player")
        {
            GameObject.Find("GameUI").transform.SendMessage("AddScoreNum");

            Destroy(this.gameObject);
        }

    }

}
