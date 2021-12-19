import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ApiService } from './services/api-service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'sportsystem';

  guest: boolean = true;
  signout: boolean = false;
  addItem: boolean = false;
  username: string = ""

  constructor(
    private service: ApiService,
    private activatedRoute: ActivatedRoute,
    private route: Router
  ) { }

  ngOnInit(): void {
    this.username = localStorage.getItem('username') || 'Guest';
    if (localStorage.getItem('type') == "guest") {
      this.guest = true;
      this.signout = false;
      this.addItem = false;
    }
    else if (localStorage.getItem('type') == "admin" || localStorage.getItem('type') == "seller") {
      this.addItem = true
      this.guest = false;
      this.signout = true;
    }
    else {
      this.guest = false;
      this.signout = true;
      this.addItem = false;
    }
  }

  signOutUser() {
    localStorage.setItem('username', "Guest");
    localStorage.setItem('type', "guest");
    localStorage.setItem('userId', "0");
    window.location.reload();
    this.guest = true;
    this.signout = false;

  }

  OpenUserEdit() {

    this.route.navigate(["edit-account/" + localStorage.getItem('userId')]);
  }
}
