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

    private static readonly Lazy<DataBaseManager> lazy =  new Lazy<DataBaseManager>(() => new DataBaseManager());

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
        }
        catch (Exception ex) 
        {
            exception = ex.ToString();
            Debug.Log("DBEXC: "+ ex.Message);
        }

    }

    //--------------------------------------------------------------------------------------------------------------------------------------------------------------
    //-------------------------------------------------------------------[ CONNECTION FUNCTIONS ]-------------------------------------------------------------------

    public void initializeDatabase()
    {
        //database = FirebaseDatabase.GetInstance("https://p-game-a75c2-default-rtdb.europe-west1.firebasedatabase.app");
        //db_reference = database.RootReference; //FirebaseDatabase.DefaultInstance.RootReference;
        //Debug.Log("RootRef: " + db_reference.ToString());
        //Debug.Log("RootRef2: " + database.GetReference("player").Child("test").ToString());
    }

    public bool getConnectionState()
    {
        //return db_reference != null ? true : false;
        return false;
    }

    //--------------------------------------------------------------------------------------------------------------------------------------------------------------
    //----------------------------------------------------------------[ LOGIN / SIGN UP FUNCTIONS ]-----------------------------------------------------------------

    public void signinUser()
    {
    
    }

    /*public IEnumerator loginUser(string username = "", string password = "")
    {
        var db_task = database.GetReference("player").Child(username).Child(password).GetValueAsync();
        yield return new WaitUntil(predicate: () => db_task.IsCompleted);

        if(db_task.Exception != null)
        {
            Debug.Log("DB_TASK_EXCEPTION: " + db_task.Exception.Message.ToString());
        }
        else if(db_task.Result.Value == null)
        {
            Debug.Log("DB_TASK_RESULT IS NULL");
        }
        else
        {
            Debug.Log("DB_TASK_RESULT: " + db_task.Result.Value.ToString());
        }
    }*/

    /*public void loginUser(string username = "", string password = "")
    {

        //DEBUG
        Debug.Log("U: " + username + " P: " + password);
        if (db_reference == null) { Debug.Log("db_reference is null!"); } else { Debug.Log("DBref: " + db_reference.ToString()); }
        //EOF DEBUG

        Debug.Log("Route: " + database.GetReference("player").Child(username).Child(password).ToString());
        //db_reference.Child("player")
        database.GetReference("player")
                .Child(username)
                .Child(password)
                .GetValueAsync()
                .ContinueWith( task => {
            if (task.IsCompleted)
            {
                Debug.Log("task.IsCompleted: Succeeded");
                DataSnapshot data_snapshot = task.Result;
                Debug.Log(task.Result.ToString());
            }
            else
            {
                Debug.LogError("task.IsCompleted: Failed");
            }
        });

    }
    */

    public string returnException()
    {
        return this.exception;
    }
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------
}
