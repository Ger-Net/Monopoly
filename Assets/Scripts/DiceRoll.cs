using UnityEngine;

public class DiceRoll : MonoBehaviour
{
    [SerializeField] private GameObject[] currentSide;

    private int number;   
    public void Roll()
    {
        currentSide[number].SetActive(false);
        number = Random.Range(0, 6);
        currentSide[number].SetActive(true);
    }

    public int GetNumberOfSteps()
    {
        return number + 1;
    }
     
}
