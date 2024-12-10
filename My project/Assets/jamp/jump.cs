using UnityEngine;

public class jump : MonoBehaviour
{
    public float moveSpeed = 5f; // Prêdkoœæ ruchu
    public float jumpForce = 5f; // Si³a skoku
    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Pobierz komponent Rigidbody
    }

    void Update()
    {
        // Pobierz wejœcie z klawiatury
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Stwórz wektor ruchu
        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);

        // Przesuñ postaæ za pomoc¹ Rigidbody
        rb.MovePosition(transform.position + movement * moveSpeed * Time.deltaTime);

        // SprawdŸ, czy postaæ jest na ziemi i czy naciœniêto spacjê
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void Jump()
    {
        // Dodaj si³ê do skoku
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false; // Ustaw flagê isGrounded na false po skoku
    }

    private void OnCollisionEnter(Collision collision)
    {
        // SprawdŸ, czy postaæ dotyka ziemi
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // Ustaw flagê isGrounded na true, gdy dotykasz ziemi
        }
    }
}
