using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PasswordHistoryPrefab : MonoBehaviour
{
    public TMP_InputField previousPasswordInputField;
    public Button revealPreviousPasswordButton;

    private void Start()
    {
        previousPasswordInputField = GetComponentInChildren<TMP_InputField>();
        revealPreviousPasswordButton = GetComponent<Button>();
        GetComponentInChildren<Button>().onClick.AddListener(revealSavedPassword);
    }

    public void revealSavedPassword() // This function allows the user to reveal previously generated passwords
    {
        if (previousPasswordInputField.contentType == TMP_InputField.ContentType.Password)
        {
            previousPasswordInputField.contentType = TMP_InputField.ContentType.Standard;
        }
        else
        {
            previousPasswordInputField.contentType = TMP_InputField.ContentType.Password;
        }
        previousPasswordInputField.ForceLabelUpdate(); // Forces the text in the InputField to rebuild itself.
    }
}