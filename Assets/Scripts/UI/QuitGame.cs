using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void QuitProgram()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

}
