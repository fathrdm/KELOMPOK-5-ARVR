using UnityEngine;

public abstract class ButtonMoveScene : ScriptableObject, IMoveScene
{
    public abstract void Execute();
}
