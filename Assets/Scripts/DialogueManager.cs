using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;

    public Animator animator;

    private Queue<string> sentences;
    private string crntSentence;
 
    // Start is called before the first frame update
    void Start() {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue) {
        Debug.Log("Starting conversation with " + dialogue.name);
        animator.SetBool("isOpen", true);
        DisplayBiggerDialogueBox();

        nameText.text = dialogue.name;
        sentences.Clear();

        foreach (string sentence in dialogue.sentences) {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayBiggerDialogueBox() {
        if (animator.GetBool("isOpen") == true) {
            Debug.Log("isOpen is true.");
            StopAllCoroutines();
            StartCoroutine(Wait(0.5F));
            animator.SetBool("isFullSizeTime", true);
            Debug.Log("isFullSizeTime is true.");
        }
    }

    IEnumerator Wait(float time) {
        yield return new WaitForSeconds(time);
    }

    public void ContinueBtn()
    {
        if (dialogueText.text != crntSentence)
        {
            StopAllCoroutines();
            dialogueText.text = crntSentence;
        }
        else DisplayNextSentence();
    }

    public void DisplayNextSentence() {
        if (sentences.Count == 0) {
            EndDialogue();
            return;
        }
        crntSentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(crntSentence));
        Debug.Log(crntSentence);
    }

    IEnumerator TypeSentence(string sentence) {
        dialogueText.text = "";

        foreach (char letter in sentence.ToCharArray()) {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.05F);
        }
    }

    public void EndDialogue() {
        Debug.Log("End of conversation.");
        animator.SetBool("isFullSizeTime", false);
        animator.SetBool("isOpen", false);
    }
}
