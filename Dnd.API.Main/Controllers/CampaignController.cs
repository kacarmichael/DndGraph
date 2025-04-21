using Dnd.Application.Main.Models.Campaigns;
using Dnd.Application.Main.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Dnd.API.Main.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CampaignController : ControllerBase
{
    private readonly ICampaignService _campaignService;

    public CampaignController(ICampaignService campaignService) => _campaignService = campaignService;

    [HttpGet]
    public async Task<IActionResult> GetCampaigns() => Ok(await _campaignService.GetAllCampaignsAsync());

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetCampaign(int id) => Ok(await _campaignService.GetCampaignByIdAsync(id));

    [HttpPost]
    public async Task<IActionResult> CreateCampaign([FromBody] Campaign campaign) =>
        Ok(await _campaignService.CreateCampaignAsync(campaign));

    [HttpPut]
    public async Task<IActionResult> UpdateCampaign([FromBody] Campaign campaign) =>
        Ok(await _campaignService.UpdateCampaignAsync(campaign));

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteCampaign(int id) => Ok(await _campaignService.DeleteCampaignByIdAsync(id));

    [HttpGet("{id:int}/sessions")]
    public async Task<IActionResult> GetCampaignSessions(int id) =>
        Ok(await _campaignService.GetCampaignSessionByIdAsync(id));

    [HttpPost("{id:int}/sessions")]
    public async Task<IActionResult> CreateCampaignSession(int id, [FromBody] CampaignSession campaignSession)
    {
        return Ok(await _campaignService.CreateCampaignSessionAsync(campaignSession));
    }

    [HttpDelete("{id:int}/sessions/{sessionId:int}")]
    public async Task<IActionResult> DeleteCampaignSession(int id) =>
        Ok(await _campaignService.DeleteCampaignSessionByIdAsync(id));

    [HttpPut("{id:int}/sessions/{sessionId:int}")]
    public async Task<IActionResult> UpdateCampaignSession(int id, int sessionId,
        [FromBody] CampaignSession campaignSession) =>
        Ok(await _campaignService.UpdateCampaignSessionAsync(campaignSession));
}