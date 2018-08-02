import { Contact } from './Contact';

export class Customer {
    constructor(
        public CustomerId?: number,
        public Name?: string,
        public Address?: string,
        public Email?: string,
        public Comments?: string,

        public Contact?: Contact[]
    ) { }
}