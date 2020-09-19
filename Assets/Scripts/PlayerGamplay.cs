using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGamplay : MonoBehaviour {
    // Start is called before the first frame update
    public GameObject canvas;
    public GameObject laptop;
    UIController ui;
    float time = 0;
    float rate = 0.01f;

    void Start() {
        ui = canvas.GetComponent<UIController>();
    }

    // Update is called once per frame
    void Update() {
        time += Time.deltaTime;
        Console.WriteLine(Time.deltaTime);
        ui.hours = 48 - time / 60;
    }
}
