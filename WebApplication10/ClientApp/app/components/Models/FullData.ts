import { Customer } from "./customer";
import { Contact } from "./contact"
export class FullData {
    constructor(
        public customer?: Customer,
        public contactstodelete: number[] = [],
        public depstodelete: number[] = [],
        public userstodelete: number[] = []) { }
}