using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddGameObject : MonoBehaviour
{
    [SerializeField] private GameObject obj;

    public void CreatObject()
    {
        Instantiate(obj,Vector3.zero,Quaternion.identity);
    }
}
