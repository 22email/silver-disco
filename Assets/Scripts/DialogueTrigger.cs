using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private Dialogue dialogueScript;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private float hearingRange;
    [SerializeField] private string[] lines;

    private bool playerInRange;

    // Start is called before the first frame update
    void Start()
    {
        playerInRange = false;
    }

    // Update is called once per frame
    void Update()
    {
        playerInRange = Physics2D.OverlapCircle(transform.position, hearingRange, playerLayer);
    }

    public void StartDialogue(InputAction.CallbackContext context) {
        //If the Enter key was CLICKED...
        if (context.performed && playerInRange) {
            dialogueScript.StartDialogue(lines);
        }
    }
}
