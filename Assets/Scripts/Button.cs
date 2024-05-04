using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public InputActionAsset actionAsset;

    public Text textUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var rightAButton = actionAsset.actionMaps[5].actions[0].ReadValue<float>();

        textUI.text = rightAButton.ToString();
    }
}
