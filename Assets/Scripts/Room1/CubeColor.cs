using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeColor : MonoBehaviour
{
    // Start is called before the first frame update
    Color originalColor;
    public bool hit;
    void Awake()
    {
        originalColor = gameObject.GetComponent<Renderer>().material.color;
        hit = false;
    }
    private void OnTriggerEnter(Collider other) {
        hit = true;
    }

    public void Blink() {
        StartCoroutine(Delay());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Delay()
    {
        gameObject.GetComponent<Renderer>().material.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<Renderer>().material.color = originalColor;
    }
}
