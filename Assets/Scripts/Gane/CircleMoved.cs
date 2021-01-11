using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMoved : MonoBehaviour
{
    private GameObject cirl;
    private Rigidbody2D cirlRB;
    public float Speed = 120.0f, DefSpeed = 120.0f, SlowedSpeed = 40.0f, FastSpeed = 150.0f, 
    timing1Phase = 4f, timing2Phase = 3f, timing3Phase = 2f, timing4Phase = 1.5f;

    [SerializeField] private int rndMoving;
    [SerializeField] private float timing;

    void Start()
    {
        cirl = GameObject.FindWithTag("Circle");
        cirlRB = cirl.GetComponent<Rigidbody2D>();

        StartCoroutine(ChaosMoving());
    }

    IEnumerator ChaosMoving()
    {
      while (true)
      {
        if(PlayerPrefs.GetInt("Stage") <= 5)
            timing = timing1Phase;
        else if(PlayerPrefs.GetInt("Stage") <= 10)
            timing = timing2Phase;
        else if(PlayerPrefs.GetInt("Stage") <= 15)
            timing = timing3Phase;
        else if(PlayerPrefs.GetInt("Stage") >= 15)
            timing = timing4Phase;

        yield return new WaitForSeconds(timing);

        rndMoving = Random.Range(1, 4);
        Speed = DefSpeed;

        if(rndMoving == 1)
        Speed = Speed * -1;
        else if(rndMoving == 2)
        Speed = SlowedSpeed;
        else if(rndMoving == 3)
        Speed = FastSpeed;

        yield return new WaitForSeconds(timing);
      }
    }

    void FixedUpdate()
    {
        cirlRB.transform.Rotate (0,0, Speed * Time.deltaTime);
    }
}
