import { Customer } from "./customer";
import { Department } from "./department"
export class User {
    constructor(
        public userid: number,
        public name?: string,
        public mobile?: string,
        public mail?: string,
        public username?: string,
        public password?: string,
        public customerid?: number,
        public departmentid?:number,
        public customer?: Customer,
        public department?: Department,
        public tempuid?: number,
        public tempudid?: number

        ) { }
}