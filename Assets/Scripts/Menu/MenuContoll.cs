using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuContoll : MonoBehaviour
{
    public Animator animator;

    public GameObject KnifeSkinsGO, KnifeSkinsGOshop;
    public Sprite[] allSkinsKnife;
    private int CurrentSkin;

    void Start()
    {
        ///////
       ///// PlayerPrefs.SetInt("Apples", 500);
       
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
