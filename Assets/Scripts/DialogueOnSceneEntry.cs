using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueOnSceneEntry : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()

    {
        Debug.Log("D T");
        FindObjectOfType<DialogueTrigger>().TriggerDialogue();
    }
}
