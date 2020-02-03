using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSoundPlayer : MonoBehaviour
{
    private AudioSource source;
    private AudioClip clip;
    private bool is_start;

    public GameObject shpere;
    public Material[] materials;

    public  int  playing_material_index;

    private void Awake()
    {
        source = gameObject.GetComponent<AudioSource>();
        clip = source.clip;
        is_start = false;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        if (is_start)
        {
            if (!source.isPlaying)
            {
                FinalSound();
            }
        }
    }

    void FinalSound()
    {
        shpere.GetComponent<Renderer>().material = materials[0];
        is_start = false;
    }

    public void PlaySound()
    {
        shpere.GetComponent<Renderer>().material = materials[playing_material_index];
        source.Play();
        is_start = true;
    }
}
