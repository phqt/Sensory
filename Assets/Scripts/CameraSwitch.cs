using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public GameObject camera1;
    public GameObject camera2;

    private bool switchCamera = false;
    private float timer = 0f;
    private int filmsCollected = 0;

    private void Update()
    {
        
        if (!switchCamera && camera2 == null)
        {
            // Set the active camera to camera 1
            camera1.SetActive(true);
        }

        // Check if the player has collected enough films
        if (filmsCollected >= 1 && !switchCamera && camera2 != null)
        {
            // Set the active camera to camera 2 and start the timer
            camera1.SetActive(false);
            camera2.SetActive(true);
            switchCamera = true;
            timer = 5f;
        }

        // If the camera is switched, start the countdown timer
        if (switchCamera)
        {
            timer -= Time.deltaTime;

            // If the timer reaches 0, destroy camera 2 and switch back to camera 1
            if (timer <= 0f)
            {
                Destroy(camera2);
                camera1.SetActive(true);
                switchCamera = false;
            }
        }
        int ammoCount = GameObject.Find("Player").GetComponent<AmmoSystem>().currentAmmo;
        filmsCollected = ammoCount;
    }
}
