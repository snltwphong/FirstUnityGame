using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 5.0f;
    public int keys = 0;
    public TMPro.TextMeshProUGUI LiveText;
    // Start is called before the first frame update
    void Start()
    {
        LiveText.text = "Lives:" + Lives.totalLive.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, speed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, -speed * Time.deltaTime, 0);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (Lives.totalLive >0)
            {
                Lives.totalLive--;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else
            {
                SceneManager.LoadScene("MenuStartScreen");
                Lives.totalLive = 3;
            }
            
        }
        if (collision.gameObject.tag == "Door")
        {
            switch (SceneManager.GetActiveScene().name)
            {
                case "lv1":
                    SceneManager.LoadScene("lv2");
                    break;
                case "lv2":
                    if (keys == 2)
                    {
                        SceneManager.LoadScene("lv3");

                    }
                    break;

                case "lv3":
                    if (keys==2)
                    {
                        SceneManager.LoadScene("lv4");
                    }    

                    break;



            }
        }
        if (collision.gameObject.tag == "Key")
        {
            keys += 1;
            Destroy(collision.gameObject);
        }
    }
}