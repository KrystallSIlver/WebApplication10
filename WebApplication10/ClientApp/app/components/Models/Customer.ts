import { Contact } from "./contact";
import { Department } from "./department"
import { User } from "./user";

export class Customer {

   
    constructor(
        public CustomerId?: number,
        public Name?: string,
        public Address?: string,
        public Email?: string,
        public Phone?: string,
        public Comments?: string,
        public Contact: Contact[] = [],
        public Department: Department[] = [],
        public User: User[] = [] ) { }
}