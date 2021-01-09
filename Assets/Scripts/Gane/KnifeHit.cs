using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeHit : MonoBehaviour
{
    public GameObject knife;
    public Rigidbody2D knifeRB;
    public float Speed = 100f;
    public KnifeControll trigScript;

    private GameObject newKnifeGO;
    public GameObject prefKnife;
    private int numberKnife;

    public GameManagers GMS;

    void Start()
    {
        knife = GameObject.FindWithTag("Knife");
        knifeRB = knife.GetComponent<Rigidbody2D>();
        trigScript = knife.GetComponent<KnifeControll>();
    }

    void Update()
    {
        if(Input.GetMouseButton(0) && !GMS._isWin)
        {
            knifeRB.AddForce(transform.up * Speed);
        }
        if(trigScript.newKnife)
        {
            

            numberKnife++;
            newKnifeGO = Instantiate(prefKnife, new Vector3(0, -4f, 0), Quaternion.identity)as GameObject;
            newKnifeGO.name = "Knife" + numberKnife;
            trigScript.newKnife = false;

            knife = GameObject.Find("Knife" + numberKnife);
            knifeRB = knife.GetComponent<Rigidbody2D>();
            trigScript = knife.GetComponent<KnifeControll>();
        }
    }

}
