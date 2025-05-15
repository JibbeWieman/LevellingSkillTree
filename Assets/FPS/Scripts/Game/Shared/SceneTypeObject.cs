using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

[CreateAssetMenu(fileName = "New Scene Type", menuName = "ScriptableObjects/SceneType", order = 1)]
public class SceneTypeObject : ScriptableObject
{
    private List<GameObject> objects;

    public event Action OnAdded;
    public event Action OnRemoved;

    private void OnEnable()
    {
        objects ??= new List<GameObject>();
    }

    public void Add(GameObject obj)
    {
        objects.Add(obj);
        OnAdded?.Invoke();
    }

    public void Remove(GameObject obj)
    {
        objects.Remove(obj);
        OnRemoved?.Invoke();
    }

    public ReadOnlyCollection<GameObject> Objects => objects.AsReadOnly();
}