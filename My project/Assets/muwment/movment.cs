using UnityEngine;

public class movment : MonoBehaviour
{
     public float moveSpeed = 5f; // Prêdkoœæ ruchu
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Pobierz komponent Rigidbody
    }

    void FixedUpdate()
    {
        // Pobierz wejœcie z klawiatury
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Stwórz wektor ruchu
        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);

        // Przesuñ postaæ za pomoc¹ Rigidbody
        rb.MovePosition(transform.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
