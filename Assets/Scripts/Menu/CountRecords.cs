using UnityEngine;
using UnityEngine.UI;

public class CountRecords : MonoBehaviour
{
    public Text Score, Apples, Stage;
    void Start()
    {
        Apples.text = PlayerPrefs.GetInt("Apples").ToString();
        Score.text = "Score" + PlayerPrefs.GetInt("RecordScore").ToString();
        Stage.text = "Stage" + PlayerPrefs.GetInt("RecordStage").ToString();
    }

    void Update()
    {
        
    }
}
