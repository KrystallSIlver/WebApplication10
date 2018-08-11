import { Component, OnInit } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { NgForm, FormBuilder, FormGroup, Validators, FormControl, FormArray } from '@angular/forms';
import { Router, ActivatedRoute, NavigationEnd } from '@angular/router';
import { FetchCustomerComponent } from '../fetchcustomer/fetchcustomer.component';
import { CustomerService } from '../../services/csmrservice.service';
import { Contact } from '../Models/Contact';
import { Customer } from '../Models/Customer';
import { Observable } from 'rxjs';

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
    contact: Contact = new Contact();
    contacts: Contact[] = [];
    customer: Customer = new Customer();

    constructor(private _fb: FormBuilder, private _avRoute: ActivatedRoute,
        private _customerService: CustomerService, private _router: Router) {
        if (this._avRoute.snapshot.params["id"]) {
            this.customerId = this._avRoute.snapshot.params["id"];
        }
        this.customerForm = this._fb.group({
            customerId: 0,
            name: new FormControl('', [Validators.required, Validators.minLength(1)]),
            address: new FormControl('', [Validators.required, Validators.minLength(1)]),
            email: new FormControl('', [Validators.required, Validators.minLength(1)]),
            phone: new FormControl('', [Validators.required, Validators.minLength(1)]),
            comments: new FormControl('')
        });

            this.contactForm = this._fb.group({
                name: new FormControl('', [Validators.required, Validators.minLength(1)]),
                role: new FormControl('', [Validators.required, Validators.minLength(1)]),
                phone: new FormControl('', [Validators.required, Validators.minLength(1)]),
                mail: new FormControl('', [Validators.required, Validators.minLength(1)]),
              });
    }
    TestF() {
        this.customerForm.patchValue(this.customer);
        console.log(this.customer);
        this.contacts = this.customer.contacts;
        console.log(this.customer.contacts);
    }

    

    ngOnInit() {
        
        this.customerForm.valueChanges.subscribe(value =>console.log(value));
        this.contactForm.valueChanges.subscribe(v => {console.log(v);});

        if (this.customerId > 0) {
            this.title = "Edit";

            this._customerService.getCustomerById(this.customerId)
                .subscribe((resp: Customer) => {
                    this.customer = resp;
                    this.contacts = this.customer.contacts;
                    this.TestF();
                }
                , error => this.errorMessage = error).add((c) => {
                    console.log(this.customer.contacts);

                });

            //console.log(this.customer);
            
        }
        

    }

    save() {
        if (!this.customerForm.valid) {
            return;
        }

        if (this.title == "Create") {
            this.customer = this.customerForm.value;
            this.customer.contacts = this.contacts;
            this._customerService.saveCustomer(this.customer)
                .subscribe((data) => {
                    this._router.navigate(['/fetch-customer']);
                }, error => this.errorMessage = error)
        }

        else if (this.title == "Edit") {
            this.customer = this.customerForm.value;
            this.customer.contacts = this.contacts;
            console.log(this.customer)
            this._customerService.updateCustomer(this.customer)
                .subscribe((data) => {
                    this._router.navigate(['/fetch-customer']);
                }, error => this.errorMessage = error)
        }
        else if (this.condition == true) {


        }
    }
    addContact() {
        this.condition = true;
    }
    saveContact() {
        this.contact = this.contactForm.value;
        console.log(this.contacts);
        if (this.title == "Create") {
            this.contact.contactId = 0;
            this.contact.customerid = 0;
            this.contacts.push(this.contact);
        }
        else {
            this.contacts.push(this.contact);
            console.log(this.customer.contacts);
        }
        this.contactForm.reset();
        this.condition = false;

    }
    resetform() {
        this.contactForm.reset();
        
    }
    cancel() {
        if (!this.condition) {

            this._router.navigate(['/fetch-customer']);
        }
        else {
            this.condition = false;
        }
        
    }
    

    get name() { return this.customerForm.get('name'); }
    get address() { return this.customerForm.get('address'); }
    get email() { return this.customerForm.get('email'); }
    get phone() { return this.customerForm.get('phone'); }
    get comments() { return this.customerForm.get('comments'); }

    get cname() { return this.contactForm.get('name'); }
    get crole() { return this.contactForm.get('role'); }
    get cphone() { return this.contactForm.get('phone'); }
    get cmail() { return this.contactForm.get('mail'); }
}  

