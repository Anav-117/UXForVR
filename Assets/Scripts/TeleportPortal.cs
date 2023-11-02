using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPortal : MonoBehaviour
{

    public GameObject Spot;
    public GameObject PlayerController;

    Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        
        pos = transform.position;

    }    


    // Update is called once per frame
    void Update()
    {

        if (gameObject.GetComponent<OVRGrabbable>().isGrabbed) {
            // Debug.Log("PLAYER CONTROLLER - " + PlayerController.name);
            // Debug.Log(Spot.transform.position);
            PlayerController.transform.position = Spot.transform.position;
            //Debug.Log("PLAYER POSITION - " + PlayerController.transform.position);
        }
        else {
            transform.position = pos;
        }
    }
}
