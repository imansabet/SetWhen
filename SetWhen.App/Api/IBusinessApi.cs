using Refit;
using SetWhen.App.DTOs;

namespace SetWhen.App.Api;

[Headers("Authorization: Bearer")]
public interface IBusinessApi
{
    [Post("/api/businesses")]
    Task<ApiResponse<IdResponseDto>> CreateBusinessAsync([Body] CreateBusinessDto dto);

    [Get("/api/businesses/my")]
    Task<List<BusinessDto>> GetMyBusinessesAsync();

    [Post("/api/businesses/{businessId}/staff")]
    Task<ApiResponse<IdResponseDto>> AddStaffAsync(Guid businessId, [Body] AddStaffDto dto);
}