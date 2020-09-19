using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class PlayerGamplay : MonoBehaviour {
    // Start is called before the first frame update
    public GameObject canvas;
    public GameObject cylinder;
    public LayerMask laptopCollider;
    public LayerMask cafeteria;
    public LayerMask breakroom;
    public LayerMask workshop;
    UIController ui;
    float time = 0;
    public float progress = 0;
    float rate = 0.01f;
    bool gameOver = false;

    void Start() {
        ui = canvas.GetComponent<UIController>();
    }

    // Update is called once per frame
    void Update() {
        rate = (ui.food * 0.00008f) + (ui.energy * 0.00008f) + (ui.experience * 0.00016f);
        time += Time.deltaTime;
        ui.hours = 48 - time / 4;
        if (Physics.CheckSphere(transform.position, 0.3f, laptopCollider)) {
            if (progress < 1)
                progress += rate * Time.deltaTime;
            ui.energy -= 2 * Time.deltaTime;
            ui.food -= 1 * Time.deltaTime;
            GetComponent<AudioSource>().mute = false;
        }
        else
            GetComponent<AudioSource>().mute = true;
        if (Physics.CheckSphere(transform.position, 0.3f, breakroom)) {
            if (ui.energy < 100)
                ui.energy += 3 * Time.deltaTime;
        }
        if (Physics.CheckSphere(transform.position, 0.3f, cafeteria)) {
            if (ui.food < 100)
                ui.food += 2 * Time.deltaTime;
        }
        if (Physics.CheckSphere(transform.position, 0.3f, workshop)) {
            if (ui.experience < 100)
                ui.experience += 1 * Time.deltaTime;
            ui.energy -= 1 * Time.deltaTime;
            ui.food -= 0.5f * Time.deltaTime;
        }
        if (!gameOver) {
            if (progress >= 1.0) {
                ui.win();
                gameOver = true;
            }
            if (ui.energy <= 0 || ui.food <= 0) {
                ui.die();
                gameOver = true;
            }
            if (ui.hours <= 0) {
                ui.fail();
                gameOver = true;
            }
        }
    }
}
