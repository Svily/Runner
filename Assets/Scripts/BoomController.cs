using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomController : MonoBehaviour {



    void OnTriggerEnter(Collider collider)
    {

        if (collider.name == "Player")
        {
            
            collider.transform.SendMessage("CanDestroyBars");

            Destroy(this.gameObject);

        }

    }

}
