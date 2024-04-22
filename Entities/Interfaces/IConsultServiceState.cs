namespace ConsultServiceState.Entities.Interfaces
{
    public interface IConsultServiceState
    {
        Task<HttpResponseMessage> GetAsync(string url);
    }
}
