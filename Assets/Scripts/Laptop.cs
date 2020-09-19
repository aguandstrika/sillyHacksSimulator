using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laptop : MonoBehaviour {
    // Start is called before the first frame update
    public GameObject progressBar;
    Transform laptopTransform;
    public float progress = 0;
    float startx;
    float startwidth;
    void Start() {
        laptopTransform = progressBar.transform;
        startx = laptopTransform.localPosition.x;
        startwidth = laptopTransform.localScale.x;
    }

    // Update is called once per frame
    void Update() {
        laptopTransform.localScale = new Vector3(progress * startwidth, 1, laptopTransform.localScale.z);
        laptopTransform.localPosition = new Vector3(startx + (startwidth - (progress * startwidth))*5,laptopTransform.localPosition.y, laptopTransform.localPosition.z);
    }
}
