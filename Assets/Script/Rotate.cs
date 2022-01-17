using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotateSpeed = 4f;
    public int longIndex = -1;
    public List<float> longs = new List<float>();
    void Start() { }

    void Update() {
        if(longIndex == -1) {
            transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
        } else {
            float p = longs[longIndex];
            float z = transform.localEulerAngles.z;
            float f = Mathf.Sqrt(Mathf.Abs(z - (p % 360)));
            if(f > 1f) {
                if(f < Mathf.Sqrt(180)) f = -f;
                transform.Rotate(0, 0, f * Time.deltaTime * 12);
            }
        }
    }

    public void ScrollItems(bool dir) {
        if(dir) longIndex++;
        else longIndex--;
        longIndex = Mathf.Clamp(longIndex, 0, longs.Count - 1);
        Debug.Log(dir);
    }
}