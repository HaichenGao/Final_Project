using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
    // static bool created = false;

    void Awake() {
        // if (!created) {
            DontDestroyOnLoad(this.gameObject);
        //     created = true;
        // } else {
        //     Destroy (this.gameObject);
        // }
    }
}
