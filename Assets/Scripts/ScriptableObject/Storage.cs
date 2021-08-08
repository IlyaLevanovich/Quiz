using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Storage", menuName = "New Storage", order = 51)]
public class Storage : ScriptableObject
{
    [SerializeField] private List<Sprite> _content;
    public List<Sprite> Content => _content;

}
