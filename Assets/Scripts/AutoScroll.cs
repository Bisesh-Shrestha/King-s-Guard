using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class AutoScroll : MonoBehaviour
{
    float speed = 1f;
    //float textProsBegin= -1520.0f;
    float boundaryTextEnd= 1520.0f;

    [SerializeField] RectTransform myGorectTransform;
    [SerializeField] TextMeshProUGUI mainText;

    private void Start()
    {
        StartCoroutine(AutoScrollText());
    }

    IEnumerator AutoScrollText()
    {
        while (myGorectTransform.localPosition.y < boundaryTextEnd)
        {
            myGorectTransform.Translate(Vector3.up * speed * Time.deltaTime);
            yield return null;
        }
        SceneManager.LoadScene("TitleScene");
    }
}
