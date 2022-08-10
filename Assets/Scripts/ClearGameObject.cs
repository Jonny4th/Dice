using UnityEngine;

public class ClearGameObject : MonoBehaviour
{
    [SerializeField] private string _tag;
    // Start is called before the first frame update

    public void ClearObject()
    {
        GameObject[] objects;
        objects = GameObject.FindGameObjectsWithTag(_tag);

        foreach(GameObject obj in objects)
        {
            Destroy(obj);
        }
    }
}
