using Dnd.API.Models.Campaigns.Interfaces;
using Dnd.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Dnd.API.Controllers;

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
    public async Task<IActionResult> CreateCampaign([FromBody] ICampaign campaign) =>
        Ok(await _campaignService.CreateCampaignAsync(campaign));

    [HttpPut]
    public async Task<IActionResult> UpdateCampaign([FromBody] ICampaign campaign) =>
        Ok(await _campaignService.UpdateCampaignAsync(campaign));

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteCampaign(int id) => Ok(await _campaignService.DeleteCampaignByIdAsync(id));

    [HttpGet("{id:int}/sessions")]
    public async Task<IActionResult> GetCampaignSessions(int id) =>
        Ok(await _campaignService.GetCampaignSessionByIdAsync(id));

    [HttpPost("{id:int}/sessions")]
    public async Task<IActionResult> CreateCampaignSession(int id, [FromBody] ICampaignSession campaignSession)
    {
        Ok(await _campaignService.CreateCampaignSessionAsync(campaignSession));
    }

    [HttpDelete("{id:int}/sessions/{sessionId:int}")]
    public async Task<IActionResult> DeleteCampaignSession(int id, int sessionId) =>
        Ok(await _campaignService.DeleteCampaignSessionByIdAsync(id, sessionId));

    [HttpPut("{id:int}/sessions/{sessionId:int}")]
    public async Task<IActionResult> UpdateCampaignSession(int id, int sessionId,
        [FromBody] ICampaignSession campaignSession) =>
        Ok(await _campaignService.UpdateCampaignSessionAsync(campaignSession));
}