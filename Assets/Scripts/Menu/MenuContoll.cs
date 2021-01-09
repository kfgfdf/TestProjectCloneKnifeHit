using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuContoll : MonoBehaviour
{
    public Animator animator;

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
