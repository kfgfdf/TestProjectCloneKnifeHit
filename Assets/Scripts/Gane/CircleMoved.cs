using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMoved : MonoBehaviour
{
    private GameObject cirl;
    private Rigidbody2D cirlRB;
    public float Speed = 120.0f, DefSpeed = 120.0f, SlowedSpeed = 20.0f, FastSpeed = 150.0f;

    private int rndMoving;

    void Start()
    {
        cirl = GameObject.FindWithTag("Circle");
        cirlRB = cirl.GetComponent<Rigidbody2D>();

        if(PlayerPrefs.GetInt("Stage") <= 5)
        Invoke("ChangeRotation", 0.3f);
        else if(PlayerPrefs.GetInt("Stage") <= 10)
        Invoke("ChangeRotation", 0.15f);
        else if(PlayerPrefs.GetInt("Stage") <= 15)
        Invoke("ChangeRotation", 0.05f);
        else if(PlayerPrefs.GetInt("Stage") >= 15)
        Invoke("ChangeRotation", 0.02f);
    }

    void FixedUpdate()
    {
        cirlRB.transform.Rotate (0,0, Speed * Time.deltaTime);
    }
    
    void ChangeRotation()
    {
        rndMoving = Random.Range(1, 4);

        if(rndMoving == 1)
        Invoke("FlipRotation", 2);
        else if(rndMoving == 2)
        Invoke("SlowedRotation", 1);
        else if(rndMoving == 3)
        Invoke("BoostRotation", 1);
    }

    void FlipRotation()
    {
        Speed = Speed * -1;
        Invoke("ChangeRotation", 0.5f);
    }

    void SlowedRotation()
    {
        Speed = SlowedSpeed;
        Invoke("DeffoltRotation", 0.5f);
    }

    void BoostRotation()
    {
        Speed = FastSpeed;
        Invoke("DeffoltRotation", 0.5f);
    }

    void DeffoltRotation()
    {
        Speed = DefSpeed; //DEFOLTSPEED
        Invoke("ChangeRotation", 0.4f);
    }
}
