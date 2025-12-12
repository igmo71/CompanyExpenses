namespace CompanyExpenses.Abstractions
{
    public interface ITree<TNode>
    {
        string Id { get; set; }
        string? ParentId { get; set; }
        List<TNode> Children { get; set; }
        bool Expanded { get; set; }
    }
}
