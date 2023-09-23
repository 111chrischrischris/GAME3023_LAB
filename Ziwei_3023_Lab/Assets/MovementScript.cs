using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public float movementSpeed = 1.0f;
    public Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector2 inputVector = new Vector2(horizontalInput, verticalInput);
        Vector2 normalizedInput = inputVector.normalized;

        rb.MovePosition(rb.position + new Vector2(normalizedInput.x * movementSpeed, normalizedInput.y * movementSpeed) * Time.deltaTime);
    }
}
