import { Component, Inject } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { Router, ActivatedRoute } from '@angular/router';
import { CustomerService } from '../../services/csmrservice.service'
import { Customer } from '../Models/customer';

@Component({
    templateUrl: './fetchcustomer.component.html'
})

export class FetchCustomerComponent {

    public cstmrList: Customer[] = [];

    constructor(public http: Http, private _router: Router, private _customerService: CustomerService) {
        this.getAllCustomers();
    }

    getAllCustomers() {
        this._customerService.getAllCustomers().subscribe(
            data => this.cstmrList = data
        )
    }

    delete(customerId) {
        var ans = confirm("Do you want to delete customer with Id: " + customerId);
        if (ans) {
            this._customerService.deleteCustomer(customerId).subscribe((data) => {
                this.getAllCustomers();
            }, error => console.error(error))
        }
    }

}

interface CutomerData {
    customerId: number;
    name: string;
    address: string;
    email: string;
    phone: string;
    comments: string;
}  