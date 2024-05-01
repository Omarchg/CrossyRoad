using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Botones : MonoBehaviour
{
    public GameObject exit, restart;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Exit() 
    {
        LeanTween.scale(exit, Vector2.zero, 1f).setEase(LeanTweenType.easeInBack).setOnComplete(() => { Application.Quit(); });
    }
    public void Restart()
    {
        LeanTween.scale(restart, Vector2.zero, 1f).setEase(LeanTweenType.easeInBack).setOnComplete(() => { SceneManager.LoadScene(0); });
    }
}
