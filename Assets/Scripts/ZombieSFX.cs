
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class ZombieSFX : UdonSharpBehaviour
{
    [SerializeField] AudioClip[] audioClips;
    [SerializeField] float rMin;
    [SerializeField] float rMax;
    private float time = 0;
    private float num;
    private AudioSource AS;

    private void Start()
    {
        num = Random.Range(rMin, rMax);
        AS = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (time > num)
        {
            num = Random.Range(rMin, rMax);
            time = 0;
            AS.clip = audioClips[Random.Range(0, audioClips.Length)];
            AS.Play();
        }
        time += Time.deltaTime;
    }
}
