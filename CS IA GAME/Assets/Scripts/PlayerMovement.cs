using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // Main character is called "Ballie"
    public float ballieSpeed = 5f;
    public float jump = 5f;
    public float jumpTime = 2f;


    void FixedUpdate()
    {
        Jump();
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f,0f);
        transform.position += movement * Time.deltaTime * ballieSpeed;

        if (gameObject.GetComponent<Rigidbody2D>().position.y < -5f)
        {
            FindObjectOfType<GameManager>().GameOver();
        }

        jumpTime += Time.deltaTime;

    }

    void Jump()
    {

        if (Input.GetButtonDown("Jump") && jumpTime > 0.5f)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(
                new Vector2(0f, jump), ForceMode2D.Impulse);
            jumpTime = 0f;
        }
    }

}

