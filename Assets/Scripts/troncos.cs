using UnityEngine;

public class Troncos : MonoBehaviour
{
    [SerializeField]
    private float velocidad = 5f;
    [SerializeField]
    private float resetOffset = -65f;

    private Transform playerTransform; 

    void Update()
    {
        transform.Translate(velocidad * Time.deltaTime, 0, 0);

        if (playerTransform != null)
        {
            Vector3 playerPosition = playerTransform.position;
            playerPosition.x = transform.position.x;
            playerTransform.position = playerPosition;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LimiteCocheIzquierda") || other.CompareTag("LimiteCocheDerecha"))
        {
            transform.Translate(resetOffset, 0, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerTransform = collision.transform; 
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerTransform = null;
        }
    }
}
