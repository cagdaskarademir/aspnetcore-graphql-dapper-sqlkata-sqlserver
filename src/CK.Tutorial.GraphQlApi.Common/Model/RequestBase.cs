namespace CK.Tutorial.GraphQlApi.Common.Model
{
    public class RequestBase
    {
        public int DefaultPage { get; } = 1;
        public int DefaultPageSize { get; } = 10;
        public string[] Columns { get; set; }
        public int? PageSize { get; set; }
        public int? Page { get; set; }
    }
}