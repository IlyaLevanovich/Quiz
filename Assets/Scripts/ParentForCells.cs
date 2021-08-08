using System.Collections.Generic;
using UnityEngine;

public class ParentForCells : MonoBehaviour
{
    [SerializeField] private LevelTask _levelTask;
    private List<Cell> _childObjects;
    public List<Cell> ChildObjects => _childObjects;
    private float _factorRation = 0.5f;

    public void CorrectState(int countY, int countX)
    {
        transform.position = new Vector3(-countX * _factorRation, -countY * _factorRation);
        CorrectData();
    }

    private void CorrectData()
    {
        FindChildrens();
        ReplaceChildrenSprites();
         _levelTask.SetTask();
    }

    private void FindChildrens()
    {
        Cell[] cells = GetComponentsInChildren<Cell>();
        _childObjects = new List<Cell>(cells);
    }

    public void ReplaceChildrenSprites()
    {
        foreach (var child in _childObjects)
            child.SetSprite();
    }
    
    public void ResetData()
    {
        transform.position = Vector2.zero;
        foreach (var child in _childObjects)
            Destroy(child.gameObject);
    }
}
