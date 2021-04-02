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
        previousPasswordInputField = GetComponentInChildren<TMP_InputField>(); // Locates the InputField so its ContentType can be altered.
        revealPreviousPasswordButton = GetComponent<Button>(); // Locates the button so that functions can be added.
        GetComponentInChildren<Button>().onClick.AddListener(revealSavedPassword); // Adds revealSavedPassword() to the button located next to previously generated password.
    }

    public void revealSavedPassword() // This function allows the user to reveal previously generated passwords. By setting the ContentType to "Standard", this will display the password.
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