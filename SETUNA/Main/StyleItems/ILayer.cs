namespace SETUNA.Main.StyleItems
{
    using System;

    public interface ILayer
    {
        void AddCommand(ToolCommand addCmd);
        void RefreshLayer();
        void RemoveCommand(ToolCommand removeCmd);
    }
}

