using Godot;
using System;

public partial class ImagePicker : Control
{
    TextureRect _ImageViwer;
    FileSelector _FileSelector;

    string _ImagePath;

    public override void _EnterTree()
    {
        base._EnterTree();
        _ImageViwer = GetNode<TextureRect>("ImageViewer");
        _FileSelector = _ImageViwer.GetNode<FileSelector>("FileSelector");
    }

    public void Open(string RootFolder = "", string[] FileFilters = null)
    {
        _FileSelector.Init(RootFolder, FileFilters);
        _FileSelector.Open();
        _ImagePath = _FileSelector.Path;

        _ImageViwer.Texture = ResourceLoader.Load<Texture2D>(_ImagePath);
    }
}
