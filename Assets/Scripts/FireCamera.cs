using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCamera : MonoBehaviour
{
    public GameObject TheCamera;
    public bool IsFlashing = false;

    public float TargetDistance;
    public int DamageAmount = 5;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (IsFlashing == false)
            {
                StartCoroutine(FlashingCamera());
            }
        }
    }

    IEnumerator FlashingCamera ()
    {
        IsFlashing = true;
        RaycastHit Shot;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot))
        {
            TargetDistance = Shot.distance;
            Shot.transform.SendMessage("DamageEnemy", DamageAmount, SendMessageOptions.DontRequireReceiver);
        }

        yield return new WaitForSeconds(4.0f);
        IsFlashing = false;
    }
}
