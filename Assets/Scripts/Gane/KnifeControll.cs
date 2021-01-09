using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeControll : MonoBehaviour
{
    public GameObject circle, GameManag, MCanvas;
    public bool newKnife;
    public GameManagers hitsScript;
    void Start()
    {
        
        circle = GameObject.FindWithTag("Circle");
        GameManag = GameObject.Find("GameManager");
        hitsScript = GameManag.GetComponent<GameManagers>();
        MCanvas = GameObject.Find("MainCanvas");
    }

    void OnCollisionEnter2D (Collision2D other)
    {
        if(other.gameObject.tag == "Circle")
        {
            hitsScript.countHits++;

            PlayerPrefs.SetInt("TemporaryScore", PlayerPrefs.GetInt("TemporaryScore") + 1);
            transform.parent = circle.transform;
            newKnife = true;

            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY 
            | RigidbodyConstraints2D.FreezeRotation;
            
        }
        if(other.gameObject.tag == "Knife" || other.gameObject.tag == "KnifeStatic")
        {
            hitsScript._isDead = true;
            MCanvas.SetActive(false);
            Time.timeScale = 0;

            if(PlayerPrefs.GetInt("RecordStage") < PlayerPrefs.GetInt("Stage"))
                PlayerPrefs.SetInt("RecordStage", PlayerPrefs.GetInt("Stage"));

            PlayerPrefs.SetInt("Stage", 1);

            if(PlayerPrefs.GetInt("TemporaryScore") > PlayerPrefs.GetInt("RecordScore"))
                PlayerPrefs.SetInt("RecordScore", PlayerPrefs.GetInt("TemporaryScore"));

            PlayerPrefs.SetInt("TemporaryScore", 0);
        }
    }
}
