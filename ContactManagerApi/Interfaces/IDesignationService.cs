using ContactManagerApi.Responses;

namespace ContactManagerApi.Interfaces
{
    public interface IDesignationService
    {
        Task<GetDesignationsResponse> GetDesignationsAsync();
        //Task<DesignationResponse> GetDesignationAsync(int id);
    }
}
