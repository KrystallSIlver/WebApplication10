import { Customer } from './Customer';
import { User } from './User';

export class Department {
    constructor(
        public departmentId?: number,
        public name?: string,
        public address?: string,
        public customerId?: number,
        public managerId?: number,
        public customer?: Customer,
        public user?: User) { }

}