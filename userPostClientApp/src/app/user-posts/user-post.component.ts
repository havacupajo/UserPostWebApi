import { Component, OnInit, Inject } from '@angular/core';
import { UserPost } from '../interfaces/user-post';
import { HttpClient } from '@angular/common/http';
import { DataService } from '../data.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-user-post',
  templateUrl: './user-post.component.html'
})
export class UserPostComponent implements OnInit {
  
  public userPosts: UserPost[];

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private dataService: DataService, private router: Router) { }
 
  ngOnInit() {     
    this.http.get<UserPost[]>(this.baseUrl).subscribe(result => {
      this.userPosts = result;
    }, error => console.error(error));
  }

  showUserDetails = function(userPost: UserPost){
    this.dataService.userPostDetails = userPost;
    this.router.navigateByUrl('/userPosts');
  }

}

