import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { HttpClientModule} from '@angular/common/http';

import { AppComponent } from './app.component';
import { UserPostComponent } from './user-posts/user-post.component';
import { UserPostDetailsComponent } from './user-posts/user-post-details.component';

@NgModule({
  declarations: [
    AppComponent,
    UserPostComponent,
    UserPostDetailsComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot([
      { path: '', component: UserPostComponent },
      { path : 'userPosts', component: UserPostDetailsComponent }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
