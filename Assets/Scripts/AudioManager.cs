using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public List<AudioClip> audioClips; // Lista de áudios
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Método para reproduzir um áudio específico com base no índice
    public void PlayAudio(int audioIndex)
    {
        if (audioIndex >= 0 && audioIndex < audioClips.Count)
        {
            audioSource.clip = audioClips[audioIndex];
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("Índice de áudio fora dos limites da lista.");
        }
    }
}
