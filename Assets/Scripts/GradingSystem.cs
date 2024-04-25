/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Firestore;
using Firebase.Extensions;
using System.Threading.Tasks;
using System.Text;
using System.IO;
using TMPro;



public class GradingSystem : MonoBehaviour
{
    private FirebaseFirestore firestore;
    public string userId;
    public bool email_found;
    public bool class_found;
    public string user_email;
    public string class_code;
    //-_-\\
    public TMP_InputField input_email;
    public TMP_InputField input_class_code;
    public Button submitButton;

    void Start()
    {
        // Get references to the input fields and button components
        input_email = transform.Find("email").GetComponent<TMP_InputField>();
        input_class_code = transform.Find("Class Code").GetComponent<TMP_InputField>();
        submitButton = transform.Find("Sign In").GetComponentInChildren<Button>();
        // Add a listener to the submit button
        submitButton.onClick.AddListener(SubmitButtonClicked);
    }
    void SubmitButtonClicked()
    {
        // Get the text from the input fields
        string userInput1 = input_email.text;
        string userInput2 = input_class_code.text;
        // Call your function with the user inputs
        Verify_Login(userInput1, userInput2);
        StartCoroutine(Wait());
        
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3f);
        Debug.Log("Login Status " + email_found + "  " + class_found);
        if (email_found && class_found)
        {
            Debug.Log("Login is completely verified, may proceed to next scenes.");
        }
    }

    public async void Verify_Login(string email, string classCode)
    {
        Debug.Log("Function called with inputs: " + email + ", " + classCode);
        Dictionary<string, Dictionary<string, object>> allUsersData = new Dictionary<string, Dictionary<string, object>>();
        CollectionReference usersCollectionRef = FirebaseFirestore.DefaultInstance.Collection("users");
        // Fetch all documents in the users collection
        QuerySnapshot usersSnapshot = await usersCollectionRef.GetSnapshotAsync();
        // Process each user document in the snapshot
        foreach (DocumentSnapshot userSnapshot in usersSnapshot.Documents)
        {
            // Get the user ID
            userId = userSnapshot.Id;
            // Convert user data to dictionary
            Dictionary<string, object> userData = userSnapshot.ToDictionary();
            // Store user data in the allUsersData dictionary
            allUsersData[userId] = userData;

            object field1Value = userData["email"];
            //Debug.Log("User ID: " + userId + ", Email: " + (string)field1Value);
            if (email == (string)field1Value)
            {
                email_found = true;
                user_email = (string)field1Value;
                Debug.Log(field1Value + " Email Verified: " + email_found);
                check_class(classCode);
            }
        }
    }

    public async void check_class(string classCode)
    {
        //////////////////////////////////////////////////////////////////////////////////////
        // Reference to the parent collection
        CollectionReference parentCollectionRef = FirebaseFirestore.DefaultInstance.Collection("classrooms");
        QuerySnapshot query1Snapshot = await parentCollectionRef.GetSnapshotAsync();
        // Iterate over the documents
        foreach (DocumentSnapshot documentSnapshot in query1Snapshot.Documents)
        {
            // Read the data of the document
            IDictionary<string, object> data = documentSnapshot.ToDictionary();

            // Check if the document's code matches the provided code
            if (data.TryGetValue("class_code", out object documentCode) && documentCode.ToString() == classCode)
            {
                Debug.Log("Class code " + classCode + " is validated.");
                class_found = true;
                class_code = classCode;
                // Access the subcollection of the matching document
                CollectionReference subcollectionRef = documentSnapshot.Reference.Collection("students");

                // Retrieve documents from the subcollection
                QuerySnapshot subcollectionSnapshot = await subcollectionRef.GetSnapshotAsync();

                // Iterate over the documents in the subcollection
                foreach (DocumentSnapshot subdocumentSnapshot in subcollectionSnapshot.Documents)
                {
                    // Read/write data of subdocuments as needed
                    IDictionary<string, object> subdocumentData = subdocumentSnapshot.ToDictionary();
                    Debug.Log("Found the student " + subdocumentData["email"] + " with grades " + subdocumentData["assignment_1"] + " " + subdocumentData["assignment_2"]);
                    // Example: Update subdocument data (write to Firestore)
                    // Modify the data dictionary as needed
                    //subdocumentData["field1"] = "New Value";
                    //await subdocumentSnapshot.Reference.SetAsync(subdocumentData);
                }

                // Exit the loop since we found the matching document
                break;
            }
        }
    }
}
*/