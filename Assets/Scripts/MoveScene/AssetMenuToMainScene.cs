using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "SceneMove/MainScene")]
public class AssetMenuToMainScene : ButtonMoveScene
{
    public override void Execute()
    {
        SceneManager.LoadScene("MainScene");
    }
}
