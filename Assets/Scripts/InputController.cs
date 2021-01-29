using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TankData))] //Required for the script to run
[RequireComponent(typeof(TankMotor))] //Required for the script to run
[RequireComponent(typeof(TankShooter))] //Required for the script to run
public class InputController : MonoBehaviour
{
    // Variables
    private TankData data; //Tank Data Component
    private TankMotor motor; //Tank Motor Component
    private TankShooter shooter; //Tank Shooter Component

    public enum InputScheme { WASD, arrowKeys }; // What Control Scheme the player can select
    public InputScheme inputScheme = InputScheme.arrowKeys; // Default control scheme is set to arrow keys, but can be changed

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
            //Arrow Key Movement
            case InputScheme.arrowKeys:
                //Handling Movement
                if (Input.GetKey(KeyCode.UpArrow)) //Move Up
                {
                    motor.Move(data.moveSpeed);
                }
                else if (Input.GetKey(KeyCode.DownArrow)) //Move Back
                {
                    motor.Move(-data.moveSpeed);
                }
                else
                {
                    motor.Move(0);
                }

                //Handling Rotation
                if (Input.GetKey(KeyCode.RightArrow)) //Move Right
                {
                    motor.Rotate(-data.turnSpeed);
                }
                else if (Input.GetKey(KeyCode.LeftArrow)) //Move Left
                {
                    motor.Rotate(data.turnSpeed);
                }
                //Handle Shooting
                if (Input.GetKeyDown(KeyCode.KeypadEnter)) //Shoot
                {
                    shooter.shoot();
                }

                break;
                //WASD Movement
            case InputScheme.WASD:

                //Handling Movement
                if (Input.GetKey(KeyCode.W)) //Move Up
                {
                    motor.Move(data.moveSpeed);
                }
                else if (Input.GetKey(KeyCode.S)) //Move Back
                {
                    motor.Move(-data.moveSpeed);
                }
                else
                {
                    motor.Move(0);
                }

                //Handling Rotation
                if (Input.GetKey(KeyCode.A)) // Move Right
                {
                    motor.Rotate(-data.turnSpeed);
                }
                else if (Input.GetKey(KeyCode.D)) //Move Left
                {
                    motor.Rotate(data.turnSpeed);
                }

                //Handle Shooting
                if (Input.GetKey(KeyCode.Space)) //Shoot
                {
                    shooter.shoot();
                }

                break;


            default:
                Debug.LogError("No input scheme selected.");
                break;

        }
    }
}
