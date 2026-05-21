using System.Collections.Generic;
using System.Windows.Forms;

namespace Engine3D_2._0
{
    // solução em:
    // https://stackoverflow.com/questions/24571817/how-to-set-selected-item-of-property-grid
    public static class PropertyGridExtensions
    {
        public static IEnumerable<GridItem> EnumerateAllItems(this PropertyGrid grid)
        {
            if (grid == null)
                yield break;

            // pega o item raiz
            GridItem start = grid.SelectedGridItem;
            while (start?.Parent != null)
            {
                start = start.Parent;
            }

            if (start == null)
                yield break;

            foreach (GridItem item in start.EnumerateAllItems())
            {
                yield return item;
            }
        }

        public static IEnumerable<GridItem> EnumerateAllItems(this GridItem item)
        {
            if (item == null)
                yield break;

            yield return item;

            foreach (GridItem child in item.GridItems)
            {
                foreach (GridItem gc in child.EnumerateAllItems())
                {
                    yield return gc;
                }
            }
        }
    }
}
