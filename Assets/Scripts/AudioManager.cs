using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public List<AudioClip> audioClips; // Lista de �udios
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // M�todo para reproduzir um �udio espec�fico com base no �ndice
    public void PlayAudio(int audioIndex)
    {
        if (audioIndex >= 0 && audioIndex < audioClips.Count)
        {
            audioSource.clip = audioClips[audioIndex];
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("�ndice de �udio fora dos limites da lista.");
        }
    }
}
