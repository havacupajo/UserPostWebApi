import { Component, Input, OnInit } from '@angular/core';
import { DataService } from '../data.service';
import { Geo } from '../interfaces/user';
import { UserPost } from '../interfaces/user-post';

@Component({
  selector: 'app-user-post-details',
  templateUrl: './user-post-details.component.html'
})
export class UserPostDetailsComponent implements OnInit {
  
  @Input() userPostDetails: UserPost;

  constructor(private dataService: DataService) { }

  ngOnInit(): void {
    this.userPostDetails = this.dataService.userPostDetails;
  }

  openLink = function(geo: Geo){
    window.open("//www.google.com/maps/place/" + geo.lat + "," + geo.lng, '_blank');
  }

}
