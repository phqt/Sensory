using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBind : MonoBehaviour
{

    public Transform character;
   

    [SerializeField] private float sensX = 100f;
    [SerializeField] private float sensY = 100f;



    float mouseX;
    float mouseY;

    float multiplier = 0.01f;

    float xRotation;
    float yRotation;

    // Start is called before the first frame update

    void Reset()
    {
        character = GetComponentInParent<PlayerMovement>().transform;
    }
  

    void Start()
    {

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") ;
        float mouseY = Input.GetAxisRaw("Mouse Y") ;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        character.rotation = Quaternion.Euler(0, yRotation, 0);

    }
}
