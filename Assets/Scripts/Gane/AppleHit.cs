using UnityEngine;

public class AppleHit : MonoBehaviour
{
    void OnTriggerEnter2D (Collider2D other)
    {
        if(other.gameObject.tag == "Knife")
        {
            Destroy(gameObject);
            PlayerPrefs.SetInt("Apples", PlayerPrefs.GetInt("Apples") + 1);
        }
    }
}
