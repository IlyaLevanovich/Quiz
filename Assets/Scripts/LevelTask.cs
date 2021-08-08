using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelTask : MonoBehaviour
{
    [SerializeField] private ParentForCells _parentCells;
    [SerializeField] private TaskText _taskText;
    private List<string> _taskNames;
    private string _correctElement;
    public string CorrectElement => _correctElement;

    private void Awake() => _taskNames = new List<string>();
    public void SetTask() => _taskText.SetTask(SelectRandomElement());

    private string SelectRandomElement()
    {
        _correctElement = _parentCells.ChildObjects.ElementAt(GetRandom()).SpriteName;
        if(_taskNames.Contains(_correctElement))
            SelectRandomElement();
        else
            _taskNames.Add(_correctElement);

        return _correctElement;
    }
    private int GetRandom() => Random.Range(0, _parentCells.ChildObjects.Count);
}
