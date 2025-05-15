using System.Collections;
using UnityEngine;

public abstract class Manager : MonoBehaviour
{
    //[SerializeField]
    //private SceneTypeObject ST_GameManager;

    public virtual void Start()
    {
        //Automatically add this manager to the GameManager's manager list
        //GameManager gameManager = FindObjectOfType<GameManager>();
        //if (gameManager != null)
        //{
        //    gameManager.AddManager(this);
        //}
        //else
        //{
        //    Debug.LogError("GameManager not found in the scene.");
        //}

        Debug.Log($"Starting process: <color=#FFFFFF>{this.GetType()}</color>");
    }

    public virtual void Update()
    {
        // Managers can have their own update logic if needed.
    }

    //public abstract void Pause();
}
