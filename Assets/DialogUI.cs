using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private TMP_Text textLabel;

    // Start is called before the first frame update
    private void Start()
    {
        GetComponent<TypeWriterEffect>().Run("This is text and it is working", textLabel);
    }

}
