using UnityEngine;

public class AddGameObject : MonoBehaviour
{
    [SerializeField] private GameObject obj;
    public float yOffset;
    public void CreatObject()
    {
        Instantiate(obj,Vector3.up*yOffset,Quaternion.identity);
    }
}
