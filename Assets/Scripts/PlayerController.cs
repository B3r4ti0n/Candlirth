using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera mainCamera;
    public Rigidbody2D rb;
    public float jumpForce = 5f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius = 0.1f;
    public int jumpMaxBase = 2;
    public int jumpMax = 0;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        jumpMax = jumpMaxBase;
    }

    private void FixedUpdate() {
        //CheckGrounded();
        //Pulsed();
    }

    private void Pulsed(){
        if (jumpMax > 0) {
            Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;

            Vector3 direction = mousePosition - transform.position;
            direction*=jumpForce;
            direction = new Vector3(direction.x > 9 ? 9: direction.x, direction.y > 9 ? 9: direction.y,0);
            
            rb.velocity = direction;
            jumpMax--;
            
        }
    }
    
    /*private void OnTriggerEnter2D(Collider2D other) {
        jumpMax = jumpMaxBase;
    }*/
    private void OnTriggerStay2D(Collider2D other) {
        jumpMax = jumpMaxBase;
    }

    void OnMouseLeft(){
        Pulsed();
    }
}