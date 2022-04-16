using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbsDataManager
{
    public abstract string LoadData();
    public abstract void SaveData(string data);
}
