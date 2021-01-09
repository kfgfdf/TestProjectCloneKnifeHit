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
    public GameObject prefKnifeDeffolt;
    private int numberKnife;

    public GameManagers GMS;

    private bool _ButtonDown, _isAttack;

    public float AttackSpeed = 0.2f; // ! < 0.2f

    public GameObject[] AllSkinsKnife;
    private GameObject CurrentSkinKnife;
    private int numberSkinKnife;

    void Start()
    {
        PlayerPrefs.SetInt("KnifeSkin", 2);

        numberSkinKnife = PlayerPrefs.GetInt("KnifeSkin");

        if (!PlayerPrefs.HasKey("KnifeSkin")) 
            CurrentSkinKnife = prefKnifeDeffolt;
        else if(PlayerPrefs.GetInt("KnifeSkin") == 1)
            CurrentSkinKnife = prefKnifeDeffolt;
        else
            CurrentSkinKnife = AllSkinsKnife[numberSkinKnife - 2];

        newKnifeGO = Instantiate(CurrentSkinKnife, new Vector3(0, -4.2f, 0), Quaternion.identity)as GameObject;

        knife = GameObject.FindWithTag("Knife");
        knifeRB = knife.GetComponent<Rigidbody2D>();
        trigScript = knife.GetComponent<KnifeControll>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !GMS._isWin && !_isAttack)
            _ButtonDown = true;
        
        if(trigScript.newKnife)
        {
            

            numberKnife++;
            newKnifeGO = Instantiate(CurrentSkinKnife, new Vector3(0, -4.2f, 0), Quaternion.identity)as GameObject;
            newKnifeGO.name = "Knife" + numberKnife;
            trigScript.newKnife = false;

            knife = GameObject.Find("Knife" + numberKnife);
            knifeRB = knife.GetComponent<Rigidbody2D>();
            trigScript = knife.GetComponent<KnifeControll>();
        }
    }

    void FixedUpdate()
    {
        if(_ButtonDown)
        {
            _ButtonDown = false;
            _isAttack = true;
            knifeRB.AddForce(transform.up * Speed);
            Invoke("AttackFalse", AttackSpeed); // ! < 0.2f
        }
    }

    void AttackFalse()
    {
        _isAttack = false;
    }

}
