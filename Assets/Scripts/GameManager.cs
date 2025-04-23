using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager :MonoBehaviour {

    private int tacoCount = 0;
    public TextMeshProUGUI tacoText;

    void Update() {

        tacoText.text = "Tacos: " + tacoCount.ToString();
    }
    public void AddTacoCount() {
        tacoCount++;
    }
}
