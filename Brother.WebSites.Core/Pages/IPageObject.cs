namespace Brother.WebSites.Core.Pages
{
    public interface IPageObject
    {
        string ValidationElementSelector { get; }
        string PageUrl { get; }
    }
}
