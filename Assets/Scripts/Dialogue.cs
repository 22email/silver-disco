using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float typeSpeed;
    private int lineIndex;

    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    void StartDialogue() 
    {
        lineIndex = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine() 
    {
        foreach(char c in lines[lineIndex]) 
        {
            textComponent.text += c;
            yield return new WaitForSeconds(typeSpeed);
        }
    }

    void NextLine() 
    {
        if (lineIndex < lines.Length - 1)
        {
            lineIndex++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void ProceedDialogue(InputAction.CallbackContext context) {
        if (context.performed) {
            if (textComponent.text == lines[lineIndex])
            {
                NextLine();
            }
            else {
                StopAllCoroutines();
                textComponent.text = lines[lineIndex];
            }
        }
    }
}
