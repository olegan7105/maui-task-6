namespace PointOfSale.Layouts
{
    public class HorizontalWrapLayoutManager : StackLayoutManager
    {
        HorizontalWrapLayout _layout;
        public HorizontalWrapLayoutManager(HorizontalWrapLayout horizontalWrapLayout) : base(horizontalWrapLayout)
        {
            _layout = horizontalWrapLayout;
        }

        public override Size Measure(double widthConstaint, double heightConstraint)
        {
            var padding = _layout.Padding;

            widthConstaint -= padding.HorizontalThickness;

            double currentRowWidth = 0;
            double currentRowHeiht = 0;
            double totalWidth = 0;
            double totalHeiht = 0;

            for (int n = 0; n < _layout.Count; n++)
            {
                var child = _layout[n];

                if(child.Visibility == Visibility.Collapsed)
                {
                    continue;
                }

                var measure = child.Measure(double.PositiveInfinity, heightConstraint);

                if(currentRowWidth + measure.Width > widthConstaint)
                {
                    totalWidth = Math.Max(totalWidth, currentRowHeiht);
                    totalHeiht += currentRowHeiht;

                    totalHeiht += _layout.Spacing;

                    currentRowWidth = 0;
                    currentRowHeiht = measure.Height;
                }
                else
                {
                    currentRowWidth += measure.Width;
                    currentRowHeiht = Math.Max(currentRowHeiht, measure.Height);

                    if(n < _layout.Count - 1)
                    {
                        currentRowWidth += _layout.Spacing;
                    }
                }
            }

            totalWidth = Math.Max(totalWidth, currentRowWidth);
            totalHeiht += currentRowHeiht;

            totalWidth += padding.HorizontalThickness;
            totalHeiht += padding.VerticalThickness;

            var finalHeight = ResolveConstraints(heightConstraint, Stack.Height,
                totalHeiht, Stack.MinimumHeight, Stack.MaximumHeight);

            var finalWidth = ResolveConstraits(widthConstaint, Stack.Width,
                totalWidth, Stack.MinimumWidth, Stack.MaximumWidth);

            return new Size(finalWidth, finalHeight);
        }

        public override Size ArrangeChildren(Rect bounds)
        {
            var padding = Stack.Padding;
            double top = padding.Top + bounds.Top;
            double left = padding.Left + bounds.Left;

            double currentRowTop = top;
            double currentX = left;
            double currentRowHeight = 0;

            double maxStackWidth = currentX;

            for (int n = 0; n < _layout.Count; n++)
            {
                var child = _layout[n];

                if(child.Visibility == Visibility.Collapsed)
                {
                    continue;
                }

                if(currentX + child.DesiredSize.Width > bounds.Right)
                {
                    maxStackWidth = Math.Max(maxStackWidth, currentX);

                    currentX = left;
                    currentRowTop += currentRowHeight + _layout.Spacing;
                    currentRowHeight = 0;
                }

                var destination = new Rect(currentX, currentRowTop, child.DesiredSize.Width, child.DesiredSize.Height);
                child.Arrange(destination);

                currentX += destination.Width + _layout.Spacing;
                currentRowHeight = Math.Max(currentRowHeight, destination.Height);
            }

            var actual = new Size(maxStackWidth, currentRowTop + currentRowHeight);

            return actual.AdjustForFill(bounds, Stack);
        }
    }
}
