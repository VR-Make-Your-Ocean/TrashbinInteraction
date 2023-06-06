using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MyTrashList : MonoBehaviour
{
    public Transform Trashbin;
    private TMP_Text tmpText;
    private TMP_Text childText;

    // Start is called before the first frame update
    void Start()
    {
        tmpText = GetComponent<TMP_Text>();
        childText = Trashbin.GetComponentInChildren<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        string text = "";
        string[] list = new string[10];
        switch (childText.text)
        {
            case "Can":
                text += "Can\n";
                list = MyGlobalVariables.can;
                break;
            case "Plastic":
                text += "Plastic\n";
                list = MyGlobalVariables.plastic;
                break;
            case "Paper":
                text += "Paper\n";
                list = MyGlobalVariables.paper;
                break;
            case "Glass":
                text += "Glass\n";
                list = MyGlobalVariables.glass;
                break;
            default: break;
        }
        for (int i = 0; i < 10; i++)
        {
            text += list[i] + "\n";
        }
        Debug.Log(text);
        tmpText.text = text;
    }

}
