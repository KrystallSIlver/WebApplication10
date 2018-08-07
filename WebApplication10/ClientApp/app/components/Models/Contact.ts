import { Customer } from "./customer";

export class Contact {
    constructor(
        public ContactId?: number,
        public Name?: string,
        public Role?: string,
        public Phone?: string,
        public Mail?: string,
        public Customerid?: number,
        public customer?: Customer) { }
}