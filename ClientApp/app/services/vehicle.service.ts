import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';

import 'rxjs/add/operator/toPromise';

import { Vehicle } from './../models/vehicle';

@Injectable()
export class VehicleService {
    private headers = new Headers({'Content-Type': 'application/json'});
    private vehiclesUrl = 'api/vehicles';
    
    constructor(private http: Http) { }

    private handleError(error: any): Promise<any> {
        console.error('An error occurred', error); // for demo purposes only
        return Promise.reject(error.message || error);
    }

    create(vehicle: Vehicle): Promise<Vehicle> {        
        return this.http.post(this.vehiclesUrl, JSON.stringify(vehicle), {headers: this.headers})
            .toPromise()
            .then(response => response.json() as Vehicle)
            .catch(this.handleError);
    }
}
