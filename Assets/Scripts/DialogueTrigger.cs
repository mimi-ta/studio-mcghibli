using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public bool triggerOnStart;

    void Start()
    {
        if (triggerOnStart) TriggerDialogue();
    }
    public void TriggerDialogue() {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
