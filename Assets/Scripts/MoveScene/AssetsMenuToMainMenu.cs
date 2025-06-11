using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "SceneMove/MainMenu")]
public class AssetMenuToMainmenu : ButtonMoveScene
{
    public override void Execute()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
