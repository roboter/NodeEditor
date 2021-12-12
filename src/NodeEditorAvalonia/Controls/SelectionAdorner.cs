﻿using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace NodeEditor.Controls;

public class SelectionAdorner : TemplatedControl
{
    public static readonly StyledProperty<Point> TopLeftProperty =
        AvaloniaProperty.Register<SelectionAdorner, Point>(nameof(TopLeft));

    public static readonly StyledProperty<Point> BottomRightProperty =
        AvaloniaProperty.Register<SelectionAdorner, Point>(nameof(BottomRight));

    public Point TopLeft
    {
        get => GetValue(TopLeftProperty);
        set => SetValue(TopLeftProperty, value);
    }

    public Point BottomRight
    {
        get => GetValue(BottomRightProperty);
        set => SetValue(BottomRightProperty, value);
    }

    public Rect GetRect()
    {
        var topLeftX = Math.Min(TopLeft.X, BottomRight.X);
        var topLeftY = Math.Min(TopLeft.Y, BottomRight.Y);
        var bottomRightX = Math.Max(TopLeft.X, BottomRight.X);
        var bottomRightY = Math.Max(TopLeft.Y, BottomRight.Y);
        return new Rect(
            new Point(topLeftX, topLeftY),
            new Point(bottomRightX, bottomRightY));
    }

    protected override void OnPropertyChanged<T>(AvaloniaPropertyChangedEventArgs<T> change)
    {
#pragma warning disable 8631
        base.OnPropertyChanged(change);
#pragma warning restore 8631

        if (change.Property == TopLeftProperty || change.Property == BottomRightProperty)
        {
            // Invalidate();
        }
    }

    public void Invalidate()
    {
        var rect = GetRect();
        Canvas.SetLeft(this, rect.X);
        Canvas.SetTop(this, rect.Y);
        Width = rect.Width;
        Height = rect.Height;
        InvalidateVisual();
    }
}
