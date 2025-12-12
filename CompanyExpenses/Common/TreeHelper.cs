using CompanyExpenses.Abstractions;

namespace CompanyExpenses.Common
{
    public static class TreeHelper
    {
        public static List<TNode> BuildTree<TNode>(List<TNode> nodes) where TNode : class, ITree<TNode>
        {
            ArgumentNullException.ThrowIfNull(nodes);

            nodes.ForEach(e => e.Children.Clear());

            List<TNode> roots = [];

            var lookup = nodes.ToDictionary(e => e.Id);

            foreach (var node in nodes)
            {
                if (string.IsNullOrWhiteSpace(node.ParentId))
                {
                    roots.Add(node);
                    continue;
                }

                if (lookup.TryGetValue(node.ParentId, out var parent) && parent != node)
                {
                    parent.Children.Add(node);
                }
                else
                {
                    roots.Add(node);
                }
            }
            return roots;
        }

        public static List<TNode>? GetDescendantsOf<TNode>(TNode node, List<TNode> nodes) where TNode : class, ITree<TNode>
        {
            var descendants = nodes.Where(e => e.ParentId == node.Id).ToList();

            foreach (TNode descendant in descendants.ToList())
                descendants.AddRange(GetDescendantsOf(descendant, nodes) ?? Enumerable.Empty<TNode>());

            return descendants;
        }

        public static List<TNode> GetDescendantsOf<TNode>(TNode node) where TNode : class, ITree<TNode>
        {
            var result = new List<TNode>();

            void dfs(TNode current)
            {
                foreach (var child in current.Children)
                {
                    result.Add(child);
                    dfs(child);
                }
            }

            dfs(node);

            return result;
        }
    }
}
