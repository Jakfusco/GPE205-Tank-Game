using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TankData))]
[RequireComponent(typeof(TankMotor))]
[RequireComponent(typeof(TankShooter))]
public class InputController : MonoBehaviour
{
    private TankData data;
    private TankMotor motor;
    private TankShooter shooter;

    public enum InputScheme { WASD, arrowKeys };
    public InputScheme inputScheme = InputScheme.arrowKeys;

    // Start is called before the first frame update
    void Start()
    {
        data = GetComponent<TankData>();
        motor = GetComponent<TankMotor>();
        shooter = GetComponent<TankShooter>();
    }

    // Update is called once per frame
    void Update()
    {
      
        switch (inputScheme)
        {
            case InputScheme.arrowKeys:
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    motor.Move(data.moveSpeed);
                }
                else if (Input.GetKey(KeyCode.DownArrow))
                {
                    motor.Move(-data.moveSpeed);
                }
                else
                {
                    motor.Move(0);
                }
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    motor.Rotate(-data.turnSpeed);
                }
                else if (Input.GetKey(KeyCode.LeftArrow))
                {
                    motor.Rotate(data.turnSpeed);
                }
                break;
            case InputScheme.WASD:
                if (Input.GetKey(KeyCode.W))
                {
                    motor.Move(data.moveSpeed);
                }
                else if (Input.GetKey(KeyCode.S))
                {
                    motor.Move(-data.moveSpeed);
                }
                else
                {
                    motor.Move(0);
                }
                if (Input.GetKey(KeyCode.A))
                {
                    motor.Rotate(-data.turnSpeed);
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    motor.Rotate(data.turnSpeed);
                }
                break;
            default:
                Debug.LogError("No input scheme selected.");
                break;

        }
    }
}
