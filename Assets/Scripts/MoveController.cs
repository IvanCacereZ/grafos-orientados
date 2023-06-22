using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveController : MonoBehaviour
{
    private Vector3 vector2move;
    private float velocity = 3f;
    [SerializeField] float energy = 100;
    [SerializeField] Text publicEnergy;
    private void Update()
    {
        publicEnergy.text = "Energia = " + energy;
        transform.position = Vector3.MoveTowards(transform.position, vector2move, velocity * Time.deltaTime);
        if (energy <= 0)
        {
            StartCoroutine(UpdateEnergy());
        }
    }
    public void ChangeMovePosition(Vector3 Destiny)
    {
        vector2move = Destiny;
    }
    public float GetEnergy()
    {
        return energy;
    }
    public void UpdateEnergy(float value)
    {
        energy = energy - value;
    }
    IEnumerator UpdateEnergy()
    {
        velocity = 0f;
        publicEnergy.text = "Capsula durmiendo ¡shhh!";
        yield return new WaitForSeconds(2f);
        energy = 100f;
        velocity = 3f;
    }
}