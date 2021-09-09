import { IContent } from "./IContent";
import { IUser } from "./IUser";

export interface IPost{
    id :string;
    tweetDate :Date;
    text : string;
    author : IUser;
    liked :IUser[];
    contentMedia : IContent[];
}