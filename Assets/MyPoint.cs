using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MyPoint : MonoBehaviour
{
    public int myVariable;
    private TMP_Text tmpText;
    // Start is called before the first frame update
    void Start()
    {
        tmpText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        myVariable = MyGlobalVariables.recycle_point;
        // TMP_Text에 변수 값 표시
        tmpText.text = "분리수거 포인트: " + myVariable.ToString();
    }
}
