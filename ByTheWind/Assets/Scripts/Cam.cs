using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cam : MonoBehaviour {

    public GameObject canvas;
    public Button resume;
    public Button goMenu;

    private float timestamp;
    private bool pause;
    
    void Start()
    {
        pause = false;
        timestamp = (float)0.095;
        canvas.SetActive(false);
        Time.timeScale = 1;
        goMenu.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Menu");
        });
    }
    void Update()
    {
        transform.position += new Vector3(timestamp, 0, 0);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pause)
            {
                Time.timeScale = 0;
                timestamp = 0;
                pause = true;
                canvas.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                timestamp = (float)0.095;
                pause = false;
                canvas.SetActive(false);
            }
        }
        resume.onClick.AddListener(() =>
        {
            canvas.SetActive(false);
            Time.timeScale = 1;
            timestamp = (float)0.095;
            pause = false;
        });
    }
}
