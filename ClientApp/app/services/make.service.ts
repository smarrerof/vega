import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';

import 'rxjs/add/operator/toPromise';

import { IMake } from './../models/make'

@Injectable()
export class MakeService {
    private headers = new Headers({'Content-Type': 'application/json'});
    private makesUrl = 'api/makes';
    
    constructor(private http: Http) { }

    private handleError(error: any): Promise<any> {
        console.error('An error occurred', error); // for demo purposes only
        return Promise.reject(error.message || error);
    }

    getMakes(): Promise<IMake[]> {
        return this.http.get(this.makesUrl)
        .toPromise()
        .then(response => response.json() as IMake[])
        .catch(this.handleError);
    }
}
