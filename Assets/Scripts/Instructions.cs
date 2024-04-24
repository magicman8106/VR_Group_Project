using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instructions : MonoBehaviour
{
    public Text text;

    string[] instruction = {"Activity 2: Dissection Techniques & Initial Incision",
        "Objective:  To learn safe and proper dissection techniques and make an initial incision to access the pig's internal anatomy.",
        "Materials:\\r\\n\\r\\n    Dissecting tray\\r\\n    Preserved fetal pig\\r\\n    Dissection tools",
        "Preparation:\r\n\r\n    Put on gloves and safety goggles.\r\n    Position the pig on its back in the dissecting tray.",
        "Tool Selection:\r\n\r\n    Scalpel: Use for initial incisions into the skin. Handle with caution as blades are extremely sharp.\r\n    Scissors: Use for longer cuts and cutting through muscle tissue.\r\n    Forceps: Use for picking up and manipulating tissues.\r\n    Probe: Use for separating and exploring structures without cutting.",
        "Initial Incision\r\n\r\n    Locate the umbilical cord: Find the cord on the mid-abdomen.\r\n    Shallow cut: Using the scalpel, make a shallow U-shaped incision around the umbilical cord, cutting through the skin only.\r\n    Deepening the cut: Switch to scissors and carefully extend the incision upward towards the neck and downward towards the hind legs. Cut through muscle layers as needed.",
        "Flap Creation:\r\n\r\n    Gently lift the edges of the incision to create flaps of skin and muscle tissue.\r\n    Fold the flaps back to expose the underlying abdominal cavity.",
        "Safety Reminders:\r\n\r\n    Always cut away from your body and fingers.\r\n    Use tools for their intended purpose.\r\n    Inform the instructor immediately in case of any cuts or injuries.",
        "Tips:\r\n\r\n    Dissect slowly and carefully.\r\n    Use the probe to initially separate tissues before cutting.\r\n    Keep your work area clean and organized.",
        "Next Steps\r\n\r\n    Observe the exposed internal organs of the abdominal cavity.\r\n    Proceed with further dissections as directed by your instructor.\r\n    Important: Your instructor may have specific variations on the incision pattern or additional instructions. Always follow their guidance closely."
        };
    private int currentPage;

    // Start is called before the first frame update
    void Start()
    {
        currentPage = 0;
        text.text = instruction[currentPage];

    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.W))
        {
            ChangeSlide(1);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            ChangeSlide(-1);
        }
        */
    }

    public void ChangeSlide(int change)
    {
        currentPage = currentPage + change;
        text.text = instruction[currentPage];
    }
}
