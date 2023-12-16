using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _hitClip;

    public Queue<AudioClip> _queue = new Queue<AudioClip>();

    private Vector3 _lastPosition;
    
    public void AddClipToQueue(AudioClip _clip, Vector3 position)
    {
        if (Vector3.Distance(_lastPosition, position) > 1)
        {
            _queue.Enqueue(_clip);
            _lastPosition = position;
        }
    }


    private void Update()
    {
        if (_queue.Count > 0)
        {
            _audioSource.PlayOneShot(_queue.Dequeue());
        }
    }

    public void PlayHitSound()
    {
        _audioSource.pitch = Random.Range(0.5f, 1.5f);
        _audioSource.PlayOneShot(_hitClip);
    }


}
