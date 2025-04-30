export class SimulationResult {
    constructor(data) {
        this.diceRolled = data.diceRolled;
        this.modifier = data.modifier;
        this.results = data.results.sort((a, b) => a.value - b.value);
        this.trials = data.trials;
    }

    getDiceRolled() {
        return this.diceRolled;
    }

    getModifier() {
        return this.modifier;
    }

    getResults() {
        return this.results;
    }

    getTrials() {
        return this.trials;
    }
}