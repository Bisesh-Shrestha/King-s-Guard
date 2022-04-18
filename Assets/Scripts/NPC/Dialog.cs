using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textDisplay;
    [SerializeField] string[] sentences;
    [SerializeField] float typingSpeed;
    private int index;

    [SerializeField] GameObject continueBtn;
    [SerializeField] GameObject DialogPanel;

    void Start()
    {
        StartCoroutine(Type());
    }
    private void Update()
    {
        if (Input.GetButtonDown("Horizontal")) 
        {
            DialogPanel.SetActive(false);
        }
        if (textDisplay.text == sentences[index])
        {
            continueBtn.SetActive(true);
        }
    }
    IEnumerator Type()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        continueBtn.SetActive(false);
        if(index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "Best of Luck";
            DialogPanel.SetActive(false);
        }
    }
}
