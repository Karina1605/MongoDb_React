import { IContent } from "./IContent";

export interface IUser{
    id :string;
    lastName : string;
    firstName :string;
    born? :Date;
    selfDescription? : string;
    photoSource? :IContent; 
}