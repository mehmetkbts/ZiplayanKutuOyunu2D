using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class CharacterSelection : MonoBehaviour
{
    public List<GameObject> characters = new List<GameObject>();
    public TextMeshProUGUI characterName;
    public Button selectButton;

    public static int currentIndex = 0;


    void Start()
    {
        UpdateCharacterDisplay();
        selectButton.onClick.AddListener(OnSelectButtonClicked);

    }

    void UpdateCharacterDisplay()
    {
        foreach (var character in characters)
        {
            character.SetActive(false);
        }
        characters[currentIndex].SetActive(true);

        characterName.text = characters[currentIndex].name;

    }

    public void OnRightButtonClicked()
    {
        currentIndex = (currentIndex + 1) % characters.Count;

        UpdateCharacterDisplay();

    }

    public void OnLeftButtonClicked()
    {
        currentIndex = ( currentIndex - 1 ) % characters.Count;

        UpdateCharacterDisplay();
    }

    void OnSelectButtonClicked()
    {
        SceneManager.LoadScene(1);
        PlayerPrefs.SetInt("SelectedCharacterIndex", currentIndex);
        PlayerPrefs.Save();

    }



}
