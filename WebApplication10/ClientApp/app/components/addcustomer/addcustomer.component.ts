import { Component, OnInit } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { NgForm, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { Router, ActivatedRoute, NavigationEnd } from '@angular/router';
import { FetchCustomerComponent } from '../fetchcustomer/fetchcustomer.component';
import { CustomerService } from '../../services/csmrservice.service';

@Component({
    templateUrl: './AddCustomer.component.html'
})

export class createcustomer implements OnInit {
    customerForm: FormGroup;
    title: string = "Create";
    CustomerId: number;
    errorMessage: any;

    constructor(private _fb: FormBuilder, private _avRoute: ActivatedRoute,
        private _customerService: CustomerService, private _router: Router) {
       if (this._avRoute.snapshot.params["id"]) {
            this.CustomerId = this._avRoute.snapshot.params["id"];
        }

        this.customerForm = this._fb.group({
            name: new FormControl('', [Validators.required]),
            address: new FormControl('', [Validators.required]),
            email: new FormControl('', [Validators.required]),
            phone: new FormControl('', [Validators.required]),
            comments: new FormControl('')
        });

    }

    ngOnInit() {

        if (this.CustomerId > 0) {
            this.title = "Edit";
            this._customerService.getCustomerById(this.CustomerId)
                .subscribe(resp => this.customerForm.setValue(resp)
                    , error => this.errorMessage = error);
        }

    }

    save() {
        if (!this.customerForm.valid) {
            return;
        }

        if (this.title == "Create") {
            console.log(this.customerForm.value);
            this._customerService.saveCustomer(this.customerForm.value)
                .subscribe((data) => {
                    this._router.navigate(['/fetch-customer']);
                }, error => this.errorMessage = error)
        }
        else if (this.title == "Edit") {
            this._customerService.updateCustomer(this.customerForm.value)
                .subscribe((data) => {
                    this._router.navigate(['/fetch-customer']);
                }, error => this.errorMessage = error)
        }
    }

    cancel() {
        this._router.navigate(['/fetch-customer']);
    }
    get customerId() { return this.customerForm.get('CustomerId') }
    get name() { return this.customerForm.get('name'); }
    get address() { return this.customerForm.get('address'); }
    get email() { return this.customerForm.get('email'); }
    get phone() { return this.customerForm.get('phone'); }
    get comments() { return this.customerForm.get('comments'); }
}  