using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ShopControll : MonoBehaviour
{
    public GameObject PresentKnifeSkin, AppleInPrice;
    public Text Price, StatusBuying;
    public bool _isChangeApples;
    public Sprite[] allSkinsKnifeShop;

    private int currentNumberButton;

    public void ButBuyOrChangeSkin()
    {
        if(Price.text == "Selected")
        {
            StatusBuying.text = "Already Selected!";
            Invoke("StatusBuyingIsNull", 1f);
        }
        else if(Price.text == "Change")
        {
            PlayerPrefs.SetInt("KnifeSkin", currentNumberButton + 1);
            StatusBuying.text = "Changed!";
            Invoke("StatusBuyingIsNull", 2f);
        }
        else
        {
          if(PlayerPrefs.GetInt("BuyingKnifeSkin" + currentNumberButton + 1) != 1)
            if(PlayerPrefs.GetInt("Apples") >= 100)
            {
                PlayerPrefs.SetInt("Apples", PlayerPrefs.GetInt("Apples") - 100);
                PlayerPrefs.SetInt("BuyingKnifeSkin" + currentNumberButton + 1, 1);
                PlayerPrefs.SetInt("KnifeSkin", currentNumberButton + 1);
                StatusBuying.text = "Buying and Changed!";
                Invoke("StatusBuyingIsNull", 1f);
            }
          else
            {
                PlayerPrefs.SetInt("KnifeSkin", currentNumberButton + 1);
                StatusBuying.text = "Changed!";
                Invoke("StatusBuyingIsNull", 1f);
            }
        }
    }

    public void ButtonClick (int numberSkin)
    {
        PresentKnifeSkin.GetComponent<SpriteRenderer>().sprite = allSkinsKnifeShop[numberSkin];
        currentNumberButton = numberSkin;

        if(PlayerPrefs.GetInt("KnifeSkin") - (numberSkin + 1) != 0)
        {
            if(PlayerPrefs.GetInt("BuyingKnifeSkin" + currentNumberButton + 1) != 1)
            {
                Price.text = "Buy skin \n for 100";
                AppleInPrice.SetActive(true);
            }
            else
            {
                Price.text = "Change";
                AppleInPrice.SetActive(false);
            }
        }
        else
        {
            Price.text = "Selected";
            AppleInPrice.SetActive(false);
        }
    }

    void StatusBuyingIsNull()
    {
        StatusBuying.text = "";
    }
}
