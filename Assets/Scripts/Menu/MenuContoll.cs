using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuContoll : MonoBehaviour
{
    public Animator animator;

    public GameObject KnifeSkinsGO, KnifeSkinsGOshop;
    public Sprite[] allSkinsKnife;
    private int CurrentSkin;

    public ShopControll ShopScript;

    void Start()
    {
        ///////
        PlayerPrefs.SetInt("Apples", 1000);
        ///////////////////////////
       
        if(!PlayerPrefs.HasKey("BuyingKnifeSkin1"))
            PlayerPrefs.SetInt("BuyingKnifeSkin1", 1);

        CurrentSkin = PlayerPrefs.GetInt("KnifeSkin");
        if (!PlayerPrefs.HasKey("KnifeSkin")) 
        {
            KnifeSkinsGO.GetComponent<SpriteRenderer>().sprite = allSkinsKnife[0];
            KnifeSkinsGOshop.GetComponent<SpriteRenderer>().sprite = allSkinsKnife[0];
        }
        else
        {
            KnifeSkinsGO.GetComponent<SpriteRenderer>().sprite = allSkinsKnife[CurrentSkin - 1];
            KnifeSkinsGOshop.GetComponent<SpriteRenderer>().sprite = allSkinsKnife[CurrentSkin - 1];
        }
    }

    void Update()
    {
        if(ShopScript._isChangedSkin)
         {
             Refreshing();
             ShopScript._isChangedSkin = false;
         }
    }

    void Refreshing()
    {
        CurrentSkin = PlayerPrefs.GetInt("KnifeSkin");
        KnifeSkinsGO.GetComponent<SpriteRenderer>().sprite = allSkinsKnife[CurrentSkin - 1];
    }


    public void ButGoToShop()
    {
        animator.Play("GoShopIsMenu");
    }

    public void ButGoToMenuIsShop()
    {
        animator.Play("GoMenuIsShop");
    }

    public void ButPlayGame()
    {
        SceneManager.LoadScene(1);
    }
}
