using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerController : MonoBehaviour
{
    TextMeshProUGUI textMesh;
    public float raius = 10;
    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        InitialSetting();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void InitialSetting()
    {
        // textMesh.text = "05:06:99";
        // textMesh.color = new Color(1, 1, 1, 1);
        // textMesh.fontSize = 3.0f;
    }
}
