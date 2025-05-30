using UnityEngine;

public class SplashController : MonoBehaviour
{
    public GameObject splashImage;
    public float delay = 3f;

    void Start()
    {
        Invoke("HideSplash", delay);
    }

    void HideSplash()
    {
        splashImage.SetActive(false);
    }
}
