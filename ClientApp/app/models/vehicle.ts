export class Vehicle {
    makeId: number;
    modelId: number;
    isRegistered: boolean = false;
    features: number[];
    contactName: string;
    contactPhone: string;
    contactEmail: string;

    constructor() {
        this.features = [];
    }
}