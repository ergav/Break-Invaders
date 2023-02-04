using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BallSounds : MonoBehaviour
{
    [SerializeField] AudioClip bounceSound;
    AudioSource source;
    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(bounceSound != null)
        source.PlayOneShot(bounceSound);
    }
}
