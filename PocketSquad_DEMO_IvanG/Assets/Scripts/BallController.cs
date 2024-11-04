using UnityEngine;

public class BallController : MonoBehaviour
{
    public bool isSelected = false;
    public float initialVelocity = 5f;

    public float currentVelocity;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // Update current velocity based on rigidbody's linear velocity
        currentVelocity = rb.linearVelocity.magnitude;
    }

    private void OnMouseDown()
    {
        GameController.Instance.SelectBall(this); // Notify GameController to select this ball
    }

    public void MoveBall(Vector3 direction)
    {
        // Apply velocity in the opposite direction to the specified direction
        rb.linearVelocity = -direction.normalized * initialVelocity;
    }
}
