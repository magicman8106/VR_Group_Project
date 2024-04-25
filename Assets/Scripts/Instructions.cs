using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instructions : MonoBehaviour
{
    public bool isAct1;
    public bool isAct2;
    public Text text;

    string[] activity1instructions =
    {
        "Activity 1: Determining Age",
        "Objective: To obtain measurements of the pig specimen and use those measurements to estimate its age and gender",
        "Safety:\r\n\r\n    Always handle the dissection specimen with care and wear gloves.\r\n    Dispose of waste materials according to your instructor's guidelines.",
        "Materials:\r\n\r\n    Dissecting tray\r\n    Preserved fetal pig\r\n    Ruler (In Centimeters)",
        "Measure Crown-Rump Length (CRL):\r\n\r\n    Gently lay the pig on its back in the dissecting tray.\r\n    Locate the crown (top of the head) and rump (base of the tail).\r\n    Using the ruler, measure the distance in centimeters (cm) between the crown and rump. This is the CRL.",
        "Measure Foot Pad Length (FPL):\r\n\r\n    Select a front or hind leg.\r\n    Locate the fleshy pad at the bottom of the hoof/foot.\r\n    Measure the length (longest dimension) of the pad in cm.",
        "Estimating Age:\r\n\r\n    Consult a reference chart (available from your instructor or online) that correlates CRL or FPL to estimated pig age in fetal development stages.\r\n    Based on your measurements, locate the corresponding age range on the chart.",
        "Next Steps:\r\n\r\n    After completing these measurements and identification steps, you can proceed with the following (depending on your instructor's instructions):\r\n\r\n    External examination of the pig's body.\r\n    Internal dissection to observe and identify organs and organ systems.",
        "Remember:\r\n\r\n    Follow your instructor's specific instructions and ask questions if anything is unclear.\r\n    Dissect with care and respect for the specimen."
    };

    string[] activity2instructions = {
        "Activity 2: Dissection Techniques & Initial Incision",
        "Objective:  To learn safe and proper dissection techniques and make an initial incision to access the pig's internal anatomy.",
        "Safety Reminders:\r\n\r\n    Always cut away from your body and fingers.\r\n    Use tools for their intended purpose.\r\n    Inform the instructor immediately in case of any cuts or injuries.",
        "Tips:\r\n\r\n    Dissect slowly and carefully.\r\n    Use the probe to initially separate tissues before cutting.\r\n    Keep your work area clean and organized.",
        "Materials:\\r\\n\\r\\n    Dissecting tray\\r\\n    Preserved fetal pig\\r\\n    Dissection tools",
        "Preparation:\r\n\r\n    Put on gloves and safety goggles.\r\n    Position the pig on its back in the dissecting tray.",
        "Tool Selection:\r\n\r\n    Scalpel: Use for initial incisions into the skin. Handle with caution as blades are extremely sharp.\r\n    Scissors: Use for longer cuts and cutting through muscle tissue.\r\n    Forceps: Use for picking up and manipulating tissues.\r\n    Probe: Use for separating and exploring structures without cutting.",
        "Initial Incision\r\n\r\n    Locate the umbilical cord: Find the cord on the mid-abdomen.\r\n    Shallow cut: Using the scalpel, make a shallow U-shaped incision around the umbilical cord, cutting through the skin only.\r\n    Deepening the cut: Switch to scissors and carefully extend the incision upward towards the neck and downward towards the hind legs. Cut through muscle layers as needed.",
        "Flap Creation:\r\n\r\n    Gently lift the edges of the incision to create flaps of skin and muscle tissue.\r\n    Fold the flaps back to expose the underlying abdominal cavity.",
        "Next Steps\r\n\r\n    Observe the exposed internal organs of the abdominal cavity.\r\n    Proceed with further dissections as directed by your instructor.\r\n    Important: Your instructor may have specific variations on the incision pattern or additional instructions. Always follow their guidance closely."
        };
    private int currentPage;

    // Start is called before the first frame update
    void Start()
    {
        currentPage = 0;
        if (isAct1)
        {
            text.text = activity1instructions[currentPage];
        }
        else if (isAct2)
        {
            text.text = activity2instructions[currentPage];
        }
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
        if (currentPage > -1)
        {
            if(isAct1 && currentPage < activity1instructions.Length)
            {
                text.text = activity1instructions[currentPage];
            }
            else if(isAct2 && currentPage < activity2instructions.Length)
            {
                text.text = activity2instructions[currentPage];
            }
            else
            {
                currentPage = currentPage - change;
            }
        }
        else
        {
            currentPage = currentPage - change;
        }
    }
}
