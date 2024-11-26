using UnityEngine;

public class movment : MonoBehaviour
{
     public float moveSpeed = 5f; // Pr�dko�� ruchu
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Pobierz komponent Rigidbody
    }

    void FixedUpdate()
    {
        // Pobierz wej�cie z klawiatury
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Stw�rz wektor ruchu
        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);

        // Przesu� posta� za pomoc� Rigidbody
        rb.MovePosition(transform.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
