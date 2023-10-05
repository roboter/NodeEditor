using CommunityToolkit.Mvvm.ComponentModel;

namespace NodeEditorDemo.ViewModels.Nodes;

public partial class RoundedRectangleViewModel : ViewModelBase
{
    [ObservableProperty] private object? _label;
}
