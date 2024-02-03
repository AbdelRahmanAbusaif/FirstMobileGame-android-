using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ballController : MonoBehaviour
{
    // Variables
    Vector3 throwbale;  // The vector representing the direction and strength of the throw
    private Rigidbody2D rb;  // Reference to the Rigidbody2D component of the ball
    private LineRenderer ln;  // Reference to the LineRenderer component for drawing the throw arrow

    [Header("Customize")]
    public float BallPowerThrow = 450f;  // Customize the power of the ball throw through the Unity Inspector
    bool DragMouse=false;

    void Start()
    {
        // Get references to components
        rb = GetComponent<Rigidbody2D>();
        ln = GetComponent<LineRenderer>();
    }
    /*private void OnMouseDown()
    {
        // When the mouse button is pressed down, calculate and show the throw vector
        CalculateThrowVector();
        SetArrow();
    }
    */
    private void OnMouseDrag()
    {
        // While the mouse is dragged, recalculate and update the throw vector and arrow
        CalculateThrowVector();
        SetSlowMotion();
        SetArrow();
        //changeScale();
        DragMouse = true;
    }

    void CalculateThrowVector()
    {
        // Calculate the throw vector based on the mouse position
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 distance = mousePos - (Vector3)transform.position;
        // Normalize the distance to get the direction and multiply by the throw power
        throwbale = -distance.normalized * BallPowerThrow;

    }
    void SetSlowMotion()
    {
        // Trigger slow-motion
        Time.timeScale = 0.2f;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }
    void SetArrow()
    {
        // Display the throw arrow using LineRenderer
        ln.positionCount = 2;
        // Set the positions relative to the ball's position
        ln.SetPosition(0, transform.position);

        // Calculate the reflected vector based on the throwbale vector
        Vector3 reflectedThrowbale = Vector2.Reflect(throwbale.normalized, Vector3.back);
        float lineLengthMultiplier = 2.0f;
        Vector3 DirectionLine = transform.position + reflectedThrowbale * lineLengthMultiplier;
        //SetPlayerRotation(DirectionLine);
        // Set the reflected vector as the second position
        ln.SetPosition(1, DirectionLine); // Set the arrow length to half of the throw vector
        ln.enabled = true;
    }
    /*void changeScale()
    {
        if(transform.localScale.y>0.65)
        {
            float scaleChange = Time.deltaTime; // Use Time.deltaTime for smooth scaling over time
            Vector3 newScale = transform.localScale - new Vector3(0f, scaleChange, 0f);
            transform.localScale = newScale;
        }
    }*/
    /*void SetPlayerRotation(Vector3 lineDirection)
    {
        DragMouse = true;
        // Calculate the angle in degrees between the line direction and the forward vector (assuming z-axis is forward)
        float angle = Mathf.Atan2(lineDirection.y, lineDirection.x) * Mathf.Rad2Deg;

        // Create a quaternion rotation based on the calculated angle
        Quaternion targetRotation = Quaternion.Euler(0f, 0f, angle+30);

        // Apply the rotation to the player's object
        if(targetRotation!=null)
        {
            transform.rotation = targetRotation;
        }
        else
        {
            transform.rotation = Quaternion.identity;
        }
    }*/
    private void OnMouseUp()
    {
        // When the mouse button is released, remove the arrow and throw the ball
        RemoveArrow();
        ThrowTheBall();
        returnSlowMotion();
        //ReturnScale();
        DragMouse = false;
    }

    void RemoveArrow()
    {
        // Disable the LineRenderer to hide the arrow
        ln.enabled = false;
    }
    void returnSlowMotion()
    {
        // To revert to normal time
        Time.timeScale = 1.0f;
        Time.fixedDeltaTime = 0.02f;
    }
    /*void ReturnScale()
    {
        if (transform.localScale.y < 1)
        {
            float scaleChange = Time.deltaTime; // Use Time.deltaTime for smooth scaling over time
            Vector3 newScale = transform.localScale + new Vector3(0f, scaleChange, 0f);
            transform.localScale = newScale;
        }
    }*/
    /*void ReturnRotation()
    {
        Quaternion constantRotation = Quaternion.identity;  // Quaternion.identity represents no rotation
        transform.rotation = constantRotation;
    }*/
    void ThrowTheBall()
    {
        // Apply force to the ball based on the calculated throw vector
        rb.AddForce(throwbale);
    }
    
}
