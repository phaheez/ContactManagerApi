using ContactManagerApi.Interfaces;
using ContactManagerApi.Responses;
using Microsoft.EntityFrameworkCore;

namespace ContactManagerApi.Services
{
    public class DesignationService : IDesignationService
    {
        private readonly ContactsDbContext _context;

        public DesignationService(ContactsDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<GetDesignationsResponse> GetDesignationsAsync()
        {
            var designations = await _context.Designations.AsNoTracking().ToListAsync();

            if (designations.Count == 0)
            {
                return new GetDesignationsResponse
                {
                    Success = false,
                    Error = "No designations found",
                    ErrorCode = "T04"
                };
            }

            return new GetDesignationsResponse { Success = true, Designations = designations };
        }

        //public async Task<DesignationResponse> GetDesignationAsync(int id)
        //{
        //    var designation = await _context.Designations.FindAsync(id);

        //    if (designation == null)
        //    {
        //        return new DesignationResponse
        //        {
        //            Success = false,
        //            Error = "Designation not found",
        //            ErrorCode = "T01"
        //        };
        //    }

        //    return new DesignationResponse { Success = true, Designation = designation };
        //}
    }
}
