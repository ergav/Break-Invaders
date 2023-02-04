using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BuildingSound : MonoBehaviour
{
    [SerializeField] AudioClip damageSound, destroySound;
    Building baseClass;
    AudioSource source;
    private void Awake()
    {
        baseClass = GetComponent<Building>();
        source = GetComponent<AudioSource>();
        baseClass.OnDamaged += PlayDamageSound;
        baseClass.OnDestroyed += PlayDestroySound;
    }
    void PlayDamageSound()
    {
        if (damageSound != null)
            source.PlayOneShot(damageSound);
    }
    void PlayDestroySound()
    {
        if (destroySound != null)
            source.PlayOneShot(destroySound);
    }
    private void OnDisable()
    {
        baseClass.OnDamaged -= PlayDamageSound;
        baseClass.OnDestroyed -= PlayDestroySound;
    }
}
