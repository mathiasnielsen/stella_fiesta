namespace StellaFiesta.Client.CoreStandard
{
    public class ResultBlock<TData>
        where TData : class
    {
        public ResultBlock(bool isSuccess, TData data = null)
        {
            IsSuccess = isSuccess;
            Data = data;
        }

        public bool IsSuccess { get; private set; }

        public TData Data { get; private set; }
    }
}
