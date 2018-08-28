import { Injectable, Inject } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs';
import { Router, Resolve } from '@angular/router';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import { retry } from 'rxjs/operator/retry';

@Injectable()
export class CustomerService {
    myAppUrl: string = "";

    constructor(private _http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.myAppUrl = baseUrl;
    }


    getAllCustomers() {
        return this._http.get(this.myAppUrl + 'api/Customers/Index')
            .map((response: Response) => response.json())
            .catch(this.errorHandler);
    }

    getCustomerById(id: number) {
        return this._http.get(this.myAppUrl + "api/Customers/Details/" + id)
            .map((response: Response) => response.json())
            .catch(this.errorHandler)
    }

    saveCustomer(customer) {
        return this._http.post(this.myAppUrl + 'api/Customers/Create', customer)
            .map((response: Response) => response.json())
            .catch(this.errorHandler)
    }

    updateCustomer(fulldata) {
        return this._http.put(this.myAppUrl + 'api/Customers/Edit', fulldata)
            .map((response: Response) => response.json())
            .catch(this.errorHandler);
    }

    deleteCustomer(id) {
        return this._http.delete(this.myAppUrl + "api/Customers/Delete/" + id)
            .map((response: Response) => response.json())
            .catch(this.errorHandler);
    }
    errorHandler(error: Response) {
        console.log(error);
        return Observable.throw(error);
    }
}  