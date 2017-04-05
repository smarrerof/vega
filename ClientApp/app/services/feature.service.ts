import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';

import 'rxjs/add/operator/toPromise';

import { IFeature } from './../models/feature'

@Injectable()
export class FeatureService {
    private headers = new Headers({'Content-Type': 'application/json'});
    private featuresUrl = 'api/features';
    
    constructor(private http: Http) { }

    private handleError(error: any): Promise<any> {
        console.error('An error occurred', error); // for demo purposes only
        return Promise.reject(error.message || error);
    }

    getFeatures(): Promise<IFeature[]> {
        return this.http.get(this.featuresUrl)
        .toPromise()
        .then(response => response.json() as IFeature[])
        .catch(this.handleError);
    }
}
