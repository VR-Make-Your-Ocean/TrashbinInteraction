using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MyDestroyScript : MonoBehaviour
{
    MeshRenderer mesh;
    Material mat;
    private AudioSource[] audioSources;
    private AudioClip[] audioClips;
    private TMP_Text tmpText;

    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        mat = mesh.material;
        audioClips = new AudioClip[2];
        audioClips[0] = Resources.Load("success") as AudioClip;
        audioClips[1] = Resources.Load("bad") as AudioClip;
        if (!audioClips[0])
            Debug.Log("로드안됨");
        audioSources = new AudioSource[2];  // 배열 초기화
        for (int i = 0; i < 2; i++)
        {
            audioSources[i] = gameObject.AddComponent<AudioSource>();
            audioSources[i].clip = audioClips[i];
            audioSources[i].loop = false;
            audioSources[i].playOnAwake = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        tmpText = other.GetComponentInChildren<TMP_Text>();
        if (other.CompareTag("Trashbin"))
        {
            if (tmpText.text == mesh.gameObject.tag)
            {
                Debug.Log("TMP Text matches with tag");
                MyGlobalVariables.recycle_point += 10;
                switch (mesh.gameObject.tag) {
                    case "Can": MyGlobalVariables.can[MyGlobalVariables.c_can] = mesh.gameObject.name; MyGlobalVariables.c_can++; break;
                    case "Plastic": MyGlobalVariables.plastic[MyGlobalVariables.c_plastic] = mesh.gameObject.name; MyGlobalVariables.c_plastic++; break;
                    case "Paper": MyGlobalVariables.paper[MyGlobalVariables.c_paper] = mesh.gameObject.name; MyGlobalVariables.c_paper++; break;
                    case "Glass": MyGlobalVariables.glass[MyGlobalVariables.c_glass] = mesh.gameObject.name; MyGlobalVariables.c_glass++; break;
                    default: break;
                }
                string text = "";
                for (int i = 0; i < 10; i++)
                    text += MyGlobalVariables.can[i] + "\n";
                Debug.Log(text);
                audioSources[0].Play();
            }
            else 
            {
                Debug.Log("TMP Text not matches with tag");
                MyGlobalVariables.recycle_point -= 10;
                if (MyGlobalVariables.recycle_point < 0)
                    MyGlobalVariables.recycle_point = 0;
                audioSources[1].Play();
            }
            Debug.Log("myVariable: " + MyGlobalVariables.recycle_point);
            Destroy(mat);
        }
    }
}
