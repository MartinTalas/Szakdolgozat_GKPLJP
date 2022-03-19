using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Auth;
using Firebase.Extensions;

public sealed class DataBaseManager
{
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------
    //------------------------------------------------------------------------[ VARIABLESS ]------------------------------------------------------------------------

    //https://p-game-a75c2-default-rtdb.europe-west1.firebasedatabase.app/

    private FirebaseDatabase db;
    private FirebaseApp firebaseApp;
    //private DatabaseReference db_reference;
    //private FirebaseStorage storage;
    //private StorageReference stReference;
    public string exception;

    private Player local_user;

    //--------------------------------------------------------------------------------------------------------------------------------------------------------------
    //---------------------------------------------------------------------[ SINGLETON PATTERN ]--------------------------------------------------------------------

    private static readonly Lazy<DataBaseManager> lazy = new Lazy<DataBaseManager>(() => new DataBaseManager());

    public static DataBaseManager Instance { get { return lazy.Value; } }

    private DataBaseManager()
    {
        try
        {/*
            Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
                var dependencyStatus = task.Result;
                if (dependencyStatus == Firebase.DependencyStatus.Available)
                {
                    // Create and hold a reference to your FirebaseApp,
                    // where app is a Firebase.FirebaseApp property of your application class.
                    firebaseApp = Firebase.FirebaseApp.DefaultInstance;
                    
                    // Set a flag here to indicate whether Firebase is ready to use by your app.
                }
                else
                {
                    UnityEngine.Debug.LogError(System.String.Format(
                      "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
                    // Firebase Unity SDK is not safe to use here.
                }
            });*/


            this.db = FirebaseDatabase.GetInstance("https://p-game-a75c2-default-rtdb.europe-west1.firebasedatabase.app/");
            //this.storage = FirebaseStorage.getInstance();
            //this.stReference = storage.getReferenceFromUrl("gs://p-game-a75c2.appspot.com/speeches");
            //Debug.Log("RootRef: " + db.ToString());

            exception = "It works correctly(?)!";
        }
        catch (Exception ex)
        {
            exception = ex.ToString();
            Debug.Log("DBEXC: " + ex.Message);
        }

    }

    //--------------------------------------------------------------------------------------------------------------------------------------------------------------
    //-------------------------------------------------------------------[ CONNECTION FUNCTIONS ]-------------------------------------------------------------------

    public FirebaseDatabase getConnection()
    {
        return db;
    }

    //--------------------------------------------------------------------------------------------------------------------------------------------------------------
}
