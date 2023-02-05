using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class SupplyShipSounds : MonoBehaviour
{
    [SerializeField] AudioClip travelSound, destroySound;
    AudioSource source;
    SupplyShip ship;
    private void Awake()
    {
        ship = GetComponent<SupplyShip>();
        source = GetComponent<AudioSource>();
        ship.OnSpawn += PlayTravelSound;
        ship.OnDestroy += PlayDestroySound;
    }
    void PlayTravelSound()
    {
        if(travelSound != null)
        {
            source.PlayOneShot(travelSound);
            Debug.Log("Play shipp sound");
        }

    }
    void PlayDestroySound()
    {
        if(destroySound != null)
        source.PlayOneShot(destroySound);
    }
    private void OnDisable()
    {
        ship.OnSpawn -= PlayTravelSound;
        ship.OnDestroy -= PlayDestroySound;
    }
}
