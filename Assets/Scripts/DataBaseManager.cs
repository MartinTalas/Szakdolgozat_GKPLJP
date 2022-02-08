using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;

public class DataBaseManager : MonoBehaviour
{
    
    //private FirebaseDatabase database;
    private DatabaseReference db_reference;
    
    private User local_user;

    [SerializeField] InputField username;
    [SerializeField] InputField password;
    [SerializeField] InputField nickname;
    
    // Start is called before the first frame update
    void Start()
    {
        //database = FirebaseDatabase.DefaultInstance;
        db_reference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    // Update is called once per frame
    void Update()
    {

    }

    /*
        ÁTNÉZNI
     */
    /*public async System.Threading.Tasks.Task<bool> saveExists()
    {
        var data_snapshot = await database.GetReference("").GetValueAsync();
        return data_snapshot.Exists;
    }*/

    public void signinUser()
    {
        //signin check
        local_user = new User();
        local_user.Username = username.text;
        local_user.Password = password.text;
        local_user.Name = nickname.text;

        string local_user_json = JsonUtility.ToJson(local_user);

        db_reference.Child("Player").Child(local_user.Username).SetRawJsonValueAsync(local_user_json)
            .ContinueWith(task => {
                if (task.IsCompleted) 
                {
                    Debug.Log("Successfully added user to database!");
                }
                else
                {
                    Debug.LogError("Failed to add user to database!");
                }
            });
    }

    public void loginUser()
    {
        //login check
        local_user = new User();//itt a konstruktort felhasználva, az adatbázisból leszedett adatokat töltjük be
    }
}
