// InstructionManager.cs
using UnityEngine;
using UnityEngine.UI;

public class InstructionManager : MonoBehaviour
{
    public Text instructionText;
    private string[] instructions = 
    {
        "Obtain a fetal pig, dissection tray, gloves, ruler, scissors, a probe, tweezers, and a scalpel.",
        "Place the fetal pig on your dissecting tray.",
        "Ensure the pig is positioned on its back.",
        "Use the ruler to measure the length along the dorsal side, from the tip of the snout to the tail to estimate its age."
    };
    private int currentInstructionIndex = 0;

    void Start()
    {
        UpdateInstruction();  // Initialize the first instruction on start
    }

    public void NextInstruction()
    {
        if (currentInstructionIndex < instructions.Length - 1)
        {
            currentInstructionIndex++;
            UpdateInstruction();
        }
    }

    private void UpdateInstruction()
    {
        instructionText.text = instructions[currentInstructionIndex];
    }
}
