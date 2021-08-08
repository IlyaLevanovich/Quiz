using UnityEngine;
using System.Collections;

public class CellsCreator : MonoBehaviour
{
    [SerializeField] private GameObject _cell;
    [SerializeField] private ParentForCells _parent;
    [SerializeField, Range(1,3)] private int _countX = 3;
    private int _countY;
    private float _spacing = 1.5f;

    public void InitializeCount(int cellsOnY)
    {
        this._countY = cellsOnY;
        StartCoroutine(NotifyAboutCreated());
    }
    private IEnumerator Create()
    {
        yield return null;
        for(float y = 0; y < _countY; y++)
        {
            for(int x = 0; x < _countX; x++)
            {
                Vector2 position = new Vector2(x, y) * _spacing;
                Instantiate(_cell, position, Quaternion.identity);
            }
        }
    } 
    private IEnumerator NotifyAboutCreated()
    {
        yield return StartCoroutine(Create());
        _parent.CorrectState(_countY, _countX);
    }
}
