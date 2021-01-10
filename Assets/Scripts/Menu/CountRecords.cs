using UnityEngine;
using UnityEngine.UI;

public class CountRecords : MonoBehaviour
{
    public Text Score, Apples, Apples2, Stage;
    public ShopControll ShopScript;

    void Start()
    {
        Apples.text = PlayerPrefs.GetInt("Apples").ToString();
        Score.text = "Score " + PlayerPrefs.GetInt("RecordScore").ToString();
        Stage.text = "Stage " + PlayerPrefs.GetInt("RecordStage").ToString();
        Apples2.text = PlayerPrefs.GetInt("Apples").ToString();
    }

    void Update()
    {
        if(ShopScript._isChangeApples)
        {
            ChangeApples();
            ShopScript._isChangeApples = false;
        }
    }

    void ChangeApples()
    {
        Apples.text = PlayerPrefs.GetInt("Apples").ToString();
        Apples2.text = PlayerPrefs.GetInt("Apples").ToString();
    }
}
