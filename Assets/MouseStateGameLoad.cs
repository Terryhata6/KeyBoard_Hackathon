using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseStateGameLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    private void OnApplicationFocus(bool ApplicationIsBack)
    {
        if (ApplicationIsBack)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
