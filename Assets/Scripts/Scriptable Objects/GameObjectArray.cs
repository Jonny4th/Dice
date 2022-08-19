using UnityEngine;
using System.Collections;
using System.Collections.Generic;


#if UNITY_EDITOR
[CreateAssetMenu(fileName = "GameObjectArray", menuName = "Dice/GameObjectArray", order = 0)]
[System.Serializable]
#endif
public class GameObjectArray : ScriptableObject {
    public List<GameObject> gameObjects = new List<GameObject>();
}