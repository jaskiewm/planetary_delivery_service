using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    float sentenceCounter = 0f;
    public Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    private void Update()
    {
        sentenceCounter += Time.deltaTime;
        //Debug.Log(sentenceCounter);
    }

    public void StartDialogue(Dialogue dialogue)
    {
        sentenceCounter = 0f;
        Debug.Log("Opening Contract:" + dialogue.name);

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        if (sentenceCounter >=4f) {
            //sentenceCounter = 0f;
            DisplayNextSentence();
        }
        
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        Debug.Log(sentence);
    }
    void EndDialogue()
    {
        Debug.Log("End of Messages");
    }
}
