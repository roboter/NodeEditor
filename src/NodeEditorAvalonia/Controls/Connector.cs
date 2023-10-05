using Avalonia;
using Avalonia.Controls.Metadata;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using NodeEditor.Model;

namespace NodeEditor.Controls;

[PseudoClasses(":selected")]
public class OffsetConnector
    : Shape
{
    public static readonly StyledProperty<Point> StartPointProperty = AvaloniaProperty.Register<OffsetConnector, Point>(nameof(StartPoint));

    public static readonly StyledProperty<Point> EndPointProperty = AvaloniaProperty.Register<OffsetConnector, Point>(nameof(EndPoint));

    public static readonly StyledProperty<double> OffsetProperty = AvaloniaProperty.Register<OffsetConnector, double>(nameof(Offset));

    static OffsetConnector()
    {
        StrokeThicknessProperty.OverrideDefaultValue<OffsetConnector>(1);
        AffectsGeometry<OffsetConnector>(StartPointProperty, EndPointProperty, OffsetProperty);
    }

    public Point StartPoint
    {
        get => GetValue(StartPointProperty);
        set => SetValue(StartPointProperty, value);
    }

    public Point EndPoint
    {
        get => GetValue(EndPointProperty);
        set => SetValue(EndPointProperty, value);
    }

    public double Offset
    {
        get => GetValue(OffsetProperty);
        set => SetValue(OffsetProperty, value);
    }

    protected override Geometry CreateDefiningGeometry()
    {
        var geometry = new StreamGeometry();

        using var context = geometry.Open();

        context.BeginFigure(StartPoint, false);

        if (DataContext is ICommonConnector connector)
        {
            var p1X = StartPoint.X;
            var p1Y = StartPoint.Y;
            var p2X = EndPoint.X;
            var p2Y = EndPoint.Y;

            connector.GetControlPoints(
                connector.Orientation,
                Offset,
                connector.Start?.Alignment ?? PinAlignment.None,
                connector.End?.Alignment ?? PinAlignment.None,
                ref p1X, ref p1Y,
                ref p2X, ref p2Y);

            context.CubicBezierTo(new Point(p1X, p1Y), new Point(p2X, p2Y), EndPoint);
        }
        else
        {
            context.CubicBezierTo(StartPoint, EndPoint, EndPoint);
        }

        context.EndFigure(false);

        return geometry;
    }
}


[PseudoClasses(":selected")]
public class BezierConnector : Shape
{
    public static readonly StyledProperty<Point> StartPointProperty =
        AvaloniaProperty.Register<OffsetConnector, Point>(nameof(StartPoint));

    public static readonly StyledProperty<Point> EndPointProperty =
        AvaloniaProperty.Register<OffsetConnector, Point>(nameof(EndPoint));

    public static readonly StyledProperty<Point> StartControlPointProperty =
        AvaloniaProperty.Register<OffsetConnector, Point>(nameof(StartPoint));

    public static readonly StyledProperty<Point> EndControlPointProperty =
        AvaloniaProperty.Register<OffsetConnector, Point>(nameof(EndPoint));

    static BezierConnector()
    {
        StrokeThicknessProperty.OverrideDefaultValue<OffsetConnector>(1);
        AffectsGeometry<OffsetConnector>(StartPointProperty, EndPointProperty, StartControlPointProperty, EndControlPointProperty);
    }

    public Point StartPoint
    {
        get => GetValue(StartPointProperty);
        set => SetValue(StartPointProperty, value);
    }

    public Point EndPoint
    {
        get => GetValue(EndControlPointProperty);
        set => SetValue(EndControlPointProperty, value);
    }

    public Point StartControlPoint
    {
        get => GetValue(StartControlPointProperty);
        set => SetValue(StartControlPointProperty, value);
    }

    public Point EndControlPoint
    {
        get => GetValue(EndControlPointProperty);
        set => SetValue(EndControlPointProperty, value);
    }

    protected override Geometry CreateDefiningGeometry()
    {
        var geometry = new StreamGeometry();

        using var context = geometry.Open();

        context.BeginFigure(StartPoint, false);

        context.CubicBezierTo(StartControlPoint, EndControlPoint, EndPoint);

        context.EndFigure(false);

        return geometry;
    }
}
