using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "SceneMove/CreditsScene")]
public class AssetMenuToCreditsScene : ButtonMoveScene
{
    public override void Execute()
    {
        SceneManager.LoadScene("Credits");
    }
}
