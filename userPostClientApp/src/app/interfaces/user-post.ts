import { Post } from "./post";
import { User } from "./user";

export interface UserPost {
    user: User;
    posts: Post[];
    count: number;
}