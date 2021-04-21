import { Injectable } from '@angular/core';
import { UserPost } from './interfaces/user-post';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  public userPostDetails: UserPost;
  constructor() { }
}
