using Dnd.Core.Main.Models.Dice;
using Dnd.Core.Main.Utils;

namespace Dnd.Core.Main.Services;

public interface IRollService
{
    Task<IDto> Roll(IDto req);

    Task<IDiceSimulation> Simulate(IDiceSet set, int trials);

    IDto Simulate(IDto req);

    IDto DiceRoll(IDto req);
}