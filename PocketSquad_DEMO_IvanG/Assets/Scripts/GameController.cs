using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance; // Singleton instance for global access
    private BallController selectedBall;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        // Check for clicks around the selected ball
        if (selectedBall != null && Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit))
            {
                // Ensure the click was not on a ball itself
                if (hit.transform.CompareTag("Ball") == false)
                {
                    // Calculate the direction from the ball to the click position
                    Vector3 clickPosition = hit.point;
                    Vector3 ballPosition = selectedBall.transform.position;

                    // Calculate direction vector in both X and Z axes
                    Vector3 direction = (clickPosition - ballPosition);
                    
                    // Apply this direction to move the ball
                    selectedBall.MoveBall(direction);
                }
            }
        }
    }

    public void SelectBall(BallController ball)
    {
        selectedBall = ball;
        ball.isSelected = true;
    }
}
