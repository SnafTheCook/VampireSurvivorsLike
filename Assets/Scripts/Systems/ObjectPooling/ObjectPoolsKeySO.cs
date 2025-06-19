using UnityEngine;
using System.Collections.Generic;

public class ObjectPoolsKeySO : ScriptableObject
{
    public string name;

    //got an idea to create scriptableobjects and use them as keys to avoid string comparison but I would have
    //to move prefabs from factory to keySOs and let objectpooling take care of all creation. Need to think about it
}

