using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager :MonoBehaviour {

    private int tacoCount = 0;
    public TextMeshProUGUI tacoText;
    public GameObject pauseCanva;
    public Image fadeImg;

    public void Start() {
        tacoCount = 0;
        if(fadeImg != null) {
            fadeImg.gameObject.SetActive(false);
        }
    }
    void Update() {
        if(tacoText != null) {
            tacoText.text = "Tacos: " + tacoCount.ToString();
        }
    }
    public void AddTacoCount() {
        tacoCount++;
    }
    public void GameOver() {
        StartCoroutine(FadeAndGoToMenu());
    }

    IEnumerator FadeAndGoToMenu() {
        fadeImg.gameObject.SetActive(true);
        float duration = 5f;
        float time = 0f;
        Color color = fadeImg.color;

        while(time < duration) {
            time += Time.deltaTime;
            float alpha = Mathf.Clamp01(time / duration);
            fadeImg.color = new Color(color.r, color.g, color.b, alpha);
            yield return null;
        }

        SceneManager.LoadScene("MainMenu");
    }
    public void PauseGame() {
        Time.timeScale = 0f;
        pauseCanva.SetActive(true);
    }
    public void ResumeGame() {
        Time.timeScale = 1f;
        pauseCanva.SetActive(false);
    }
    public void StartGame() {
        SceneManager.LoadScene("Gameplay");
    }
    public void MainMenu() {
        SceneManager.LoadScene("MainMenu");
    }
    public void QuitGame() {
        Application.Quit();
        Debug.Log("Quit Game");
    }
}
