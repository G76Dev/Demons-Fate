using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoryTextBehaviour : MonoBehaviour
{
    public string[] story;
    public float speed;

    private Queue<string> sentences = new Queue<string>();
    private bool running = false;
    private string sentence;

    public GameObject textObject;
    public GameObject NextBotónText;

    // Start is called before the first frame update
    void Start()
    {
        Display();
    }

    private void Display()
    {
        sentences.Clear();

        foreach (string sentence in story)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        
            if (!running && sentences.Count != 0)
            {        
                sentence = sentences.Dequeue();
                StartCoroutine(TypeSentence(sentence));                       
            }
            else
            {
                StopAllCoroutines();
                running = false;
                textObject.GetComponent<Text>().text = sentence;
            }  
        

        if (sentences.Count==0 && SceneManager.GetActiveScene().name.Equals("InitScene"))
        {
            NextBotónText.GetComponent<Text>().text = "PLAY";
        }
        else if(sentences.Count == 0)
        {
            NextBotónText.GetComponent<Text>().text = "RETURN";
        }

        GameObject myEventSystem = GameObject.Find("EventSystem");
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
    }

    IEnumerator TypeSentence (string sentence)
    {
        running = true;

        textObject.GetComponent<Text>().text = "";
        foreach (char c in sentence.ToCharArray())
        {
            textObject.GetComponent<Text>().text += c;
            yield return new WaitForSeconds(0.03f);
            yield return null;
        }

        running = false;
    }
}
