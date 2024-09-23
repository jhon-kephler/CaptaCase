namespace CaptaCase.Core.Schema
{
    public class PaginatedResult<T> : Result<IEnumerable<T>>
    {
        public PaginatedResult() { }

        public PaginatedResult(List<T> data)
        {
            SetSuccess(data);
        }
    }
}
