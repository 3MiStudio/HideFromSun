using UnityEngine;

public class PuzzleCloseButton : MonoBehaviour
{
    public PuzzleClickTrigger puzzleTrigger;

    public void ClosePuzzle()
    {
        Debug.Log("Close button clicked");
        if (puzzleTrigger != null)
        {
            puzzleTrigger.ClosePuzzle();
        }
        else
        {
            Debug.LogWarning("PuzzleTrigger reference is missing!");
        }
    }
}
