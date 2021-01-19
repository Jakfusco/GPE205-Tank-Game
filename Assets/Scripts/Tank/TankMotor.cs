using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TankData))]
[RequireComponent(typeof(CharacterController))]
public class tankMotor : MonoBehaviour
{
    private TankData data;
    private CharacterController characterController;


    public void Start()
    {
        data = GetComponent<TankData>();
        characterController = GetComponent<CharacterController>();
    }

    /// <summary>
    /// Move Method moves the tank
    /// </summary>
    /// <param name="moveSpeed"></param>
    public void Move(float moveSpeed)
    {
        // Create a vector to hold our speed data
        // Start with the vector pointing the same direction as the GameObject this script is on.
        // Now, instead of our vector being 1 unit in length, apply our speed value
        Vector3 speedVector = transform.forward * moveSpeed;

        // Call SimpleMove() and send it our vector
        // Note that SimpleMove() will apply Time.deltaTime, and convert to meters per second for us!
        characterController.SimpleMove(speedVector);
    }

    /// <summary>
    /// Rotate Method rotates the tank.
    /// </summary>
    /// <param name="rotateSpeed"></param>
    public void Rotate(float rotateSpeed)
    {
        // Create a vector to hold our rotation data
        // Start by rotating right by one degree per frame draw. Left is just "negative right".
        // Adjust our rotation to be based on our speed
        // Transform.Rotate() doesn't account for speed, so we need to change our rotation to "per second" instead of "per frame."
        // See the lecture on Timers for details on how this works.
        Vector3 rotateVector = Vector3.up * rotateSpeed *Time.deltaTime;

        // Now, rotate our tank by this value - we want to rotate in our local space (not in world space).
        transform.Rotate(rotateVector, Space.Self);
    }


}
