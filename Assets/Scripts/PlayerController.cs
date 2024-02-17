using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 0f;
    [SerializeField] float movementSpeed = 0f;
    private Vector3 initialPosition = Vector3.zero;
    private Quaternion initialRotation = Quaternion.identity;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = gameObject.transform.position;
        initialRotation = gameObject.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        Rotate(HorizontalController());
        Move(VerticalController());
    }

    //Get Axis from the horizontal player control.  
    float HorizontalController()
    {
        return Input.GetAxis("Horizontal");
    }

    //Get Axis from the vertical player control. 
    float VerticalController()
    {
        return Input.GetAxis("Vertical");
    }

    void Rotate(float rotation)
    {
        transform.Rotate(new Vector3(0, rotation, 0) * rotationSpeed);
    }

    //Set a new movement for the player specified by the controller and movement speed.
    void Move(float movement)
    {
        gameObject.GetComponent<CharacterController>().Move(transform.TransformDirection(new Vector3(0, 0, movement) * movementSpeed * Time.deltaTime));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.StartsWith("Sphere"))
        {
            Destroy(other.gameObject);
            GameManager.Instance.UpdateScore(1f);
        }

        if (other.name.StartsWith("Enemy"))
        {
            Debug.Log("<b><color=purple>GOKU: YA BASTA FREEZER!!</color></b>");
            GameManager.Instance.UpdateScore(-1f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name.StartsWith("Enemy"))
        {
            Debug.Log("<b><color=purple>GOKU: YA BASTA FREEZER!!</color></b>");
        }
    }
}
