namespace HexagonArchitecture.Services.Dto
{
    public class PostDto : DtoBase<int>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string BlogUrl { get; set; }
    }
}