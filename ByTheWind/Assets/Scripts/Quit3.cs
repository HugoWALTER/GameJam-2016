using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Quit3 : MonoBehaviour {

    public Button restartBtn;
    public Button backtoBtn;
    // Use this for initialization
    void Start () {
        restartBtn.onClick.AddListener(() => { SceneManager.LoadScene("Name"); });
        backtoBtn.onClick.AddListener(() => { SceneManager.LoadScene("la bonne save"); });
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
