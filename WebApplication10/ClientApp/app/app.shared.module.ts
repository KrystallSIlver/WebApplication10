import { NgModule } from '@angular/core';
import { CustomerService } from './services/csmrservice.service'
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router'; 


import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchCustomerComponent } from './components/fetchcustomer/fetchcustomer.component';
import { createcustomer } from './components/addcustomer/addcustomer.component';
import { customerdetails } from './components/customerdetails/customerdetails.component';
import { BrowserModule } from '@angular/platform-browser';



@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        FetchCustomerComponent,
        createcustomer,
        customerdetails,
    ],
    imports: [
        CommonModule,
        BrowserModule,
        HttpModule,
        FormsModule,
        ReactiveFormsModule,  
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'fetch-customer', component: FetchCustomerComponent },
            { path: 'register-customer', component: createcustomer },
            { path: 'customers/edit/:id', component: createcustomer },
            { path: 'customer-details/:id', component: customerdetails },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers: [CustomerService] 
})
export class AppModuleShared {
}
