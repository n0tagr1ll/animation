using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem; //her bruger vi unity input system

public class NewMonoBehaviourScript : MonoBehaviour
{
    private Vector2 movement; //bevægelse af playeren
    private Rigidbody2D myBody; 
    private Animator myAnimator; //animator til playeren


    [SerializeField] private int speed = 5; //hastighed på playeren

    private void Awake() //awake funktion som køre når scriptet bliver loadet
    {
        myBody = GetComponent<Rigidbody2D>(); //henter rigidbody2d componenten
        myAnimator = GetComponent<Animator>(); //henter animator componenten
    }

    private void OnMovement(InputValue value) //funktion som køre når der bliver givet input til bevægelse
    {
        movement = value.Get<Vector2>(); //sætter movement variablen til den værdi som bliver givet fra input systemet

        if (movement.x != 0 || movement.y != 0) //tjekker om der er bevægelse
        {

            myAnimator.SetFloat("x", movement.x); //sætter animatorens x parameter til movement x værdien
            myAnimator.SetFloat("y", movement.y); //sætter animatorens y parameter til movement y værdien

            myAnimator.SetBool("IsWalking", true); //sætter animatorens IsWalking parameter til true
        }
        else
            myAnimator.SetBool("IsWalking", false); //ellers sætter den til false
    }

    private void FixedUpdate() //fixed update funktion som køre hver frame
    {
        myBody.linearVelocity = movement * speed; //sætter rigidbody2dens linear velocity til movement værdien gange med speed værdien
    }
}