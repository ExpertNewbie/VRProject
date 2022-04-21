using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDialogController : MonoBehaviour
{
    AbsButtonController abstractClass;
    [SerializeField] Text info;
    // Start is called before the first frame update
    void Start()
    {
        // info.text = "NONE INFO";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetDialogText(string text)
    {
        info.text = text;
    }
    public void DialogYes()
    {
        abstractClass.DialogThrowsInfo(true);
        Destroy(gameObject);
    }
    public void DialogNo()
    {
        abstractClass.DialogThrowsInfo(false);
        Destroy(gameObject);
    }
    public void SetAbsButtonController(AbsButtonController overrideClass)
    {
        abstractClass = overrideClass;
    }
}
