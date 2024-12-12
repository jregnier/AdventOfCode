namespace Day5;

internal class Update
{
    public bool IsValid { get; set; }

    public List<int> Pages { get; set; } = [];

    public int GetMiddlePage() => Pages[Pages.Count / 2];
}

internal class Page(int pageNumber, Rules rules) : IComparable<Page>
{
    private readonly Rules _rules = rules;

    public int PageNumber { get; set; } = pageNumber;

    public int CompareTo(Page? other)
    {
        if (other == null)
        {
            return 1;
        }

        if (_rules.Exists(PageNumber, other.PageNumber))
        {
            return -1;
        }
        else if (_rules.Exists(other.PageNumber, PageNumber))
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
}