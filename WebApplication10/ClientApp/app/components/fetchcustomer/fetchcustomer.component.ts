import { Component, Inject } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { Router, ActivatedRoute } from '@angular/router';
import { CustomerService } from '../../services/csmrservice.service'

@Component({
    templateUrl: './fetchcustomer.component.html'
})

export class FetchCustomerComponent {

    public cstmrList: CutomerData[];

    constructor(public http: Http, private _router: Router, private _customerService: CustomerService) {
        this.getAllCustomers();
    }

    getAllCustomers() {
        this._customerService.getAllCustomers().subscribe(
            data => this.cstmrList = data
        )
    }

    delete(Id) {
        var ans = confirm("Do you want to delete customer with Id: " + Id);
        if (ans) {
            this._customerService.deleteCustomer(Id).subscribe((data) => {
                this.getAllCustomers();
            }, error => console.error(error))
        }
    }
}

interface CutomerData {
    CustomerId: number;
    name: string;
    address: string;
    email: string;
    phone: string;
    comments: string;
}  