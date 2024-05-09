using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // 开始页面菜单
    // Start is called before the first frame update
    public void GamePlay()
    {
        int SelectedCharacter =
        int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
        Manager.instance.CharIndex = SelectedCharacter;
        SceneManager.LoadScene("GamePlay");
    }
}
