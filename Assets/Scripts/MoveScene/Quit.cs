using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "SceneMove/Quit")]
public class Quit : ButtonMoveScene
{
    public override void Execute()
    {
        Application.Quit();
    }
}
