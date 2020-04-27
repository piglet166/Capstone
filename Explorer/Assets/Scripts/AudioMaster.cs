using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMaster : MonoBehaviour
{
    
    private void Awake() {
        DontDestroyOnLoad(transform.gameObject);
    }


}
