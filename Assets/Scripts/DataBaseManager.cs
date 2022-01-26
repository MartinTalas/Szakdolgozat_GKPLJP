using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Firebase;
using Firebase.Extensions;

public class DataBaseManager : MonoBehaviour
{
    public UnityEvent on_firebase_initialized = new UnityEvent();
    Color _color = Color.blue;

    void Start()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread( task =>
        {
            if(task.Exception != null)
            {
                Debug.LogError("Failed initialize firebase with " + task.Exception.Message);
                _color = Color.red;
                return;
            }
            else
            {
                _color = Color.green;
            }

            on_firebase_initialized.Invoke();
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void getColor()
    {
        GetComponent<Renderer>().material.color = _color;
    }
}