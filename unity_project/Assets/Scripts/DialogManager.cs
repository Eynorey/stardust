using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour {


    public Text dialog;
    public GameObject dialogWindow;
    public Text dialogTitle;
    public GameObject startButton;
    public GameObject continueButton;
    public GameObject endButton;
    public GameObject skipButton;
    private Queue<string> sentences;

	// Use this for initialization
	void Start () {
        sentences = new Queue<string>();
	}

    public void StartDialog(Dialog dialog)
    {
        dialogWindow.SetActive(true);
        sentences.Clear();
        startButton.SetActive(false);
        continueButton.SetActive(true);
        dialogTitle.text = dialog.name;
        foreach(string sentence in dialog.sentences)
        {
            sentences.Enqueue(sentence);
        }
      
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 1)
        {
            skipButton.SetActive(false);
            continueButton.SetActive(false);
            endButton.SetActive(true);
        }
        if(sentences.Count == 0)
        {
            EndDialog();
            return;
        }
        var sentence = sentences.Dequeue();
        dialog.text = sentence;
    }

    public void EndDialog()
    {
         dialogWindow.SetActive(false);
    }
	
}
