using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class gameManager : MonoBehaviour
{
    public static gameManager Instance;
    public string spawnPointID = "default";

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadScene(string sceneName, string destinationID)
    {
        spawnPointID = destinationID;
        StartCoroutine(LoadSceneAndPositionPlayer(sceneName));
    }

    private IEnumerator LoadSceneAndPositionPlayer(string sceneName)
    {
        // Load the scene asynchronously
        yield return SceneManager.LoadSceneAsync(sceneName);

        // Wait a frame to make sure the scene is ready
        yield return null;

        // Find the player and the spawn point
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        SceneEntryPoint[] entryPoints = GameObject.FindObjectsByType<SceneEntryPoint>(FindObjectsSortMode.None);


        foreach (SceneEntryPoint point in entryPoints)
        {
            if (point.ID == spawnPointID)
            {
                if (player != null)
                {
                    player.transform.position = point.transform.position;
                }
                else
                {
                    Debug.LogWarning("Player not found in new scene.");
                }
                yield break;
            }
        }

        Debug.LogWarning("No SceneEntryPoint with ID: " + spawnPointID);
    }
}
