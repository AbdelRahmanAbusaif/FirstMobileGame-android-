using UnityEngine;

public class TragectoryLine : MonoBehaviour
{
    public LineRenderer ln;
    Vector3 throwbale;
    float ballPowerThrow = 450f;
    private void Awake()
    {
        ln=GetComponent<LineRenderer>();   
    }
    private void OnMouseDown()
    {
        CalculateThrowVector();
    }
    private void OnMouseDrag()
    {
        CalculateThrowVector();
    }
    void CalculateThrowVector()
    {
        // Calculate the throw vector based on the mouse position
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 distance = mousePos - (Vector3)transform.position;
        // Normalize the distance to get the direction and multiply by the throw power
        throwbale = -distance.normalized * ballPowerThrow;
    }
    public void RenderLine()
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
    public void EndLine()
    {
        ln.enabled = false; 
    }
}
