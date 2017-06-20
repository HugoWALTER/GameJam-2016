using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Quit : MonoBehaviour
{
    public Text scoring;
    public Button restartBtn;
    public Button backtoBtn;
    public Button ragequitBtn;
    // Use this for initialization
    void Start()
    {
        scoring.text = "Score: " + BoatController.count.ToString();
        restartBtn.onClick.AddListener(() => { SceneManager.LoadScene("Main"); });
        backtoBtn.onClick.AddListener(() => { SceneManager.LoadScene("Menu"); });
        ragequitBtn.onClick.AddListener(() => { Application.Quit(); });
    }
    
}
