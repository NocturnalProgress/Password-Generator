using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Engine : MonoBehaviour
{
    public Toggle includeUppercase, includeLowercase, includeNumbers, includeSymbols;

    public Slider passwordLengthSlider;

    public string generatedPassword;

    public TMP_InputField passwordLengthDisplay, generatedPasswordInputField;

    public GameObject previousPasswordPrefab, passwordHistoryScrollView;

    private int passwordLength = 6;

    private List<string> uppercaseLetterList = new List<string>(new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" });

    private List<string> lowercaseLettersList = new List<string>(new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" });

    private List<string> numbersList = new List<string>(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" });

    private List<string> symbolsList = new List<string>(new string[] { "!", "#", "$", "%", "&", "(", ")", "+", "-", "/", ":", ";", "@", "[", "/", "]", "^", "_", "|", "~" });

    public void GenPass()
    {
        for (generatedPassword = ""; generatedPassword.Length < passwordLength;) // Continues looping until the generated password's length is equal to the desired password length.
        {
            int randomNumber = Random.Range(1, 5); // Creates a random number for the Switch Case to randomly add Uppercase or Lowercase Letters, Numbers, or Symbols.

            switch (randomNumber)
            {
                case 4: // Checks if the Toggle for Uppercase Letters is on.
                    if (includeUppercase.isOn)
                    {
                        generatedPassword += uppercaseLetterList[Random.Range(0, uppercaseLetterList.Count)];
                    }
                    break;

                case 3: // Checks if the Toggle for Lowercase Letters is on.
                    if (includeLowercase.isOn)
                    {
                        generatedPassword += lowercaseLettersList[Random.Range(0, lowercaseLettersList.Count)];
                    }
                    break;

                case 2: // Checks if the Toggle for Numbers is on.
                    if (includeNumbers.isOn)
                    {
                        generatedPassword += numbersList[Random.Range(0, numbersList.Count)];
                    }
                    break;

                case 1: // Checks if the Toggle for Symbols is on.
                    if (includeSymbols.isOn)
                    {
                        generatedPassword += symbolsList[Random.Range(0, symbolsList.Count)];
                    }
                    break;

                default: // This shouldn't ever happen but who knows what could occur when someone is using this. (Also a default case is required.)
                    Debug.Log("Uh what?");
                    break;
            }
        }
        generatedPasswordInputField.text = generatedPassword; // Outputs the newly generated password to the "Generated Password" InputField.
        savePreviousPassword(); // Calls the function to instantiate a prefab
    }

    public void setPasswordLengthDisplay() // Sets the Password Length Input Field to the value of the Slider. (This function is called every time the Slider is moved.)
    {
        passwordLengthDisplay.text = passwordLengthSlider.value.ToString();
    }

    public void checkPasswordLengthDisplayNumber() // Ensures that the Password Length Input Field is no more than 420 and no less than 6. (This function is called when the Password Length Display is updated.)
    {
        bool success = int.TryParse(passwordLengthDisplay.text, out passwordLength); // If int.TryParse is able to convert the text in the Password Length Display into an integer, then the bool is true.

        if (success)
        {
            if (passwordLength > 420) // Ensures that the password length does not exceed 420.
            {
                passwordLengthDisplay.text = "420";
            }
        }
        else // If the int.TryParse is unable to convert the Password Length Display text into an integer, then the text in the Input Field is set to 6.
        {
            passwordLengthDisplay.text = "6";
        }
    }

    public void toggleCheck() // Checks if all Toggles are off at the same time. If they are then they reset.
    {
        if (!includeUppercase.isOn && !includeLowercase.isOn && !includeNumbers.isOn && !includeSymbols.isOn)
        {
            includeUppercase.isOn = true;
            includeLowercase.isOn = true;
            includeNumbers.isOn = true;
            includeSymbols.isOn = true;
        }
    }

    public void savePreviousPassword() // Creates a prefab which lets the user see their previously generated passwords.
    {
        GameObject previousPassword = Instantiate(previousPasswordPrefab, new Vector3(0, 0, 0), transform.rotation) as GameObject; // Creates a Previous Password Prefab
        previousPassword.transform.SetParent(passwordHistoryScrollView.transform, false); // Sets the parent of the new gameobject to the "Content" GameObject under the ScrollView.
        previousPassword.transform.localScale = new Vector3(1, 1, 1); // Ensures that the scale of the GameObject is (1, 1, 1)
        previousPassword.GetComponentInChildren<TMP_InputField>().text = generatedPassword; // Sets the current password to the InputField of the prefab so that it can be saved and another password can be generated.
    }
}