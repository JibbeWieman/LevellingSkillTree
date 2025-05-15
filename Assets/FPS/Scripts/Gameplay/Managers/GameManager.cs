//using System;
//using System.Collections.Generic;
//using UnityEngine;

//public class GameManager : MonoBehaviour
//{
//    List<Manager> managers = new();

//    void Start()
//    {
//        DontDestroyOnLoad(gameObject);

//        // Optionally start all managers already registered at this point
//        for (int i = 0; i < managers.Count; i++)
//            managers[i].Start();
//    }

//    void Update()
//    {
//        for (int i = 0; i < managers.Count; i++)
//            managers[i].Update();
//    }

//    public T GetManager<T>() where T : Manager
//    {
//        T manager = managers.Find(m => m is T) as T;

//        if (manager == null)
//        {
//            Debug.LogWarning($"Manager of type {typeof(T)} not found.");
//        }

//        return manager;
//    }

//    // AddManager now accepts an instance of Manager
//    public void AddManager(Manager manager)
//    {
//        if (!managers.Contains(manager))
//        {
//            managers.Add(manager);
//            Debug.Log($"{manager.GetType()} added to GameManager.");
//        }
//    }

//    public void RemoveManager<T>() where T : Manager
//    {
//        managers.RemoveAll(t => t.GetType() == typeof(T));
//    }
//}
