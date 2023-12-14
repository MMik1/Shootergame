using UnityEngine;
using UnityEngine.SceneManagement;

public class death : MonoBehaviour
{
    public float movementSpeed = 5f;

    private void Update()
    {
        // Handle player movement
        MovePlayer();

        // Check for player death
        if (Input.GetKeyDown(KeyCode.Space)) // You can replace this with your own death condition
        {
            Die();
        }
    }

    private void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * movementSpeed * Time.deltaTime;
        transform.Translate(movement);
    }

    private void Die()
    {
        // Load the "You Died" scene
        SceneManager.LoadScene("YouDiedScene");
    }
}
