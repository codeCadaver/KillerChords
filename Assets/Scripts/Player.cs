using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] Vector2 position;
    [SerializeField] float rotateWalkAmount = 200f;

    PlayerInput playerInput;
    Vector2 move;
    Vector3 defaultRotation;
    Vector3 rotateCharacter;

    private void Awake()
    {
        playerInput = new PlayerInput();

        playerInput.Player.Move.performed += Move;
        playerInput.Player.Move.canceled += context => move = Vector2.zero;
        playerInput.Player.Strum.performed += Strum;
        playerInput.Player.Swing.performed += Swing;
        playerInput.Player.Jump.performed += Jump;
    }

    private void Start()
    {
        defaultRotation = transform.eulerAngles;
        rotateCharacter = transform.eulerAngles;
    }

    private void Jump(InputAction.CallbackContext context)
    {
        Debug.Log("Player has Jumped");
    }

    private void Strum(InputAction.CallbackContext context)
    {
        Debug.Log("Player Strummed");
    }

    private void Swing(InputAction.CallbackContext context)
    {
        Debug.Log("You swung the guitar");
    }

    private void Move(InputAction.CallbackContext context)
    {
        //flipCharacter.x = 1f;
        move = context.ReadValue<Vector2>();
        if(move.x < 0)
        {
            //flipCharacter.z = -1f;
            rotateCharacter.y = defaultRotation.y + rotateWalkAmount;
            transform.eulerAngles = rotateCharacter;
        } else
        {
            transform.eulerAngles = defaultRotation;

        }
        //transform.localScale = flipCharacter;
    }

    // Update is called once per frame
    void Update()
    {
        // MovePlayer
        Vector2 movement = new Vector2(move.x, move.y) * Time.deltaTime * moveSpeed;
        transform.Translate(movement, Space.World);
    }

    private void OnEnable()
    {
        playerInput.Player.Enable();
    }

    private void OnDisable()
    {
        playerInput.Player.Disable();
    }
}
