import { Component, OnInit } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { NgForm, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { Router, ActivatedRoute, NavigationEnd, Route } from '@angular/router';
import { FetchCustomerComponent } from '../fetchcustomer/fetchcustomer.component';
import { CustomerService } from '../../services/csmrservice.service';
import { Customer } from '../Models/Customer';
import { Contact } from '../Models/Contact';
import { createcustomer } from '../addcustomer/addcustomer.component'

@Component({
    templateUrl: './customerdetails.component.html'
})

export class customerdetails implements OnInit {
    title: string = "Details";
    errorMessage: any;
    customerId: number = 0;
    cust: Customer = new Customer();
    contacts: Contact[] = [];
    generalinfo: boolean = true;
    contactinfo: boolean = false;
    depinfo: boolean = false;
    userinfo: boolean = false;

    constructor(private _fb: FormBuilder, private _avRoute: ActivatedRoute,
        private _customerService: CustomerService, private _router: Router) {
            this.customerId = this._avRoute.snapshot.params["id"];
    }
    
    ngOnInit() {
        this._customerService.getCustomerById(this.customerId).subscribe(user => {
            this.cust = user;
            this.contacts = this.cust.contacts;
            console.log(user);
            console.log(this.contacts);
        });
    }
    down() {
        this.generalinfo = false;
        this.contactinfo = false;
        this.depinfo = false;
        this.userinfo = false;
    }
    general() {
        this.generalinfo = true;
        this.contactinfo = false;
        this.depinfo = false;
        this.userinfo = false;
    }
    cont() {
        this.down();

        this.contactinfo = true;
    }
    dep() {
        this.down();
        this.depinfo = true;
    }
    user() {
        this.down();
        this.userinfo = true;
    }
    return() {
        this._router.navigate(['/fetch-customer']);
    }
}
