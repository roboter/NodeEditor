﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using NodeEditor.Model;
using NodeEditor.Mvvm;
using NodeEditorDemo.ViewModels.Nodes;

namespace NodeEditorDemo.Services;

public class NodeFactory : INodeFactory
{
    internal static INode CreateRectangle(double x, double y, double width, double height, string? label, double pinSize = 10)
    {
        var node = new NodeViewModel
        {
            X = x,
            Y = y,
            Width = width,
            Height = height,
            Pins = new ObservableCollection<IPin>(),
            Content = new RectangleViewModel { Label = label }
        };

        node.AddPin(0, height / 2, pinSize, pinSize, PinAlignment.Left, "L");
        node.AddPin(width, height / 2, pinSize, pinSize, PinAlignment.Right, "R");
        node.AddPin(width / 2, 0, pinSize, pinSize, PinAlignment.Top, "T");
        node.AddPin(width / 2, height, pinSize, pinSize, PinAlignment.Bottom, "B");

        return node;
    }

    internal static INode CreateChip(double x, double y, double width, double height, string? label, double pinSize = 10)
    {
        var node = new NodeViewModel
        {
            X = x,
            Y = y,
            Width = width,
            Height = height,
            Pins = new ObservableCollection<IPin>(),
            Content = new RectangleViewModel { Label = label }
        };

        for (int i = 0; i != 10; i++)
        {
            node.AddPin(0, i * 15, pinSize * 2, pinSize, PinAlignment.Left, $"P{i}");

        }
        //node.AddPin(width, height / 2, pinSize, pinSize, PinAlignment.Right, "R");
        //node.AddPin(width / 2, 0, pinSize, pinSize, PinAlignment.Top, "T");
        //node.AddPin(width / 2, height, pinSize, pinSize, PinAlignment.Bottom, "B");

        return node;
    }

    internal static INode CreateVia(double x, double y, double width, double height, string? label, double pinSize = 10)
    {
        var node = new NodeViewModel
        {
            X = x,
            Y = y,
            Width = width,
            Height = height,
            Pins = new ObservableCollection<IPin>(),
            Content = new RectangleViewModel { Label = label }
        };

        node.AddPin(0, 0, pinSize, pinSize, PinAlignment.Right, "V1");

        //node.AddPin(width, height / 2, pinSize, pinSize, PinAlignment.Right, "R");
        //node.AddPin(width / 2, 0, pinSize, pinSize, PinAlignment.Top, "T");
        //node.AddPin(width / 2, height, pinSize, pinSize, PinAlignment.Bottom, "B");

        return node;
    }

    internal static INode CreatePin(double x, double y, double width, double height, string? label, double pinSize = 10)
    {
        var node = new NodeViewModel
        {
            X = x,
            Y = y,
            Width = width,
            Height = height,
            Pins = new ObservableCollection<IPin>(),
            Content = new RectangleViewModel { Label = label }
        };

        node.AddPin(10, 10, pinSize, pinSize, PinAlignment.Right, "P1");

        //node.AddPin(width, height / 2, pinSize, pinSize, PinAlignment.Right, "R");
        //node.AddPin(width / 2, 0, pinSize, pinSize, PinAlignment.Top, "T");
        //node.AddPin(width / 2, height, pinSize, pinSize, PinAlignment.Bottom, "B");

        return node;
    }

    internal static INode CreateEllipse(double x, double y, double width, double height, string? label, double pinSize = 10)
    {
        var node = new NodeViewModel
        {
            X = x,
            Y = y,
            Width = width,
            Height = height,
            Pins = new ObservableCollection<IPin>(),
            Content = new EllipseViewModel { Label = label }
        };

        node.AddPin(0, height / 2, pinSize, pinSize, PinAlignment.Left, "L");
        node.AddPin(width, height / 2, pinSize, pinSize, PinAlignment.Right, "R");
        node.AddPin(width / 2, 0, pinSize, pinSize, PinAlignment.Top, "T");
        node.AddPin(width / 2, height, pinSize, pinSize, PinAlignment.Bottom, "B");

        return node;
    }

    internal static INode CreateSignal(double x, double y, double width = 180, double height = 30, string? label = null, bool? state = false, double pinSize = 10, string name = "SIGNAL")
    {
        var node = new NodeViewModel
        {
            Name = name,
            X = x,
            Y = y,
            Width = width,
            Height = height,
            Pins = new ObservableCollection<IPin>(),
            Content = new SignalViewModel { Label = label, State = state }
        };

        node.AddPin(0, height / 2, pinSize, pinSize, PinAlignment.Left, "IN");
        node.AddPin(width, height / 2, pinSize, pinSize, PinAlignment.Right, "OUT");

        return node;
    }

    internal static INode CreateAndGate(double x, double y, double width = 60, double height = 60, double pinSize = 10, string name = "AND")
    {
        var node = new NodeViewModel
        {
            Name = name,
            X = x,
            Y = y,
            Width = width,
            Height = height,
            Pins = new ObservableCollection<IPin>(),
            Content = new AndGateViewModel { Label = "&" }
        };

        node.AddPin(0, height / 2, pinSize, pinSize, PinAlignment.Left, "L");
        node.AddPin(width, height / 2, pinSize, pinSize, PinAlignment.Right, "R");
        node.AddPin(width / 2, 0, pinSize, pinSize, PinAlignment.Top, "T");
        node.AddPin(width / 2, height, pinSize, pinSize, PinAlignment.Bottom, "B");

        return node;
    }

    internal static INode CreateOrGate(double x, double y, double width = 60, double height = 60, int count = 1, double pinSize = 10, string name = "OR")
    {
        var node = new NodeViewModel
        {
            Name = name,
            X = x,
            Y = y,
            Width = width,
            Height = height,
            Pins = new ObservableCollection<IPin>(),
            Content = new OrGateViewModel { Label = "≥", Count = count }
        };

        node.AddPin(0, height / 2, pinSize, pinSize, PinAlignment.Left, "L");
        node.AddPin(width, height / 2, pinSize, pinSize, PinAlignment.Right, "R");
        node.AddPin(width / 2, 0, pinSize, pinSize, PinAlignment.Top, "T");
        node.AddPin(width / 2, height, pinSize, pinSize, PinAlignment.Bottom, "B");

        return node;
    }

    internal static ICommonConnector CreateConnector(IPin? start, IPin? end, double offset)
    {
        return new OffsetConnectorViewModel
        {
            Start = start,
            End = end,
            Offset = offset
        };
    }

    internal static ICommonConnector CreateBezierConnector(IPin? start, IPin? end)
    {
        return new OffsetConnectorViewModel
        {
            Start = start,
            End = end,
            
        };
    }

    public IDrawingNode CreateDrawing(string? name = null)
    {
        var drawing = new DrawingNodeViewModel
        {
            Name = name,
            X = 0,
            Y = 0,
            Width = 900,
            Height = 600,
            Nodes = new ObservableCollection<INode>(),
            Connectors = new ObservableCollection<ICommonConnector>(),
            EnableMultiplePinConnections = false,
            EnableSnap = true,
            SnapX = 15.0,
            SnapY = 15.0,
            EnableGrid = true,
            GridCellWidth = 15.0,
            GridCellHeight = 15.0,
        };

        return drawing;
    }

    public IList<INodeTemplate> CreateTemplates()
    {
        return new ObservableCollection<INodeTemplate>
        {
            new NodeTemplateViewModel
            {
                Title = "Rectangle",
                Template = CreateRectangle(0, 0, 60, 60, "rect"),
                Preview = CreateRectangle(0, 0, 60, 60, "rect")
            },
            new NodeTemplateViewModel
            {
                Title = "Ellipse",
                Template = CreateEllipse(0, 0, 60, 60, "ellipse"),
                Preview = CreateEllipse(0, 0, 60, 60, "ellipse")
            },
            new NodeTemplateViewModel
            {
                Title = "Signal",
                Template = CreateSignal(0, 0, label: "signal", state: false),
                Preview = CreateSignal(0, 0, label: "signal", state: false)
            },
            new NodeTemplateViewModel
            {
                Title = "AND Gate",
                Template = CreateAndGate(0, 0, 60, 60),
                Preview = CreateAndGate(0, 0, 60, 60)
            },
            new NodeTemplateViewModel
            {
                Title = "OR Gate",
                Template = CreateOrGate(0, 0, 60, 60),
                Preview = CreateOrGate(0, 0, 60, 60)
            }
        };
    }
}
