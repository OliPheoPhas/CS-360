using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class game_start_button : MonoBehaviour
{
    public string sceneToLoad = "Screen_in-game";

    private void OnMouseDown()
    {
        // Load the specified scene
        SceneManager.LoadScene(sceneToLoad);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
