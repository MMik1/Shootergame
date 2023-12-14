using UnityEngine;

public class MouseUnlock : MonoBehaviour
{
    // Call this method when you want to unlock the cursor
    public void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None; // Unlock the cursor
        Cursor.visible = true; // Make the cursor visible
    }

    // Call this method when you want to lock the cursor again (e.g., in another scene)
    public void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor
        Cursor.visible = false; // Hide the cursor
    }
}
