using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Explore : MonoBehaviour
{
    // public GameObject earth;
    public Transform earth;
    public Canvas navUI;
    public Canvas startUI;
    bool wasClicked = false;
    float timer = 0;
    void Start() { 
        // earth = earth.transform
    }

    void Update() {
        if(!wasClicked) return;
        timer += Time.deltaTime;

        Vector3 target = new Vector3(0, 0, 12);
        if(earth.position != target) {
            float speed = Time.deltaTime * Vector3.Distance(earth.position, target) * 1.6f;
            speed = Mathf.Max(0.012f, speed);
            earth.position = Vector3.MoveTowards(earth.position, target, speed);            
        } else {
            // SetActive(false) disables script --> object stops moving?
            startUI.gameObject.SetActive(false);
            navUI.gameObject.SetActive(true);
        }        

    }
    public void Click() {
        wasClicked = true;
    }
}
