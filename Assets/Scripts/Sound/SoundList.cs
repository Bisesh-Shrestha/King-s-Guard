using System.Collections.Generic;
using UnityEngine;

public class SoundList : MonoBehaviour
{
    [SerializeField] List<AudioClip> gameSounds = new List<AudioClip>();
    AudioSource audioSource;
    [SerializeField] int orderList;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        orderList = 1;
    }

    public void playsfx(int sound)
    {
        audioSource.clip = gameSounds[sound];
        audioSource.Play();
    }

}
