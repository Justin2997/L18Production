using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConclusionTransition : MonoBehaviour
{
    public Animator animator;

    public void FadeToConclusion()
    {
        animator.SetTrigger("EndGame");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(1); 
    }
}
