/* 
 Composite Pattern:
    - Compose objects into tree structures to represent whole-part hierarchies. Composite lets clients treat individual objects and compositions of objects uniformly.
    - Recursive composition
    - “Directories contain entries, each of which could be a directory.”
    - 1-to-many “has a” up the “is a” hierarchy
 */

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Composite_CS
{
    //Component
    public interface IShape
    {
        ReadOnlyCollection<IShape> Children { get; }
        void RenderToScreen();
    }

    //Leaf
    public class Line : IShape
    {
        private readonly int _x1;
        private readonly int _x2;
        private readonly int _y1;
        private readonly int _y2;

        public Line(int x1, int y1, int x2, int y2)
        {
            _x1 = x1;
            _y1 = y1;
            _x2 = x2;
            _y2 = y2;
        }

        #region IShape Members

        public void RenderToScreen()
        {
            Console.WriteLine("Rendering Line: x1={0}, y1={1}, x2={2}, y2={3}", _x1, _y1, _x2, _y2);
        }

        public ReadOnlyCollection<IShape> Children
        {
            get { return null; }
        }

        #endregion
    }

    //Leaf
    public class Rectangle : IShape
    {
        private readonly int _height;
        private readonly int _width;
        private readonly int _x;
        private readonly int _y;

        public Rectangle(int x, int y, int width, int height)
        {
            _x = x;
            _y = y;
            _width = width;
            _height = height;
        }

        #region IShape Members

        public void RenderToScreen()
        {
            Console.WriteLine("Rendering Rectangle: x={0}, y={1}, width={2}, height={3}", _x, _y, _width, _height);
        }

        public ReadOnlyCollection<IShape> Children
        {
            get { return null; }
        }

        #endregion
    }

    //Composite
    public class Picture : IShape
    {
        private readonly IList<IShape> _children;

        public Picture()
        {
            _children = new List<IShape>();
        }

        #region IShape Members

        public void RenderToScreen()
        {
            Console.WriteLine("Rendering Pictures...");
            Console.WriteLine("Rendering Children");
            foreach (IShape shape in _children)
            {
                shape.RenderToScreen();
            }
        }

        public ReadOnlyCollection<IShape> Children
        {
            get { return (ReadOnlyCollection<IShape>) _children; }
        }

        #endregion

        public void Add(IShape shape)
        {
            _children.Add(shape);
        }

        public void Remove(IShape shape)
        {
            _children.Remove(shape);
        }
    }

    public class Program
    {
        private static void Main(string[] args)
        {
            IList<IShape> allShapes = new List<IShape>();

            var line = new Line(10, 10, 100, 100);
            var rentangle = new Rectangle(50, 50, 100, 100);
            var picture = new Picture();
            picture.Add(new Line(20, 20, 30, 30));
            picture.Add(new Rectangle(100, 100, 50, 50));

            allShapes.Add(line);
            allShapes.Add(rentangle);
            allShapes.Add(picture);

            foreach (var shape in allShapes)
            {
                shape.RenderToScreen();
            }

            Console.ReadKey();
        }
    }
}