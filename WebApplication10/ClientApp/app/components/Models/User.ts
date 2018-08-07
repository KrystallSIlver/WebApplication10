import { Customer } from "./customer";
import { Department } from "./department"
export class User {
    constructor(
        public UserId?: number,
        public Name?: string,
        public Mobile?: string,
        public Mail?: string,
        public Username?: string,
        public DepartmentName?: string,
        public Password?: string,
        public CustomerId?: number,
        public DepartmentId?:number,
        public Customer?: Customer,
        public Department?: Department) { }
}