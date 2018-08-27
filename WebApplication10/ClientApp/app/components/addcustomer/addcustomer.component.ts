import { Component, OnInit } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { NgForm, FormBuilder, FormGroup, Validators, FormControl, FormArray, Form } from '@angular/forms';
import { Router, ActivatedRoute, NavigationEnd } from '@angular/router';
import { FetchCustomerComponent } from '../fetchcustomer/fetchcustomer.component';
import { CustomerService } from '../../services/csmrservice.service';
import { Contact } from '../Models/Contact';
import { Customer } from '../Models/Customer';
import { Observable } from 'rxjs';
import { User } from '../Models/User';
import { Department } from '../Models/department';
import { forEach } from '@angular/router/src/utils/collection';
import { FullData } from '../Models/FullData';

@Component({
    templateUrl: './AddCustomer.component.html'

})

export class createcustomer implements OnInit {
    customerForm: FormGroup;
    contactForm: FormGroup;
    depForm: FormGroup;
    userForm: FormGroup;

    title: string = "Create";
    customerId: number = 0;
    errorMessage: any;

    addcont: boolean = false;
    edit: boolean = false;
    adduser: boolean = false;
    adddep: boolean = false;

    fulldata: FullData = new FullData();

    contact: Contact = new Contact(0);
    econtact: Contact = new Contact(0);
    contacts: Contact[] = [];

    user: User = new User(0);
    euser: User = new User(0);
    users: User[] = [];
    uid: number = 0;
    did: number = 0;
    cid: number = 0;

    department: Department = new Department(0);
    edepartment: Department = new Department(0);
    departments: Department[] = [];
    cust: Customer = new Customer();
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
        this.userForm = this._fb.group({
            name: new FormControl('', [Validators.required, Validators.minLength(1)]),
            mobile: new FormControl('', [Validators.required, Validators.minLength(1)]),
            mail: new FormControl('', [Validators.required, Validators.minLength(1)]),
            username: new FormControl('', [Validators.required, Validators.minLength(1)]),
            tempudid: new FormControl('', [Validators.required, Validators.minLength(1)]),
            password: new FormControl('', [Validators.required, Validators.minLength(1)]),

        });
        this.depForm = this._fb.group({
            name: new FormControl('', [Validators.required, Validators.minLength(1)]),
            address: new FormControl('', [Validators.required, Validators.minLength(1)]),
            tempduid: new FormControl('', [Validators.required, Validators.minLength(1)]),
        });
    }
    LoadData() {
        this.customerForm.patchValue(this.customer);
        console.log(this.customer);
        this.contacts = this.customer.contacts;
        this.departments = this.customer.departments;
        this.users = this.customer.users;
    }

    

    ngOnInit() {
        
     //   this.customerForm.valueChanges.subscribe(value =>console.log(value));
      //  this.contactForm.valueChanges.subscribe(v => {console.log(v);});

        if (this.customerId > 0) {
            this.title = "Edit";

            this._customerService.getCustomerById(this.customerId)
                .subscribe((resp: Customer) => {
                    this.customer = resp;
                    this.contacts = this.customer.contacts;
                    this.departments = this.customer.departments;
                    this.users = this.customer.users;
                    this.LoadData();
                }
                , error => this.errorMessage = error);            
        }
        

    }

    save() {
        if (!this.customerForm.valid) {
            return;
        }
        this.customer = this.customerForm.value;
    /*    this.customer.name = this.cust.name;
        this.customer.address = this.cust.address;
        this.customer.comments = this.cust.comments;
        this.customer.email = this.cust.email;
        this.customer.phone = this.cust.phone;*/
        this.customer.contacts = this.contacts;
        this.customer.users = this.users;
        this.customer.departments = this.departments;
        console.log(this.customer)
        if (this.title == "Create") {
                this._customerService.saveCustomer(this.customer)
                .subscribe((data) => {
                    this._router.navigate(['/fetch-customer']);
                }, error => this.errorMessage = error)
        }

        else if (this.title == "Edit") {
            console.log("edit" + this.customer)
            this._customerService.updateCustomer(this.customer)
                .subscribe((data) => {
                    this._router.navigate(['/fetch-customer']);
                }, error => this.errorMessage = error)
        }
    }
   
    addContact() {
        this.customerInf();
        this.addcont = true;
    }
    rmCont(contact: Contact) {
        for (let i = 0; i < this.contacts.length;i++)
        {
            if (this.contacts[i] == contact) {
                if (this.title != "Create") {
                    this.fulldata.contactstodelete.push(contact.contactId);
                }
                this.contacts.splice(i,1);
                break;
            }
        }
        
    }
    editCont(contact: Contact) {
        //let cont: Contact = this.contacts.find(x => x === contact);
        this.edit = true;
        this.econtact = contact;
        console.log(this.econtact);
        this.contactForm.patchValue(contact);


    }

    addUser() {
        this.customerInf();
        this.adduser = true;
    }
    rmUser(user: User) {
        for (let i = 0; i < this.users.length;i++) {
            if (this.users[i] == user) {
                if (this.title != "Create") {
                    this.fulldata.userstodelete.push(user.userid);
                }
                this.users.splice(i, 1);
                break;
            }
        }
        console.log(this.users);
    }
    editUser(user: User) {
        this.edit = true;
        this.euser = user;
        console.log(this.euser);
        this.userForm.patchValue(user);

    }

    addDepartment() {
        this.customerInf();
        this.adddep = true;
    }
    rmDepartment(dep: Department) {
        for (let i = 0; i < this.departments.length; i++) {
            if (this.departments[i] === dep) {
                if (this.title != "Create") {
                    this.fulldata.depstodelete.push(dep.departmentId);
                }
                this.departments.splice(i,1);
                break;
            }
        }
    }
    editDepartment(dep: Department) {
        this.edit = true;
        this.edepartment = dep;
        this.depForm.patchValue(dep);

    }

    customerInf() {
        this.addcont = false;
        this.adduser = false;
        this.adddep = false;
    }

    saveContact() {
        this.contact = this.contactForm.value;
        console.log(this.contacts);
        if (!this.edit) {
           // this.contact.contactId = this.cid;
            this.contact.customerid = 0;
            this.contacts.push(this.contact);
            this.cid--;
        }
        else if (this.edit == true)
        {
            for (let i = 0; i < this.contacts.length; i++) {
                if (this.contacts[i] == this.econtact) {
                    this.contact.contactId = this.econtact.contactId;
                    this.contacts[i] = this.contact;
                    break;
                }
            }
            this.edit = false;
        }
        else {
            this.contacts.push(this.contact);
            console.log(this.customer.contacts);
        }
        this.contactForm.reset();
    }

    saveDepartment() {
        this.department = this.depForm.value;
        console.log(this.departments);
        if (!this.edit) {
            this.department.tempdid = this.did;
            console.log(this.department);
            this.department.departmentId = this.department.tempdid;
            this.departments.push(this.department);
            this.did--;
        }
        else if (this.edit == true) {
            for (let i = 0; i < this.departments.length; i++) {
                if (this.departments[i] == this.edepartment) {
                    this.department.tempdid = this.edepartment.tempdid;
                    this.department.departmentId = this.edepartment.departmentId;
                    this.department.userid = this.department.tempduid;
                    console.log(this.department);
                    this.departments[i] = this.department;
                    break;
                }
            }
            this.edit = false;
        }
        this.depForm.reset();
    }

    saveUser() {
        this.user = this.userForm.value;
        console.log(this.user);
        if (!this.edit) {
            this.user.tempuid = this.uid;
            this.user.userid = this.user.tempuid;
            this.user.departmentid = this.user.tempudid;
            console.log(this.user);
            this.users.push(this.user);
            console.log(this.users);
            this.uid--;
        }
        else if (this.edit) {
            for (let i = 0; i < this.users.length; i++) {
                if (this.users[i] == this.euser) {
                    this.user.userid = this.euser.userid;
                    this.user.tempuid = this.euser.tempuid;
                    this.user.departmentid = this.user.tempudid;
                    this.users[i] = this.user;
                    break;
                }
            }
            this.edit = false;
        }
        this.userForm.reset();
    }

    cancel() {
            this._router.navigate(['/fetch-customer']);        
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

    get dname() { return this.depForm.get('name'); }
    get daddress() { return this.depForm.get('address'); }
    get tempduid() { return this.depForm.get('tempduid'); }

    get uname() { return this.userForm.get('name'); }
    get umobile() { return this.userForm.get('mobile'); }
    get umail() { return this.userForm.get('mail'); }
    get uusername() { return this.userForm.get('username'); }
    get upassword() { return this.userForm.get('password'); }
    get udepartmentid() { return this.userForm.get('tempudid') }
}  

