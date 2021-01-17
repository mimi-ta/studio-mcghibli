using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    
    void Update()
    {
        if (!FindObjectOfType<DialogueManager>().animator.GetBool("isOpen"))
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
