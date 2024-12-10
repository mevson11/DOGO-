using UnityEngine;

public class jump : MonoBehaviour
{
    public float moveSpeed = 5f; // Pr�dko�� ruchu
    public float jumpForce = 5f; // Si�a skoku
    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Pobierz komponent Rigidbody
    }

    void Update()
    {
        // Pobierz wej�cie z klawiatury
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Stw�rz wektor ruchu
        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);

        // Przesu� posta� za pomoc� Rigidbody
        rb.MovePosition(transform.position + movement * moveSpeed * Time.deltaTime);

        // Sprawd�, czy posta� jest na ziemi i czy naci�ni�to spacj�
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void Jump()
    {
        // Dodaj si�� do skoku
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false; // Ustaw flag� isGrounded na false po skoku
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Sprawd�, czy posta� dotyka ziemi
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // Ustaw flag� isGrounded na true, gdy dotykasz ziemi
        }
    }
}
