using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject hourBar;
    public GameObject hourText;
    public float hours = 48;
    public GameObject energyBar;
    public GameObject energyText;
    public float energy;
    public GameObject foodBar;
    public GameObject foodText;
    public float food;
    public GameObject experienceBar;
    public GameObject experienceText;
    public float experience;
    public GameObject winScreen;
    public GameObject deathScreen;
    public GameObject failScreen;

    void Start() {
    }

    public void win() {
        winScreen.SetActive(true);
    }
    public void die() {
        deathScreen.SetActive(true);
    }
    public void fail() {
        failScreen.SetActive(true);
    }

    // Update is called once per frame
    void Update() {
        hourBar.GetComponent<RectTransform>().anchorMax = new Vector2(hours/48, 1);
        hourText.GetComponent<TMP_Text>().text = System.Math.Round(hours, 1).ToString();
        energyBar.GetComponent<RectTransform>().anchorMax = new Vector2(energy / 100, 1);
        energyText.GetComponent<TMP_Text>().text = System.Math.Round(energy).ToString();
        foodBar.GetComponent<RectTransform>().anchorMax = new Vector2(food / 100, 1);
        foodText.GetComponent<TMP_Text>().text = System.Math.Round(food).ToString();
        experienceBar.GetComponent<RectTransform>().anchorMax = new Vector2(experience / 100, 1);
        experienceText.GetComponent<TMP_Text>().text = System.Math.Round(experience).ToString();
    }
}
