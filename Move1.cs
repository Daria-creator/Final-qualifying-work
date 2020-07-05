using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Move1 : MonoBehaviour
{

    public Rigidbody rb;
    public float angle;
    public float speed;
    public int directionInput;
    public float money; 

    public static bool paused = false;
    public static bool started = false;
    public static bool trigger = false;
    public static bool speed2x = false;

	public GameObject panel;
    public GameObject panel1;
    public GameObject panel2;
    public GameObject button;
    public GameObject image1;
    public GameObject image2;
    public GameObject image3;
    public GameObject text;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        
       if(!paused)
       {
           if(started)
        {
                if(!trigger){
            button.SetActive(true);
            image1.SetActive(true);
            image2.SetActive(true);
            image3.SetActive(true);
            panel2.SetActive(false);
                if(rb.transform.position.x < 700)
                {        
                    Moving();
                    if(rb.transform.position.z == -14)
                    {
                        if (directionInput > 0)
                        {
                            Flip();
                            money = money + 1;                          
                        }
                    }

                    if(rb.transform.position.z == -6)
                    {
                        if (directionInput < 0)
                        {
                            Flip(); 
                            money = money + 1;              
                        }
                    }
                }  
                else
                    {
                        button.SetActive(false);
                        image1.SetActive(false);
                        image2.SetActive(false);
                        image3.SetActive(false);
                        panel1.SetActive(true);                        
                        started = false;
                    }
            }
            else if (trigger)
            {
                Debug.Log("trigger");
                button.SetActive(false);
                image1.SetActive(false);
                image2.SetActive(false);
                image3.SetActive(false);
                panel1.SetActive(true);
                started = false;
            }
            else
            {
                button.SetActive(false);
                image1.SetActive(false);
                image2.SetActive(false);
                image3.SetActive(false);
            }
        }
       }
            else
                {
                    button.SetActive(false);
                    panel.SetActive(true);
                    image1.SetActive(false);
                    image2.SetActive(false);
                    image3.SetActive(false);
                    paused = true; 
                }  
    }

    public void Move(int InputAxis)
    {
        directionInput = InputAxis;   
    }

    void Flip()
    {
        transform.position = new Vector3(transform.position.x , transform.position.y, transform.position.z + angle * directionInput );
        directionInput = 0;
    }


    void Moving()
    {
        if (speed2x) 
        {
            speed = speed * 2;
            Debug.Log(speed);
            transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z );
            speed2x = false;
        }
        else{
            transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z );
        }
       }

    public void PauseButton()
    { 

        if(paused) 
           {
            panel.SetActive(false);
            paused = false;
           }
        else 
        {
            panel.SetActive(true);
            paused = true; 
        }
    }

    public void StartButton()
    {
        if(started)
        {
            panel2.SetActive(false);
        }
        else
        {
            button.SetActive(false);
            image1.SetActive(false);
            image2.SetActive(false);
            panel2.SetActive(true);
            started = true;
        }
    }

    public void SpeedButton()
    {
        speed2x = true;
    }

    
  void OnTriggerEnter()
    {  
     trigger = true;
    } 

    public void MenuButton1()
        {
            panel.SetActive(false);
            trigger = false;
            SceneManager.LoadScene("Menu");
            Debug.Log("Menu");
        } 
}
