using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Firebase;
using Firebase.Extensions;

public class FirebaseInit : MonoBehaviour
{
    public UnityEvent on_firebase_initialized = new UnityEvent();
    Color debug_color = Color.blue;//DEBUG

    void Start()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread( task =>
        {
            if(task.Exception != null)
            {
                Debug.LogError("Failed initialize firebase with " + task.Exception.Message);
                debug_color = Color.red;//DEBUG
                return;
            }
            else
            {
                debug_color = Color.green;//DEBUG
            }

            Debug.Log("Successful initialize firebase");
            on_firebase_initialized.Invoke();
        });
    }

    // Update is called once per frame
    void Update()
    {

    }

    //DEBUG FUNCTION
    public void getColor()//DEBUG
    {
        GetComponent<Renderer>().material.color = debug_color;
    }
}