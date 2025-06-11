using UnityEngine;

public class PuzzleClickTrigger : MonoBehaviour
{
    public GameObject puzzleUI;
    private bool isPuzzleOpen = false;

    private void OnMouseDown()
    {
        if (!isPuzzleOpen && puzzleUI != null)
        {
            puzzleUI.SetActive(true);
            Time.timeScale = 0f;
            isPuzzleOpen = true;
        }
    }

    // This method can be called from the close button to reset the flag
    public void ClosePuzzle()
    {
        if (puzzleUI != null)
        {
            puzzleUI.SetActive(false);
            Time.timeScale = 1f;
            isPuzzleOpen = false;
        }
    }
}
