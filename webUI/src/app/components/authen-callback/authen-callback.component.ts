import { ActivatedRoute } from '@angular/router';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-authen-callback',
  templateUrl: './authen-callback.component.html',
  styleUrls: ['./authen-callback.component.css']
})
export class AuthenCallbackComponent implements OnInit {

  error = false;

  constructor(private route: ActivatedRoute) { }

  ngOnInit(): void {

    if (this.route.snapshot.fragment.indexOf('error') > 0) {
      this.error = true;
      return;
    }
  }

}
