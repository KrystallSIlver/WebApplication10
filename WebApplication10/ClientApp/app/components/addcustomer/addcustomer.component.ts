import { Component, OnInit } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { NgForm, FormBuilder, FormGroup, Validators, FormControl, FormArray } from '@angular/forms';
import { Router, ActivatedRoute, NavigationEnd } from '@angular/router';
import { FetchCustomerComponent } from '../fetchcustomer/fetchcustomer.component';
import { CustomerService } from '../../services/csmrservice.service';
import { Contact } from '../Models/Contact';
import { Customer } from '../Models/Customer';

@Component({
    templateUrl: './AddCustomer.component.html'
    
})

export class createcustomer implements OnInit {
    customerForm: FormGroup;
    contactForm: FormGroup;
    title: string = "Create";
    customerId: number = 0;
    errorMessage: any;
    condition: boolean = false;
    customer: Customer = new Customer();
    
    constructor(private _fb: FormBuilder, private _avRoute: ActivatedRoute,
        private _customerService: CustomerService, private _router: Router) {
       if (this._avRoute.snapshot.params["id"]) {
            this.customerId = this._avRoute.snapshot.params["id"];
        }

        this.customerForm = this._fb.group({
            customerId: 0,
            name: new FormControl('', [Validators.required]),
            address: new FormControl('', [Validators.required]),
            email: new FormControl('', [Validators.required]),
            phone: new FormControl('', [Validators.required]),
            comments: new FormControl('')
        });
        this.contactForm = this._fb.group({
            cname: new FormControl(''),
            crole: new FormControl(''),
            cphone: new FormControl(''),
            cmail: new FormControl(''),
            contactId: this.customerId
        });
    }
    
    ngOnInit() {
        
        this.customer = this.customerForm.value;
        this.customerForm.valueChanges.subscribe(value => {
            console.log(value);
        });
        if (this.customerId > 0) {
            this.title = "Edit";
            this._customerService.getCustomerById(this.customerId)
                .subscribe(resp => this.customerForm.setValue(resp)
                , error => this.errorMessage = error);
            console.log(this.customerId);
        }

    }
    
    save() {

        if (!this.customerForm.valid) {
            return;
        }

        if (this.title == "Create") {
            console.log(this.customerForm.value);
            this._customerService.saveCustomer(this.customer)
                .subscribe((data) => {
                    this._router.navigate(['/fetch-customer']);
                }, error => this.errorMessage = error)
        }
        else if (this.title == "Edit") {
            this._customerService.updateCustomer(this.customer)
                .subscribe((data) => {
                    this._router.navigate(['/fetch-customer']);
                }, error => this.errorMessage = error)
        }
        else if (this.condition == true) {


        }
    }

    cancel() {
        this._router.navigate(['/fetch-customer']);
    }
    get name() { return this.customerForm.get('name'); }
    get address() { return this.customerForm.get('address'); }
    get email() { return this.customerForm.get('email'); }
    get phone() { return this.customerForm.get('phone'); }
    get comments() { return this.customerForm.get('comments'); }
}  

