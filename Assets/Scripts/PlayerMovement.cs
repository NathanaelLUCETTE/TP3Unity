using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;

    private Rigidbody rb;
    private Animator animator;
    private bool isGrounded = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0f, vertical);

        // Déplacement
        transform.Translate(movement * moveSpeed * Time.deltaTime);

        // Animation de marche
        animator.SetFloat("Speed", movement.magnitude);

        // Rotation vers la direction de déplacement
        if (movement.magnitude > 0.1f)
        {
            transform.rotation = Quaternion.LookRotation(movement);
        }

        // Saut
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("ESPACE PRESSE - isGrounded = " + isGrounded);

            if (isGrounded)
            {
                Debug.Log("SAUT !");

                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

                animator.SetTrigger("Jump");

                isGrounded = false;
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            Debug.Log("JOUEUR SUR LE SOL");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}