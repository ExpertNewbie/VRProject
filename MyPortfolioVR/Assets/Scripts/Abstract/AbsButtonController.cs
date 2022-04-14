using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbsButtonController : MonoBehaviour
{
    public GameObject uiDialog;
    public bool isDialogOpen = false;
    public abstract void ButtonExit();
    public abstract void DialogOpen(string info);
    public abstract void DialogThrowsInfo(bool yn);
}
