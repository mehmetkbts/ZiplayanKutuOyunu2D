using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class CharacterSpawner : MonoBehaviour
{
    public GameObject[] characters;
    int index = 0;
    void Start()
    {
        index = CharacterSelection.currentIndex;
        Debug.Log("Index : " + index);

        int selected = index;

        if (selected >= 0 && selected < characters.Length)
        {
            GameObject selectedCharacterPrefab = characters[selected];
            Instantiate(selectedCharacterPrefab, transform.position, Quaternion.identity);

        }
        else
        {
            Debug.Log("Index degeri hatalý");
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1.0f;
    }


}
