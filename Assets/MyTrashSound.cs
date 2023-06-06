using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTrashSound: MonoBehaviour
{
    AudioSource audioSoure;
    // Start is called before the first frame update
    void Start()
    {
        audioSoure = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trashbin"))
        {
            audioSoure.Play();
        }
    }
}
