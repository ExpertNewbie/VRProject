using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDialogController : MonoBehaviour
{
    AbsButtonController abstractClass;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
