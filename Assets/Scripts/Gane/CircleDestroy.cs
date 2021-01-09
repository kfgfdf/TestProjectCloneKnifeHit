using UnityEngine;
using UnityEngine.SceneManagement;

public class CircleDestroy : MonoBehaviour
{
    public void PlayingNext()
    {
        SceneManager.LoadScene(1);
    }
}
