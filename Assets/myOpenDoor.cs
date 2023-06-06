using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myOpenDoor : MonoBehaviour
{
    public Transform user;
    public float detectionRange = 3f;
    public Transform lid;
    public float lidOpenAngle = -90f;
    public float lidCloseAngle = 0f;

    private bool isOpen = false;
    
    void Start()
    {
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, user.position);
        if (distance <= detectionRange && !isOpen)
        {
            OpenLid();
        }
        else if (distance > detectionRange && isOpen)
        {
            CloseLid();
        }
    }

    private void OpenLid()
    {
        isOpen = true;
        lid.rotation = Quaternion.Euler(lidOpenAngle, 180f, 0f);
    }

    private void CloseLid()
    {
        isOpen = false;
        lid.rotation = Quaternion.Euler(lidCloseAngle, 180f, 0f);
    }
}
