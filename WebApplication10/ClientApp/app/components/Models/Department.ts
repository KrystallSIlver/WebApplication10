import { Customer } from './Customer';
import { User } from './User';

export class Department {
    constructor(
        public departmentId: number,
        public name?: string,
        public address?: string,
        public customerId?: number,
        public userid?: number,
        public customer?: Customer,
        public user?: User,
        public tempdid?: number,
        public tempduid?: number
    ) { }

}