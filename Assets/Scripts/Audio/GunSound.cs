using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class GunSound : MonoBehaviour
{

    [SerializeField] AudioClip[] clips;

    AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void Play(int sound)
    {
        source.PlayOneShot(clips[sound]);
    }
}
