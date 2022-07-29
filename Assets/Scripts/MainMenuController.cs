using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //add thêm để sử dụng

public class MainMenuController : MonoBehaviour
{
public void playGame()
    {
        //string clickedObj = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        //hoặc EventSystem.current.currentSelectedGameObject.name khi add thư viện UnityEngine.EventSystems
        
        int selectedCharacter = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
        GameManager.instance.charIndex = selectedCharacter;
        SceneManager.LoadScene("GamePlay");
    }
}
