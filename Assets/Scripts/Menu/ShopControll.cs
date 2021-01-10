using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ShopControll : MonoBehaviour
{
    public GameObject PresentKnifeSkin, AppleInPrice;
    public Text Price, StatusBuying;
    public bool _isChangeApples;
    public bool _isChangedSkin;
    public Sprite[] allSkinsKnifeShop;

    private int currentNumberButton, ChangeTextInt;

    public void ButBuyOrChangeSkin()
    {
        //if(Price.text == "Selected")
        if(ChangeTextInt == 0)
        {
            StatusBuying.text = "Already Selected!";
            Invoke("StatusBuyingIsNull", 2f);
        }
        //else if(Price.text == "Change")
        else if(ChangeTextInt == 1)
        {
            PlayerPrefs.SetInt("KnifeSkin", currentNumberButton + 1);
            _isChangedSkin = true;
            StatusBuying.text = "Changed!";
            Invoke("StatusBuyingIsNull", 2f);
        }
        else if(ChangeTextInt == 2)
        {
          if(PlayerPrefs.GetInt("BuyingKnifeSkin" + currentNumberButton + 1) != 1)
            if(PlayerPrefs.GetInt("Apples") >= 100)
            {
                PlayerPrefs.SetInt("Apples", PlayerPrefs.GetInt("Apples") - 100);
                _isChangeApples = true;
                PlayerPrefs.SetInt("BuyingKnifeSkin" + currentNumberButton + 1, 1);
                PlayerPrefs.SetInt("KnifeSkin", currentNumberButton + 1);
                _isChangedSkin = true;
                StatusBuying.text = "Buying and Changed!";
                Invoke("StatusBuyingIsNull", 2f);
            }
          else
            {
                PlayerPrefs.SetInt("KnifeSkin", currentNumberButton + 1);
                _isChangedSkin = true;
                StatusBuying.text = "Changed!";
                Invoke("StatusBuyingIsNull", 2f);
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
                ChangeTextInt = 2;
            }
            else
            {
                Price.text = "Change";
                AppleInPrice.SetActive(false);
                ChangeTextInt = 1;
            }
        }
        else
        {
            Price.text = "Selected";
            AppleInPrice.SetActive(false);
            ChangeTextInt = 0;
        }
    }

    void StatusBuyingIsNull()
    {
        StatusBuying.text = "";
    }
}
