using UnityEngine;
using System.Collections;

#if UNITY_EDITOR
[CreateAssetMenu(fileName = "GameObjectArray", menuName = "Dice/GameObjectArray", order = 0)]
#endif
public class GameObjectArray : ScriptableObject {
    public GameObject[] gameObjects;
}