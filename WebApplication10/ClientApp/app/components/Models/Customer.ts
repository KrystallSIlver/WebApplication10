﻿import { Contact } from "./contact";
import { Department } from "./department"
import { User } from "./user";

export class Customer {

   
    constructor(
        public CustomerId?: number,
        public name?: string,
        public address?: string,
        public email?: string,
        public phone?: string,
        public comments?: string,
        public contacts: Contact[] = [],
        public departments: Department[] = [],
        public users: User[] = [] ) { }
}