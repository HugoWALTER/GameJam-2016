using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class BoatController : MonoBehaviour {

    public int lifes;

    public Text countText;
    public static int count;
    public GameObject Scrollctrl;
    private Scroll speed;
    private Rigidbody2D boat;
    private AudioSource audio;

    private float mass;
    private float gravity;
    private bool in_water;
    private Transform cameraTranform;
    private float tmp;

    void Start ()
    {
        lifes = 3;
        audio = GetComponent<AudioSource>();
        speed = Scrollctrl.GetComponent<Scroll>();
        count = 0;
        cameraTranform = Camera.main.transform;
        tmp = cameraTranform.position.x - transform.position.x;
        boat = GetComponent<Rigidbody2D>();
        mass = 1;
        gravity = 2;
        boat.mass = mass;
        boat.gravityScale = gravity;
        SetCountText();
    }
	

    void Update()
    {
        //print(Scrollctrl.)
        transform.position = new Vector3 (cameraTranform.position.x - tmp, transform.position.y, transform.position.z);
        //transform.position = Vector3.right * cameraTranform.position.x;
        getBounce();
        
    }
    void LateUpdate()
    {

    }

    void getBounce()
    {
        // Trigger when press Space key
        if (Input.GetKey("space"))
        {
            if (mass < 40 && in_water)
            {
                gravity = 2;
                mass += (float)1;            
            }
            if (mass < 7 && !in_water)
            {
                mass = 1;
                gravity += (float)1;
            }

        }


        // Trigger when keyup Space key
        if (Input.GetKeyUp("space"))
        {
            mass = 1;
            gravity = 2;
        }

        // "Map" values to Unity
        boat.gravityScale = gravity;
        boat.mass = mass;       
    }

    void OnTriggerEnter2D(Collider2D other)
    {
       // if (other.gameObject.CompareTag("Coin"))
           // other.gameObject.SetActive(false);

        if (other.gameObject.CompareTag("MainCamera"))
            in_water = true;
        if (other.gameObject.CompareTag("token"))
        {
            ++count;
            SetCountText();
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("obs"))
        {
            audio.Play();
            --lifes;
            SetCountText();
            other.gameObject.SetActive(false);
        }
    }

    void OnTriggerExit2d(Collider2D other)
    {
        if (other.gameObject.CompareTag("MainCamera"))
            in_water = false;
    }

    void SetCountText()
    {
     //   if (((count > 0) && (count < 31)) && (count % 5) == 0)
         if (speed.paralaxSpeed > -8)   
            speed.paralaxSpeed -= (float)0.035;
        countText.text = "Score: " + count.ToString();

        if (lifes == 0)
            SceneManager.LoadScene("game over");
    

        for (int i = 0; i < Camera.main.transform.childCount; i++)
            Camera.main.transform.GetChild(i).gameObject.SetActive((i) < lifes);
    }
}
