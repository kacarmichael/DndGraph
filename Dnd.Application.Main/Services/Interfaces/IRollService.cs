using Dnd.Application.Main.Models.Dice;
using Dnd.Application.Main.Utils;

namespace Dnd.Application.Main.Services.Interfaces;

public interface IRollService
{
    Task<IDto> Roll(IDto req);

    Task<DiceSimulation> Simulate(DiceSet set, int trials);

    IDto Simulate(IDto req);

    IDto DiceRoll(IDto req);
}