﻿using Microsoft.AspNetCore.Mvc;
using RegisterRescueRS.Domain.Application.Services;
using RegisterRescueRS.Presenter.Controllers.App.V1.DTOs;

namespace RegisterRescueRS.Presenter.Controllers.App.V1;

[ApiController]
[Route("api/v{version:apiVersion}/Family")]
[ApiVersion("1.0")]
public class FamilyController(FamilyService service, IServiceProvider serviceProvider) : BaseController<FamilyService, IServiceProvider>(service, serviceProvider)
{
    [HttpPost]
    [MapToApiVersion("1.0")]
    public async Task<ActionResult<ResponseDTO>> PostFamily(FamilyRequestDTO dto) =>
        await this.mainService.PostFamily(dto, Request.Headers.Authorization.ToString());

    [HttpGet("List")]
    [MapToApiVersion("1.0")]
    public async Task<ActionResult<IEnumerable<FamilyCardDTO>>> ListFamilies(int page, int size, string searchTerm) =>
        await this.mainService.ListFamilies(page, size, searchTerm, Request.Headers.Authorization.ToString());

    [HttpGet("Details")]
    [MapToApiVersion("1.0")]
    public async Task<ActionResult<FamilyDTO>> FamilyDetails(Guid familyId) =>
        await this.mainService.FamilyDetails(familyId);
}
