using System.Collections.Generic;

namespace NodeEditor.Model;

public interface IDrawingNodeFactory
{
    IPin CreatePin();
    ICommonConnector CreateConnector();
    public IList<T> CreateList<T>();
}
