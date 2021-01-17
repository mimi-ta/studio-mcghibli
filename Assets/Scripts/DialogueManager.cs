using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public string AlternativeSceneName;

    public Animator animator;

    private Queue<string> sentences;
    private string crntSentence;
 
    // Start is called before the first frame update
    void Awake() {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue) {
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
            StopAllCoroutines();
            StartCoroutine(Wait(0.5F));
            animator.SetBool("isFullSizeTime", true);
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

    public void AlternativeBtn()
    {
        SceneManager.LoadScene(AlternativeSceneName);
    }

    public void EnableAltButton(string buttonName) {
        GameObject obj = GameObject.Find(buttonName);
        if (obj)
        {
            Button objBtn = obj.GetComponentInChildren<Button>();
            if (!objBtn.isActiveAndEnabled)
            {
                objBtn.enabled = true;
                obj.GetComponentInChildren<Text>().enabled = true;
            } else
            {
                EndDialogue();
            }
        } else
        {
            EndDialogue();
        }
    }

    public void DisplayNextSentence() {
        if (sentences.Count == 0) {
            GameObject continueBtnElement = GameObject.Find("ContinueButton");
            
            if (continueBtnElement) {
                Button continueButton = continueBtnElement.GetComponentInChildren<Button>();

                if (continueButton.enabled == true) {
                    continueButton.enabled = false;
                    continueButton.GetComponentInChildren<Text>().enabled = false;
                }
            }
            EnableAltButton("AlternativeButton");
            return;
        }
        crntSentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(crntSentence));
    }

    IEnumerator TypeSentence(string sentence) {
        dialogueText.text = "";

        foreach (char letter in sentence.ToCharArray()) {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.05F);
        }
    }

    public void EndDialogue() {
        animator.SetBool("isFullSizeTime", false);
        animator.SetBool("isOpen", false);
    }
}
