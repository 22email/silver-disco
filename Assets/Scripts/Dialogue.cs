using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public float typeSpeed;
    private int lineIndex;
    private string[] lines;

    public void StartDialogue(string[] lines) 
    {
        //Receive the lines from the NPC
        this.lines = lines;

        //Stop any typing (in case the player presses E when the dialogue is still playing)
        StopAllCoroutines();

        //Make the dialogue box appear (empty)
        gameObject.SetActive(true);
        textComponent.text = string.Empty;

        lineIndex = 0;

        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine() 
    {
        //Type out each character in the line individually
        foreach(char c in lines[lineIndex]) 
        {
            textComponent.text += c;
            yield return new WaitForSeconds(typeSpeed);
        }
    }

    void NextLine() 
    {
        //If we will not reach the end of the list of lines yet, proceed to the next line
        if (lineIndex < lines.Length - 1)
        {
            lineIndex++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }

        //Else, if all the lines have been finished, make the dialogue box disappear
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void ProceedDialogue(InputAction.CallbackContext context) {
        //If the Enter key was CLICKED...
        if (context.performed) {
            //If the text has finished typing, move to the next line
            if (textComponent.text == lines[lineIndex])
            {
                NextLine();
            }

            //Else, the Enter key will make all text appear instantly
            else {
                StopAllCoroutines();
                textComponent.text = lines[lineIndex];
            }
        }
    }
}
