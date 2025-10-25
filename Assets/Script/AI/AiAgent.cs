using UnityEngine;

public class AiAgent : MonoBehaviour
{
    public AiStateMachine stateMachine;
    public AiStateId initialState;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        stateMachine = new AiStateMachine(this);
        stateMachine.ChangeState(initialState);
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.Update();
    }
}
