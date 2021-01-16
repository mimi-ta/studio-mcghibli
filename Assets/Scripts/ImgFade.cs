using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ImgFade : MonoBehaviour
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
            Debug.Log("hi");
            FindObjectOfType<DialogueTrigger>().TriggerDialogue();
            dialogueTriggeredFlag = true;
        }

    }

    IEnumerator FadeImage(bool fadeAway)
    {
        // fade from opaque to transparent
        if (fadeAway)
        {
            // loop over 1 second backwards
            for (float i = 1; i >= 0; i -= Time.deltaTime/length)
            {
                // set color with i as alpha
                img.color = new Color(1, 1, 1, i);
                yield return null;
            }
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