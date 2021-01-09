using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagers : MonoBehaviour
{
    public Text Apples, StageNumber, Score;
    public int rndApple, rndPosApple, rndHits;
    private GameObject newApple;
    public GameObject prefApple, circle;
    public int countHits;
    private int curHits;

    private bool Stoped;
    public GameObject[] kStage;

    public bool _isDead;
    public GameObject DeadCanvas;

    public Animator CircleDestroy;
    private GameObject[] AllKnifes;

    void Start()
    {
        if (!PlayerPrefs.HasKey("Stage")) 
            {
                PlayerPrefs.SetInt("Stage", 1);
            }

        rndHits = Random.Range(3, 7);
            for(int i = 0; i < rndHits; i++)
            {
                kStage[i].SetActive(true);
            }

        curHits = countHits;

        rndApple = Random.Range(1, 5);
        rndPosApple = Random.Range(1, 4);
        if(rndApple == 1)
        {
        if(rndPosApple == 1)
        newApple = Instantiate(prefApple, new Vector3(circle.transform.localPosition.x, circle.transform.localPosition.y + 1.6f, 0), transform.rotation, circle.transform)as GameObject;
        else if(rndPosApple == 2){
        newApple = Instantiate(prefApple, new Vector3(circle.transform.localPosition.x + 1.5f, circle.transform.localPosition.y, 0), transform.rotation, circle.transform)as GameObject;
        newApple.transform.Rotate (0,0, -100f);}
        else if(rndPosApple == 3){
        newApple = Instantiate(prefApple, new Vector3(circle.transform.localPosition.x - 1.5f, circle.transform.localPosition.y, 0), transform.rotation, circle.transform)as GameObject;
        newApple.transform.Rotate (0,0, 100f);}
        }
        //Quaternion.identity
        
    }

    void Update()
    {
        Apples.text = PlayerPrefs.GetInt("Apples").ToString();
        StageNumber.text = "Stage: " + PlayerPrefs.GetInt("Stage");
        Score.text = PlayerPrefs.GetInt("TemporaryScore").ToString();

            if(countHits >= rndHits && !Stoped)
            {
                Stoped = true;
                
                AllKnifes = GameObject.FindGameObjectsWithTag("Knife");
                for(int d = 0; d < rndHits; d++)
                {
                    Destroy(AllKnifes[d]);
                }
                if(newApple != null)
                Destroy(newApple);

                
                //Destroy(circle);
                PlayerPrefs.SetInt("Stage", PlayerPrefs.GetInt("Stage") + 1);

                CircleDestroy.Play("WoodCircle1Brocken");
                
            }
        if(curHits < countHits)
        {
            Color GreyKnife = new Color(0, 0, 0, 255);
            int a = rndHits - countHits;
            kStage[a].GetComponent<SpriteRenderer>().color = GreyKnife;
            curHits = countHits;
        }

        if(_isDead)
            DeadCanvas.SetActive(true);
        
    }

    public void ButRestart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
        
    }
    public void ButGoToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
