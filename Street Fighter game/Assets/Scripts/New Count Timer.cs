using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class NewCountTimer : MonoBehaviour
{
    public TextMeshProUGUI countdownText;
    public float timeRemaining = 60f;
    public string sceneToLoad = "Screen_Start_Menu";

    void Start()
    {
        RectTransform rt = countdownText.GetComponent<RectTransform>();
        rt.anchorMin = new Vector2(0.5f, 1f);
        rt.anchorMax = new Vector2(0.5f, 1f);
        rt.pivot = new Vector2(0.5f, 1f);
        rt.anchoredPosition = new Vector2(0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime; // Decrease the time remaining based on the frame time
            countdownText.text = string.Format("{0:0}", timeRemaining);
        }
        else
        {
            timeRemaining = 0f; // Ensure the timer doesn't go below 0
            // Handle timer expiration (e.g., end the game, trigger an event, etc.)
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
