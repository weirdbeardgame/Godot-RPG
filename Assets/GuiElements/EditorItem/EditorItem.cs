using Godot;
using System;

public partial class EditorItem : Node2D
{
    string _name;

    Resource _object;
    public Resource Object => _object;

    public Action ObjectSelected;
    public Action ObjectDeleted;

    Button _objectButton;
    Button _deleteButton;

    public void CreateButton(string n, Resource obj)
    {
        _name = n;
        _object = obj;
        _objectButton = GetNode<Button>("Object");
        _deleteButton = GetNode<Button>("Delete");

        _objectButton.Pressed += OnObjClick;
        _deleteButton.Pressed += OnDelClick;

        _objectButton.Text = _name;
    }

    public void UpdateText(string n) => _objectButton.Text = n;

    public void OnObjClick() => ObjectSelected.Invoke();
    public void OnDelClick() => ObjectDeleted.Invoke();
}
