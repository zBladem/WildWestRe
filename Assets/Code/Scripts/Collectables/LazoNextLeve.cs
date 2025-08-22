using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LazoNextLevel : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private string sceneName;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetTrigger("Collected");
            SceneManager.LoadScene(sceneName);


        }
     
    }
}