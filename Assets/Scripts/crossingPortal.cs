using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class crossingPortal : MonoBehaviour
{

    public string targetScene;
    public string targetSpawnID;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Call gameManager to load the scene with the correct spawn ID
            gameManager.Instance.LoadScene(targetScene, targetSpawnID);
        }
    }
}
// Start is called before the first frame update


    // Update is called once per frame
