using UnityEngine;

public class Dice : MonoBehaviour
{
    [SerializeField] private GameObject[] _sides = new GameObject[6];

    public int Roll()
    {
        int number = Random.Range(1, 7);
        ActivateSide(number);
        return number;
    }
    private void ActivateSide(int sideIndex)
    {
        for (int i = 0; i < _sides.Length; i++)
        {
            _sides[i].SetActive(false);
        }
        _sides[sideIndex-1].SetActive(true);
    }
}
