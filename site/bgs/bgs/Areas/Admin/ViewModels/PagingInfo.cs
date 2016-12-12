namespace bgs.Areas.Admin.ViewModels
{
    public class PagingInfo
    {
        public int CurrentPage { get; internal set; }
        public int ItemsPerPage { get; internal set; }
        public int TotalItems { get; internal set; }
        public int TotalPages
        {
            get
            {
                return (TotalItems / ItemsPerPage) + 1;
            }
        }
    }
}