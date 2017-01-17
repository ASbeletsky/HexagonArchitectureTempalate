namespace HexagonArchitecture.Mocks
{
    #region Using

    using HexagonArchitecture.Services.Common.Attributes;

    #endregion

    [Projection(typeof(SomeEntity))]
    public class SomeEntityDto
    {
        public int Id { get; set; }
    }
}