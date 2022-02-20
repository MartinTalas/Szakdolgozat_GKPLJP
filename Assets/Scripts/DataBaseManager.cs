using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using System;
using System.Threading.Tasks;

public sealed class DataBaseManager
{
    //https://p-game-a75c2-default-rtdb.europe-west1.firebasedatabase.app/
    private FirebaseDatabase database;
    private DatabaseReference db_reference;
    
    private Player local_user;

    //SINGLETON
    private static readonly Lazy<DataBaseManager> lazy =  new Lazy<DataBaseManager>(() => new DataBaseManager());

    public static DataBaseManager Instance { get { return lazy.Value; } }

    private DataBaseManager()
    {
        initializeDatabase();
    }
    //-----------------------------
    public void initializeDatabase()
    {
        database = FirebaseDatabase.GetInstance("https://p-game-a75c2-default-rtdb.europe-west1.firebasedatabase.app/");
        db_reference = database.RootReference;
        Debug.Log("RootRef: " + database.RootReference.ToString());
    }

    public bool getConnectionState()
    {
        return db_reference != null ? true : false;
    }

    public void signinUser()
    {
    
    }

    public void loginUser(string username = "", string password = "")
    {

        //DEBUG
        Debug.Log("U: " + username + " P: " + password);
        if (db_reference == null) { Debug.Log("db_reference is null!"); } else { Debug.Log("DBref: " + db_reference.ToString()); }
        //EOF DEBUG

        Debug.Log("GETDATA: " + this.db_reference.Child("player").Child(username).Child(password).GetValueAsync().ToString());
            this.db_reference.Child("player")
                         .Child(username)
                         .Child(password)
                         .GetValueAsync()
                         .ContinueWithOnMainThread(task => {
                             Debug.Log("Benn van.");
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
}
