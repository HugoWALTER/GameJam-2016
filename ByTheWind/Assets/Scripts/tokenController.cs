using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tokenController : MonoBehaviour {
    

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        randomToken(transform);
    }

    void randomToken(Transform scene)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform _this = transform.GetChild(i);
            if (_this.CompareTag("token") && onScreen(_this))
            {
                _this.gameObject.SetActive(true);
                _this.position = new Vector3(_this.position.x, Random.Range(-1, 3.5f), _this.position.z);
            }
            if (_this.CompareTag("obs") && onScreen(_this))
                _this.gameObject.SetActive(true);
        }
    }

    bool onScreen(Transform token)
    {
        return Camera.main.transform.position.x > token.position.x + 11;
    }
}
