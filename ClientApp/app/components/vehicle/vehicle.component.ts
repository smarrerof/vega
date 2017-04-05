import { Component, OnInit } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';

import { IMake } from './../../models/make';
import { IModel } from './../../models/model';
import { IFeature } from './../../models/feature';
import { Vehicle } from './../../models/vehicle';
import { MakeService } from './../../services/make.service';
import { FeatureService } from './../../services/feature.service';
import { VehicleService } from './../../services/vehicle.service';

@Component({
    selector: 'data-vehicle',
    templateUrl: './vehicle.component.html'
})

export class VehicleComponent implements OnInit {
    vehicle: Vehicle;
    makes: IMake[];
    models: IModel[];
    features: IFeature[];

    constructor(private makeService: MakeService, private featureService: FeatureService, private vehicleService: VehicleService) {
        this.vehicle = new Vehicle();
     }

    ngOnInit(): void {
        this.getMakes();
        this.getFeatures();
    }

    getMakes(): void {
        this.makeService.getMakes().then(makes => {
            this.makes = makes
            this.models = makes[0].models;
        });
    }

    getFeatures(): void {
        this.featureService.getFeatures().then(features => this.features = features);        
    }

    onSelectMake(value): void {
        this.models = this.makes.find(make => make.id === parseInt(value)).models;        
    }

    onIsRegisteredChange(e: any): void {
        this.vehicle.isRegistered = (e.value === "true");
    }

    onFeatureChange(e: any) : void {
        if (e.checked) {
            this.vehicle.features.push(e.value);
        } else {
            this.vehicle.features.splice(this.vehicle.features.indexOf(e.value), 1);
        }
    }

    onSubmit(form: NgForm): void {
        console.log(this.vehicle); // for demo purposes only
        if (form.valid) {        
            this.vehicleService.create(this.vehicle)
                .then(() => {
                    alert('Vehicle created successfully.')
                    form.resetForm();
                })
                .catch(() => alert('There was an error creating the vehicle.'));
        }
    }
}