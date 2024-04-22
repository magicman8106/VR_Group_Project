using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Firestore;
using Firebase.Extensions;

public class GradingSystem : MonoBehaviour
{
    //FirebaseFirestore db;
    // Start is called before the first frame update
    public void Start()
    {
        //db = FirebaseFirestore.DefaultInstance;
    }

    // Update is called once per frame
    void Update()
    {
        //
    }

    public void GetData()
    {
        //var users = FirebaseFirestore.DefaultInstance.Collection("users").GetSnapshotAsync();
        //var datas = db.Collection("users").GetSnapshotAsync();
        //Debug.Log(data);
        //var users = IEnumerable<data> Children;
        //Debug.Log(datas);
        var firestore = FirebaseFirestore.DefaultInstance; 
        firestore.Collection("users").GetSnapshotAsync().ContinueWithOnMainThread(task => {
            //Assert.IsNull(task.exception);

            var users = task.Result;
            Debug.Log(users);
        });
        
    }
}
