using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbsDataManager<T> : MonoBehaviour 
{
    public abstract T LoadData();
    public abstract void SaveData();
    public abstract void SaveData(T inputData);
}
