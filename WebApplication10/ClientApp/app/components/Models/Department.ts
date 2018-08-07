import { Customer } from './Customer';
import { User } from './User';

export class Department {
    constructor(
        public DepartmentId?: number,
        public Name?: string,
        public Address?: string,
        public CustomerId?: number,
        public ManagerId?: number,
        public Customer?: Customer,
        public User?: User) { }

}