namespace WebApiDemo.Entities.RequestParams
{
    public class RequestParameters
    {
        const int MaxPageSize = 10;
        private int _pageSize;

        public int PageNumber { get; set; } = 1;

        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                if (value > MaxPageSize)
                    _pageSize = MaxPageSize;
                else
                    _pageSize = value;
            }
        }
    }
}
