using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces;

[CreateAssetMenu(fileName = "New Instantiatable", menuName = "Instantiatable")]
public class Instantiatable : ScriptableObject
{
    [SerializeField]
    private List<GameObject> container = new List<GameObject>();

    public GameObject GetPrefab(int prefabId)
    {
        return container[prefabId];
    }
}
