using UnityEngine;
using UnityEngine.UI;

public class SceneCommandButton : MonoBehaviour
{
    public ButtonMoveScene command;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            if (command != null)
                command.Execute();
        });
    }
}
