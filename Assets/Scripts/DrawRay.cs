using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawRay : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public GameObject Line;

    public bool hit = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //Ray r = new Ray(transform.position, transform.forward);

        // lineRenderer = GetComponent<LineRenderer>();
        // lineRenderer.SetPosition(0, transform.position);
        // lineRenderer.SetPosition(1,transform.position + 100*transform.forward);

        //Line.transform.localPosition = new Vector3(0.0f, 50.0f, 0.0f);
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger)) {
            //Line.SetActive(true);
            Line.GetComponent<MeshCollider>().enabled = true;
            hit = true;
        }
        //Line.GetComponent<MeshCollider>().enabled = false;
        // else if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger)){
        //     //Line.GetComponent<MeshCollider>().enabled  = false;
        //     hit = false;
        //     //Line.SetActive(false);
        // }

        //Debug.Log(Line.transform.localScale);

        // RaycastHit hit;

        // if (Physics.Raycast(r, out hit, 100)) {
        //     Debug.DrawLine(transform.position, hit.position, Color.white, 2.5f);
        // }

    }
}
