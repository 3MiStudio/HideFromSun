using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player3DMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public float rotationSpeed = 10f;
    public float acceleration = 10f;

    private Rigidbody rb;
    private bool isGrounded = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 inputDir = new(h, 0, v);
        Vector3 targetVelocity = inputDir.normalized * moveSpeed;
        Vector3 currentVelocity = new(rb.linearVelocity.x, 0, rb.linearVelocity.z);

        // Smooth acceleration
        Vector3 smoothedVelocity = Vector3.Lerp(currentVelocity, targetVelocity, acceleration * Time.deltaTime);
        rb.linearVelocity = new(smoothedVelocity.x, rb.linearVelocity.y, smoothedVelocity.z);

        // Smooth rotation toward movement direction
        if (inputDir != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(inputDir);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        // Jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        // movement restriction area
        Vector3 pos = transform.position;         
        pos.x = Mathf.Clamp(pos.x, -12f, 12f);      //   left/right
        pos.z = Mathf.Clamp(pos.z, -5f, 10f);    //   down/up
        transform.position = pos;

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = true;
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = false;
    }
}
