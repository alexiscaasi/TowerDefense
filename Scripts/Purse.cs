using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Purse : MonoBehaviour
{
    public static float coins = 0;
    public Text score;

    void Start() {
        score = GetComponent<Text>();
    }

    void Update() {
        score.text = coins.ToString("0000");
    }
}
