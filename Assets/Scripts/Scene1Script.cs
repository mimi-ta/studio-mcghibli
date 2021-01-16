using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
public class Scene1Script : MonoBehaviour
{

    // the image you want to fade, assign ior
    public Image img;
    public float length;
    public float delay;
    private float timer = 0.0f;
    private bool dialogueTriggeredFlag = false;

    void Start()
    {
        StartCoroutine(FadeImage(false));
    }

    void Update()
    {
        
        timer += Time.deltaTime;
        if (timer > length + delay && !dialogueTriggeredFlag)
        {
            FindObjectOfType<DialogueTrigger>().TriggerDialogue();
            dialogueTriggeredFlag = true;
        }

        if (timer > length * 3)
        {
            StartCoroutine(FadeImage(true));
        }
    }

    IEnumerator FadeImage(bool fadeAway)
    {
        // fade from opaque to transparent
        if (fadeAway)
        {
            // loop over 1 second backwards
            FindObjectOfType<DialogueManager>().EndDialogue();
            for (float i = 1; i >= 0; i -= Time.deltaTime/length)
            {
                // set color with i as alpha
                Debug.Log(i);
                img.color = new Color(1, 1, 1, i);
                yield return null;
            }

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        // fade from transparent to opaque
        else
        {
            // loop over 1 second
            for (float i = 0; i <= length; i += Time.deltaTime/length)
            {
                // set color with i as alpha
                img.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
    }
}