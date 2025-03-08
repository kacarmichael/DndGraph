using Dnd.Core.Main.Models.Dice;
using Dnd.Core.Main.Utils;

namespace Dnd.Core.Main.Services;

public interface IRollService
{
    Task<DtoBase> Roll(DtoBase req);

    Task<IDiceSimulation> Simulate(IDiceSet set, int trials);

    DtoBase Simulate(DtoBase req);

    DtoBase DiceRoll(DtoBase req);
}