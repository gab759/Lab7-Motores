using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDoor : MonoBehaviour
{
    [SerializeField] private SoundConfig music;
    [SerializeField] private SoundConfig sfx;

    [SerializeField] private AudioSource _compAudioSource;
    [SerializeField] private AudioSource _doorAudioSource;
    [SerializeField] private Fade fade;
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            _compAudioSource.clip = music.SoundClip;
            _compAudioSource.Play();
            _doorAudioSource.clip = sfx.SoundClip;
            _doorAudioSource.Play();
            fade.CallComplexFadeIn();
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            _compAudioSource.Stop();
            _doorAudioSource.Stop();
            _doorAudioSource.Play();
            fade.CallComplexFadeIn();
        }
    }
}