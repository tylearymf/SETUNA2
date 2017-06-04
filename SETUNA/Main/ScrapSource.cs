namespace SETUNA.Main
{
    using System;
    using System.Drawing;

    public abstract class ScrapSource : IDisposable
    {
        protected string _name;

        protected ScrapSource()
        {
        }

        public virtual void Dispose()
        {
            Console.WriteLine("ScrapSource Dispose");
        }

        public abstract Image GetImage();
        public virtual Point GetPosition() => 
            Point.Empty;

        public string Name =>
            this._name;
    }
}

