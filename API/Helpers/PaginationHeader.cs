namespace API.Helpers
{
    public class PaginationHeader
    {
        public PaginationHeader(int currentPage, int totalItems, int itemsPerPage, int totalPages)
        {
            CurrentPage = currentPage;
            TotalItems = totalItems;
            ItemsPerPage = itemsPerPage;
            TotalPages = totalPages;
        }

        public int CurrentPage { get; set; }
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int TotalPages { get; set; }
    }
}